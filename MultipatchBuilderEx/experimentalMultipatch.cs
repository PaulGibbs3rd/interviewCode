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
    internal class experimentalMultipatch : Button
    {
        protected override async void OnClick()
        {
            if (MapView.Active?.Map == null)
                return;

            // find layer
            var member = MapView.Active.Map.GetLayersAsFlattenedList().FirstOrDefault(l => l.Name == "MultipatchWithTextureSimple") as FeatureLayer;
            if (member == null)
                return;

            // get the multipatch geometry
            var multipatch = MyMultipatchBuilder.CreateExperimentaleMultipatchGeometry();

			bool result = await QueuedTask.Run(() =>
			{
				string gdbPath = ArcGIS.Desktop.Core.Project.Current.DefaultGeodatabasePath;
				string fcName = "New_Multipatch_FC";

				// Create multipatch FC
				// args: geodatabasePath, featureClassName, GeomType, templaceFC, hasM, hasZ, spatialReference
				IReadOnlyList<string> args = Geoprocessing.MakeValueArray(
					gdbPath,
					fcName,
					GeometryType.Multipatch.ToString(),
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
					rowBuffer[featureClassDefinition.GetShapeField()] = multipatch;
					iCursor.Insert(rowBuffer);
					iCursor.Flush();
				}
				return true;
			});



		}
    }
}
