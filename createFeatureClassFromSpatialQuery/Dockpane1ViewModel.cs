using ArcGIS.Core.CIM;
using ArcGIS.Core.Data;
using ArcGIS.Core.Data.DDL;
using ArcGIS.Core.Geometry;
using ArcGIS.Desktop.Catalog;
using ArcGIS.Desktop.Core;
using ArcGIS.Desktop.Editing;
using ArcGIS.Desktop.Extensions;
using ArcGIS.Desktop.Framework;
using ArcGIS.Desktop.Framework.Contracts;
using ArcGIS.Desktop.Framework.Dialogs;
using ArcGIS.Desktop.Framework.Threading.Tasks;
using ArcGIS.Desktop.KnowledgeGraph;
using ArcGIS.Desktop.Layouts;
using ArcGIS.Desktop.Mapping;
using ArcGIS.Desktop.Mapping.Events;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Input;

namespace createFeatureClassFromSpatialQuery
{
    internal class Dockpane1ViewModel : DockPane
    {
        private const string _dockPaneID = "createFeatureClassFromSpatialQuery_Dockpane1";

        protected Dockpane1ViewModel()
        {
            // Only subscribe to events here, do not call LoadLayers yet.
        }

        /// <summary>
        /// Show the DockPane.
        /// </summary>
        internal static void Show()
        {
            DockPane pane = FrameworkApplication.DockPaneManager.Find(_dockPaneID);
            if (pane == null)
                return;

            // Subscribe to the MapViewInitialized event when the pane is shown
            MapViewInitializedEvent.Subscribe(OnMapViewInitialized);

            pane.Activate();
        }

        private static void OnMapViewInitialized(MapViewEventArgs obj)
        {
            var viewModel = FrameworkApplication.DockPaneManager.Find(_dockPaneID) as Dockpane1ViewModel;
            viewModel?.LoadLayers();
        }

        protected override Task InitializeAsync()
        {
            if (MapView.Active != null)
            {
                LoadLayers();
            }
            return base.InitializeAsync();
        }

        /// <summary>
        /// Text shown near the top of the DockPane.
        /// </summary>
        private string _heading = "My DockPane";
        public string Heading
        {
            get => _heading;
            set => SetProperty(ref _heading, value);
        }

        private ObservableCollection<string> _featureLayers = new ObservableCollection<string>();
        public ObservableCollection<string> FeatureLayers
        {
            get => _featureLayers;
            set => SetProperty(ref _featureLayers, value);
        }

        private ObservableCollection<string> _geometryLayers = new ObservableCollection<string>();
        public ObservableCollection<string> GeometryLayers
        {
            get => _geometryLayers;
            set => SetProperty(ref _geometryLayers, value);
        }

        private string _selectedFeatureLayerName;
        public string SelectedFeatureLayerName
        {
            get => _selectedFeatureLayerName;
            set => SetProperty(ref _selectedFeatureLayerName, value);
        }

        private string _selectedGeometryLayerName;
        public string SelectedGeometryLayerName
        {
            get => _selectedGeometryLayerName;
            set => SetProperty(ref _selectedGeometryLayerName, value);
        }

        private bool _saveAsNewFeatureClass;
        public bool SaveAsNewFeatureClass
        {
            get => _saveAsNewFeatureClass;
            set => SetProperty(ref _saveAsNewFeatureClass, value);
        }

        private RelayCommand _runSpatialQueryCommand;
        public ICommand RunSpatialQueryCommand => _runSpatialQueryCommand ?? (_runSpatialQueryCommand = new RelayCommand(async () => await RunSpatialQuery(), () => CanRunSpatialQuery()));

        private bool CanRunSpatialQuery()
        {
            return !string.IsNullOrEmpty(SelectedFeatureLayerName) && !string.IsNullOrEmpty(SelectedGeometryLayerName);
        }

