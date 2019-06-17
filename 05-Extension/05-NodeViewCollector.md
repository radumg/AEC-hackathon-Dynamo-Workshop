# 5.5 - NodeView Collector <!-- omit in toc --> 

This extra chapter gives a compiled solution on how to be able to track and map `NodeView` instances to their corresponding `NodeModel`.

- [Extension Methods](#extension-methods)
- [NodeView Collector](#nodeview-collector)

## Extension Methods
These extension methods are used to find some particular type of elements on a window's WPF Visual Tree.

```csharp
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;

namespace DiagnosticToolkit.Utilities
{
    //https://github.com/mjkkirschner/DynamoSamples/blob/extensionWorkshop/src/NodeUISampleViewExtension/NodeUISampleViewExtension.cs
    public static class WindowExtensions
    {
        ///https://stackoverflow.com/questions/10279092/how-to-get-children-of-a-wpf-container-by-type
        public static T GetChildOfType<T>(this DependencyObject depObj) where T : DependencyObject
        {
            if (depObj == null) return null;

            for (int i = 0; i < VisualTreeHelper.GetChildrenCount(depObj); i++)
            {
                var child = VisualTreeHelper.GetChild(depObj, i);

                var result = (child as T) ?? GetChildOfType<T>(child);
                if (result != null) return result;
            }
            return null;
        }

        //https://stackoverflow.com/questions/974598/find-all-controls-in-wpf-window-by-type/978352
        public static IEnumerable<T> FindVisualChildren<T>(this DependencyObject depObj) where T : DependencyObject
        {
            if (depObj != null)
            {
                for (int i = 0; i < VisualTreeHelper.GetChildrenCount(depObj); i++)
                {
                    DependencyObject child = VisualTreeHelper.GetChild(depObj, i);
                    if (child != null && child is T)
                    {
                        yield return (T)child;
                    }

                    foreach (T childOfChild in FindVisualChildren<T>(child))
                    {
                        yield return childOfChild;
                    }
                }
            }
        }
    }
}
```

## NodeView Collector

Using the above window's extension methods and a clever register/unregister of events, we can inspect Dynamo's UI tree to collect and map all `NodeView` instances to their corresponding `NodeModel` element.

```csharp
using Dynamo.Controls;
using Dynamo.Wpf.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dynamo.Graph.Nodes;
using System.Windows;
using Dynamo.ViewModels;

namespace DiagnosticToolkit.Utilities
{
    public class NodeViewCollector
    {
        private Window dynamoWindow;
        private Guid lastGuidAdded { get; set; }
        private Dictionary<Guid, NodeView> collector = new Dictionary<Guid, NodeView>();

        public NodeViewCollector(ViewLoadedParams parameters)
        {
            dynamoWindow = parameters.DynamoWindow;
            parameters.CurrentWorkspaceModel.NodeAdded += OnNodeAdded;
            parameters.CurrentWorkspaceModel.NodeRemoved += OnNodeRemoved;

            //parameters.CurrentWorkspaceChanged += OnCurrentWorkspaceChanged;
            (parameters.DynamoWindow.DataContext as DynamoViewModel).Model.WorkspaceAdded += OnCurrentWorkspaceChanged;

            this.GetAllOnCurrentWindow();
        }

        private void OnCurrentWorkspaceChanged(Dynamo.Graph.Workspaces.IWorkspaceModel workspaceModel)
        {
            workspaceModel.NodeAdded += OnNodeAdded;
            workspaceModel.NodeRemoved += OnNodeRemoved;

            this.ResetCollector();
            this.GetAllOnCurrentWindow();
        }

        #region Private Methods
        private void GetAllOnCurrentWindow()
        {
            var nodeViews = this.dynamoWindow.FindVisualChildren<NodeView>().ToList();
            foreach (var nodeView in nodeViews)
            {
                NodeModel model = nodeView.ViewModel.NodeModel;
                this.collector.Add(model.GUID, nodeView);

            }
        }

        private void ResetCollector()
        {
            this.collector = new Dictionary<Guid, NodeView>();
        }

        private void OnNodeRemoved(NodeModel nodeModel)
        {
            this.collector.Remove(nodeModel.GUID);
        }

        private void OnNodeAdded(NodeModel nodeModel)
        {
            lastGuidAdded = nodeModel.GUID;
            dynamoWindow.LayoutUpdated += DynamoWindow_LayoutUpdated;
        }

        private void DynamoWindow_LayoutUpdated(object sender, EventArgs e)
        {
            var nodeViews = this.dynamoWindow.FindVisualChildren<NodeView>().ToList();
            nodeViews.Reverse();
            foreach (var nodeView in nodeViews)
            {
                NodeModel model = nodeView.ViewModel.NodeModel;
                if (model.GUID == this.lastGuidAdded)
                {
                    this.collector.Add(model.GUID, nodeView);
                    break;
                }
            }

            dynamoWindow.LayoutUpdated -= DynamoWindow_LayoutUpdated;
        }
        #endregion

        #region Public Methods

        public List<NodeView> NodeViews
        {
            get => collector.Values.ToList();
        }

        public NodeView Get(Guid guid)
        {
            NodeView nodeView;
            if(this.collector.TryGetValue(guid, out nodeView))
            {
                return nodeView;
            }

            return null;
        }

        #endregion
    }
}
```