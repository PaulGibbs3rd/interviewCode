using ArcGIS.Core.CIM;
using ArcGIS.Core.Data;
using ArcGIS.Core.Geometry;
using ArcGIS.Desktop.Catalog;
using ArcGIS.Desktop.Core;
using ArcGIS.Desktop.Editing;
using ArcGIS.Desktop.Extensions;
using ArcGIS.Desktop.Framework;
using ArcGIS.Desktop.Framework.Contracts;
using ArcGIS.Desktop.Framework.Dialogs;
using ArcGIS.Desktop.Framework.Threading.Tasks;
using ArcGIS.Desktop.Layouts;
using ArcGIS.Desktop.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ArcGIS.Desktop.Core.Geoprocessing;

namespace MultipatchBuilderEx
{
    internal class CreateMultipoint : Button
    {
        protected override async void OnClick()
        {
            if (MapView.Active?.Map == null)
                return;

            // find layer
            var member = MapView.Active.Map.GetLayersAsFlattenedList().FirstOrDefault(l => l.Name == "MultipatchWithTextureSimple") as FeatureLayer;
            if (member == null)
                return;

            var multipoint = MultipointBuilder.CreateSampleMultipoint3D();
            var centroidPoint = MultipointBuilder.GetCentroidWithZ(multipoint);
            bool result = await QueuedTask.Run(() =>
            {
                string gdbPath = ArcGIS.Desktop.Core.Project.Current.DefaultGeodatabasePath;
                string fcName = "New_Multipoint_FC";

                // Create multipoint FC
                // args: geodatabasePath, featureClassName, GeomType, templaceFC, hasM, hasZ, spatialReference
                IReadOnlyList<string> args = Geoprocessing.MakeValueArray(
                    gdbPath,
                    fcName,
                    GeometryType.Multipoint.ToString(),
                    string.Empty,
                    "DISABLED",
                    "ENABLED",
                    SpatialReferences.WGS84
                );
                Geoprocessing.ExecuteToolAsync(
                    toolPath: "management.CreateFeatureclass",
                    values: args,
                    environments: null,
                    flags: GPExecuteToolFlags.Default);
                // Add multipatch to new FC
                using (Geodatabase gdb = new Geodatabase(new FileGeodatabaseConnectionPath(new Uri(gdbPath))))
                using (FeatureClass featureClass = gdb.OpenDataset<FeatureClass>(fcName))
                using (FeatureClassDefinition featureClassDefinition = featureClass.GetDefinition())
                using (InsertCursor iCursor = featureClass.CreateInsertCursor())
                using (RowBuffer rowBuffer = featureClass.CreateRowBuffer())
                {
                    rowBuffer[featureClassDefinition.GetShapeField()] = multipoint;
                    iCursor.Insert(rowBuffer);
                    iCursor.Flush();
                }
                if (centroidPoint != null)
                {
                    string fcName1 = "New_Centroid_FC";
                    IReadOnlyList<string> args2 = Geoprocessing.MakeValueArray(
                    gdbPath,
                    fcName1,
                    GeometryType.Point.ToString(),
                    string.Empty,
                    "DISABLED",
                    "ENABLED",
                    SpatialReferences.WGS84
);
                    Geoprocessing.ExecuteToolAsync(
                        toolPath: "management.CreateFeatureclass",
                        values: args2,
                        environments: null,
                        flags: GPExecuteToolFlags.Default);
                    using (Geodatabase gdb = new Geodatabase(new FileGeodatabaseConnectionPath(new Uri(gdbPath))))
                    using (FeatureClass featureClass = gdb.OpenDataset<FeatureClass>(fcName1))
                    using (FeatureClassDefinition featureClassDefinition = featureClass.GetDefinition())
                    using (InsertCursor iCursor = featureClass.CreateInsertCursor())
                    using (RowBuffer rowBuffer = featureClass.CreateRowBuffer())
                    {
                        // Set the shape field to the centroid geometry
                        rowBuffer[featureClassDefinition.GetShapeField()] = centroidPoint;
                        iCursor.Insert(rowBuffer);
                        iCursor.Flush(); // Commit the centroid point geometry
                    }
                }

                return true;
            });

        }
    }
}