        private async Task RunSpatialQuery()
        {
            await QueuedTask.Run(() =>
            {
                try
                {
                    Map activeMap = MapView.Active.Map;

                    FeatureLayer featureLayer = activeMap.Layers.FirstOrDefault(layer => layer.Name == SelectedFeatureLayerName) as FeatureLayer;
                    FeatureLayer geometryLayer = activeMap.Layers.FirstOrDefault(layer => layer.Name == SelectedGeometryLayerName) as FeatureLayer;

                    if (featureLayer == null || geometryLayer == null)
                    {
                        MessageBox.Show("Please select valid layers.");
                        return;
                    }

                    List<Dictionary<string, object>> features = new List<Dictionary<string, object>>();

                    // Get the geometries from the geometryLayer
                    using (RowCursor geometryCursor = geometryLayer.Search(null))
                    {
                        while (geometryCursor.MoveNext())
                        {
                            using (Feature geometryFeature = geometryCursor.Current as Feature)
                            {
                                Geometry geometry = geometryFeature.GetShape();

                                // Perform the spatial query for each geometry
                                SpatialQueryFilter spatialQueryFilter = new SpatialQueryFilter
                                {
                                    FilterGeometry = geometry,
                                    SpatialRelationship = SpatialRelationship.Contains
                                };

                                using (RowCursor featureCursor = featureLayer.Search(spatialQueryFilter))
                                {
                                    while (featureCursor.MoveNext())
                                    {
                                        using (Feature feature = featureCursor.Current as Feature)
                                        {
                                            // Clone the feature geometry and attributes
                                            Geometry clonedGeometry = feature.GetShape().Clone();
                                            var fields = feature.GetFields();
                                            var clonedAttributes = new Dictionary<string, object>();

                                            // Clone each attribute except non-editable fields
                                            foreach (var field in fields)
                                            {
                                                if (field.FieldType != FieldType.Geometry && field.FieldType != FieldType.GlobalID && field.FieldType != FieldType.OID)
                                                {
                                                    clonedAttributes[field.Name] = feature[field.Name];
                                                }
                                            }

                                            // Add the cloned geometry and attributes to the list
                                            clonedAttributes["SHAPE"] = clonedGeometry;
                                            features.Add(clonedAttributes);
                                        }
                                    }
                                }
                            }
                        }
                    }

                    if (features.Count == 0)
                    {
                        MessageBox.Show("No features found within the geometries.");
                        return;
                    }

                    // Save the results to a new feature class if required
                    if (SaveAsNewFeatureClass)
                    {
                        string newFeatureClassName = "NewFeatureClass_" + DateTime.Now.ToString("yyyyMMdd_HHmmss");
                        string gdbPath = Project.Current.DefaultGeodatabasePath;

                        using (Geodatabase geodatabase = new Geodatabase(new FileGeodatabaseConnectionPath(new Uri(gdbPath))))
                        {
                            FeatureClass existingFeatureClass = featureLayer.GetFeatureClass();
                            SpatialReference spatialReference = existingFeatureClass.GetDefinition().GetSpatialReference();

                            CreateFeatureClassSnippet(geodatabase, existingFeatureClass, spatialReference, newFeatureClassName, features);

                            // Add the new feature class to the map
                            LayerCreationParams layerCreationParams = new LayerCreationParams(new Uri(gdbPath + "\\" + newFeatureClassName))
                            {
                                IsVisible = true
                            };
                            LayerFactory.Instance.CreateLayer<FeatureLayer>(layerCreationParams, activeMap);
                        }
                    }

                }
                catch (Exception ex)
                {
                    MessageBox.Show($"An error occurred: {ex.Message}");
                }
            });
        }

