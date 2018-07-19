/* dynamo directives */
using Dynamo.Controls;
using Dynamo.ViewModels;
using Dynamo.Wpf;

namespace DynamoWorkshop.ExplicitNode
{
  public class HelloUINodeView : INodeViewCustomization<HelloUI>
  {
    DynamoViewModel _dynamoViewModel;
    NodeView _nodeview;
    HelloUI _model;

    public void CustomizeView(HelloUI model, NodeView nodeView)
    {
      _dynamoViewModel = nodeView.ViewModel.DynamoViewModel;
      _nodeview = nodeView;
      _model = model;

      var ui = new ColorSelector();
      nodeView.inputGrid.Children.Add(ui);
      ui.DataContext = model;
    }

    public void Dispose()
    {
    }
  }
}
