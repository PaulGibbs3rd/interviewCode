using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ArcGIS.Desktop.Framework.Threading.Tasks;
using System.Collections.Generic;
using ArcGIS.Core.Geometry;
using ArcGIS.Desktop.Mapping;

namespace MultipatchBuilderEx
{
    public class MultipointBuilder
    {

        public static Multipoint CreateSampleMultipoint3D()
        {
            double x = 0;
            double y = 0;
            double z = 111349;
            List<Coordinate3D> coords = new List<Coordinate3D>()
            {
                    //new Coordinate3D(0, 0, 1*z),
                    new Coordinate3D(1, 0, 0*z),
                    new Coordinate3D(0, 1, 1*z),
                    new Coordinate3D(-1, 0, 2*z),
                    new Coordinate3D(0, -1, 3*z),
                    new Coordinate3D(1, 0, 4*z),
            };
            var mpb = new ArcGIS.Core.Geometry.MultipointBuilderEx(coords,SpatialReferences.WGS84);
            return mpb.ToGeometry();
        }

        public static MapPoint GetCentroidWithZ(Multipoint inputGeometry)
        {
            
                // Check if input geometry is null
                if (inputGeometry == null)
                    return null;
                double avgZ = inputGeometry.Points.Select(prop => prop.Z).Average();
                // Use GeometryEngine to calculate the centroid
                var centroid = GeometryEngine.Instance.Centroid(inputGeometry);
                
                // Ensure the result is a MapPoint
                if (centroid is MapPoint centroidPoint)
                {
                    
                    var mpb = new ArcGIS.Core.Geometry.MapPointBuilderEx(centroidPoint.X, centroidPoint.Y, avgZ, SpatialReferences.WGS84);
                    return mpb.ToGeometry();
                }

                return null;
           
        }
    }
}