        private void CreateFeatureClassSnippet(Geodatabase geodatabase, FeatureClass existingFeatureClass, SpatialReference spatialReference, string newFeatureClassName, List<Dictionary<string, object>> features)
        {
            // Create field descriptions
            ArcGIS.Core.Data.DDL.FieldDescription globalIDFieldDescription = ArcGIS.Core.Data.DDL.FieldDescription.CreateGlobalIDField();
            ArcGIS.Core.Data.DDL.FieldDescription objectIDFieldDescription = ArcGIS.Core.Data.DDL.FieldDescription.CreateObjectIDField();
            ArcGIS.Core.Data.DDL.FieldDescription timeFieldDescription = new ArcGIS.Core.Data.DDL.FieldDescription("CreationTime", FieldType.Date);
            List<ArcGIS.Core.Data.DDL.FieldDescription> fieldDescriptions = new List<ArcGIS.Core.Data.DDL.FieldDescription>
            {
                globalIDFieldDescription,
                objectIDFieldDescription,
                timeFieldDescription
            };

            // Add all fields from the existing feature class, except the geometry field
            FeatureClassDefinition existingFeatureClassDefinition = existingFeatureClass.GetDefinition();
            foreach (Field existingField in existingFeatureClassDefinition.GetFields())
            {
                if (existingField.FieldType != FieldType.GlobalID && existingField.FieldType != FieldType.OID && existingField.FieldType != FieldType.Geometry)
                {
                    // Create a FieldDescription from the existing field
                    ArcGIS.Core.Data.DDL.FieldDescription fieldDescription = new ArcGIS.Core.Data.DDL.FieldDescription(existingField.Name, existingField.FieldType)
                    {
                        AliasName = existingField.AliasName,
                        IsNullable = existingField.IsNullable,
                        Length = existingField.Length,
                        Precision = existingField.Precision,
                        Scale = existingField.Scale
                    };

                    fieldDescriptions.Add(fieldDescription);
                }
            }

            // Create a ShapeDescription object
            ShapeDescription shapeDescription = new ShapeDescription(existingFeatureClassDefinition);

            // Create a FeatureClassDescription object to describe the feature class to create
            FeatureClassDescription featureClassDescription = new FeatureClassDescription(newFeatureClassName, fieldDescriptions.AsEnumerable(), shapeDescription);

            // Create a SchemaBuilder object
            SchemaBuilder schemaBuilder = new SchemaBuilder(geodatabase);

            // Add the creation of the new feature class to our list of DDL tasks
            schemaBuilder.Create(featureClassDescription);

            // Execute the DDL
            bool success = schemaBuilder.Build();

            // Inspect error messages
            if (!success)
            {
                IReadOnlyList<string> errorMessages = schemaBuilder.ErrorMessages;
                MessageBox.Show(string.Join("\n", errorMessages));
                return;
            }

            // Add the features to the new feature class
            using (FeatureClass newFeatureClass = geodatabase.OpenDataset<FeatureClass>(newFeatureClassName))
            {
                var editOperation = new EditOperation();
                editOperation.Callback(context =>
                {
                    foreach (var featureDict in features)
                    {
                        using (RowBuffer rowBuffer = newFeatureClass.CreateRowBuffer())
                        {
                            foreach (var attribute in featureDict)
                            {
                                // Skip non-editable fields
                                if (attribute.Key != "OBJECTID" && attribute.Key != "GlobalID")
                                {
                                    rowBuffer[attribute.Key] = attribute.Value;
                                }
                            }
                            rowBuffer["CreationTime"] = DateTime.Now;
                            using (Row newRow = newFeatureClass.CreateRow(rowBuffer))
                            {
                                newRow.Store();
                            }
                        }
                    }
                }, newFeatureClass);

                editOperation.Execute();
            }
        }

        private void LoadLayers()
        {
            QueuedTask.Run(() =>
            {
                if (MapView.Active == null)
                    return;

                Map activeMap = MapView.Active.Map;
                var featureLayers = activeMap.Layers.OfType<FeatureLayer>().Select(layer => layer.Name).ToList();

                FeatureLayers = new ObservableCollection<string>(featureLayers);
                GeometryLayers = new ObservableCollection<string>(featureLayers); // Assuming geometry layers are also feature layers
            });
        }
    }

    /// <summary>
    /// Button implementation to show the DockPane.
    /// </summary>
    internal class Dockpane1_ShowButton : Button
    {
        protected override void OnClick()
        {
            Dockpane1ViewModel.Show();
        }
    }
}
