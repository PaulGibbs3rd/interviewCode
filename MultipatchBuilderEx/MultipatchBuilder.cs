/*

   Copyright 2019 Esri

   Licensed under the Apache License, Version 2.0 (the "License");
   you may not use this file except in compliance with the License.
   You may obtain a copy of the License at

       https://www.apache.org/licenses/LICENSE-2.0

   Unless required by applicable law or agreed to in writing, software
   distributed under the License is distributed on an "AS IS" BASIS,
   WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.

   See the License for the specific language governing permissions and
   limitations under the License.

*/
using System.Collections.Generic;
using ArcGIS.Core.Geometry;

namespace MultipatchBuilderEx
{
  public class MyMultipatchBuilder
  {
    // static method to hold the coordinates and code for building a multipatch geometry using the new 2.5 MultipatchBuilderEx class
    public static Multipatch CreateTriangleMultipatchGeometry()
    {
      #region Coordinates

      var coords_face1 = new List<Coordinate3D>()
      {
        new Coordinate3D(12.495461061000071,41.902603910000039,62.552700000000186),
        new Coordinate3D(12.495461061000071,41.902603910000039,59.504700000004959),
        new Coordinate3D(12.495461061000071,41.902576344000067,59.504700000004959),
        new Coordinate3D(12.495461061000071,41.902603910000039,62.552700000000186),
        new Coordinate3D(12.495461061000071,41.902576344000067,59.504700000004959),
        new Coordinate3D(12.495461061000071,41.902576344000067,62.552700000000186),
      };

      var coords_face2 = new List<Coordinate3D>()
      {
        new Coordinate3D(12.495461061000071, 41.902576344000067, 62.552700000000186),
        new Coordinate3D(12.495461061000071, 41.902576344000067, 59.504700000004959),
        new Coordinate3D(12.495488442000067, 41.902576344000067, 59.504700000004959),
        new Coordinate3D(12.495461061000071, 41.902576344000067, 62.552700000000186),
        new Coordinate3D(12.495488442000067, 41.902576344000067, 59.504700000004959),
        new Coordinate3D(12.495488442000067, 41.902576344000067, 62.552700000000186),
      };

      var coords_face3 = new List<Coordinate3D>()
      {
        new Coordinate3D(12.495488442000067, 41.902576344000067, 62.552700000000186),
        new Coordinate3D(12.495488442000067, 41.902576344000067, 59.504700000004959),
        new Coordinate3D(12.495488442000067, 41.902603910000039, 59.504700000004959),
        new Coordinate3D(12.495488442000067, 41.902576344000067, 62.552700000000186),
        new Coordinate3D(12.495488442000067, 41.902603910000039, 59.504700000004959),
        new Coordinate3D(12.495488442000067, 41.902603910000039, 62.552700000000186),
      };

      var coords_face4 = new List<Coordinate3D>()
      {
        new Coordinate3D(12.495488442000067, 41.902576344000067, 59.504700000004959),
        new Coordinate3D(12.495461061000071, 41.902576344000067, 59.504700000004959),
        new Coordinate3D(12.495461061000071, 41.902603910000039, 59.504700000004959),
        new Coordinate3D(12.495488442000067, 41.902576344000067, 59.504700000004959),
        new Coordinate3D(12.495461061000071, 41.902603910000039, 59.504700000004959),
        new Coordinate3D(12.495488442000067, 41.902603910000039, 59.504700000004959),
      };

      var coords_face5 = new List<Coordinate3D>()
      {
        new Coordinate3D(12.495488442000067, 41.902603910000039, 59.504700000004959),
        new Coordinate3D(12.495461061000071, 41.902603910000039, 59.504700000004959),
        new Coordinate3D(12.495461061000071, 41.902603910000039, 62.552700000000186),
        new Coordinate3D(12.495488442000067, 41.902603910000039, 59.504700000004959),
        new Coordinate3D(12.495461061000071, 41.902603910000039, 62.552700000000186),
        new Coordinate3D(12.495488442000067, 41.902603910000039, 62.552700000000186),
      };

      var coords_face6 = new List<Coordinate3D>()
      {
        new Coordinate3D(12.495488442000067, 41.902603910000039, 62.552700000000186),
        new Coordinate3D(12.495461061000071, 41.902603910000039, 62.552700000000186),
        new Coordinate3D(12.495461061000071, 41.902576344000067, 62.552700000000186),
        new Coordinate3D(12.495488442000067, 41.902603910000039, 62.552700000000186),
        new Coordinate3D(12.495461061000071, 41.902576344000067, 62.552700000000186),
        new Coordinate3D(12.495488442000067, 41.902576344000067, 62.552700000000186),
      };
      #endregion

      // create a list of patch objects
      var patches = new List<Patch>();

      // create the multipatchBuilderEx object
      var mpb = new ArcGIS.Core.Geometry.MultipatchBuilderEx();

      // make each patch using the appropriate coordinates and add to the patch list
      var patch = mpb.MakePatch(PatchType.Triangles);
      patch.Coords = coords_face1;
      patches.Add(patch);

      patch = mpb.MakePatch(PatchType.Triangles);
      patch.Coords = coords_face2;
      patches.Add(patch);

      patch = mpb.MakePatch(PatchType.Triangles);
      patch.Coords = coords_face3;
      patches.Add(patch);

      patch = mpb.MakePatch(PatchType.Triangles);
      patch.Coords = coords_face4;
      patches.Add(patch);

      patch = mpb.MakePatch(PatchType.Triangles);
      patch.Coords = coords_face5;
      patches.Add(patch);

      patch = mpb.MakePatch(PatchType.Triangles);
      patch.Coords = coords_face6;
      patches.Add(patch);

      // assign the patches to the multipatchBuilder
      mpb.Patches = patches;

      // call ToGeometry to get the multipatch
      var multipatch = mpb.ToGeometry() as Multipatch;

      return multipatch;

    }

    public static Multipatch CreateExperimentaleMultipatchGeometry() {
            // List of 3d coordinates
            double x = 0;
            double y = 0;
            double z = 111349;
            List<Coordinate3D> coords = new List<Coordinate3D>()
            {
                    new Coordinate3D(0, 0, 1*z),
                    new Coordinate3D(1, 0, 0*z),
                    new Coordinate3D(0, 1, 0*z),
                    new Coordinate3D(-1, 0, 0*z),
                    new Coordinate3D(0, -1, 0*z),
                    new Coordinate3D(1, 0, 0*z),
            };
            var mpb = new ArcGIS.Core.Geometry.MultipatchBuilderEx() { HasZ = true, SpatialReference = SpatialReferences.WGS84 };
            //bool z = mpb.HasZ;
            // Create multipatch builder and create triangle-fan patch using coordinates
            // MultipatchBuilderEx builder = new MultipatchBuilderEx() { HasZ = true, SpatialReference = SpatialReferences.WGS84 };
            Patch patch = mpb.MakePatch(PatchType.TriangleFan);
            patch.Coords = coords;

            patch.Material = new BasicMaterial() { Color = System.Windows.Media.Colors.Red, EdgeColor = System.Windows.Media.Colors.DarkRed };
            mpb.Patches.Add(patch);
            var multipatch = mpb.ToGeometry() as Multipatch;
            return multipatch;
        }
  }
}
