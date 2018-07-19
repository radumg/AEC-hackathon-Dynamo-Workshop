/* dynamo directives */
using Dynamo.Controls;
using Dynamo.Wpf;
using System.Windows.Media;
using System;
using System.Windows.Shapes;
using Dynamo.ViewModels;

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

      ui.SliderA.ValueChanged += Slider_ValueChanged;
      ui.SliderR.ValueChanged += Slider_ValueChanged;
      ui.SliderG.ValueChanged += Slider_ValueChanged;
      ui.SliderB.ValueChanged += Slider_ValueChanged;

    }

    private void Slider_ValueChanged(object sender, System.Windows.RoutedPropertyChangedEventArgs<double> e)
    {

      ((Rectangle)_nodeview.grid.FindName("nodeBackground")).Fill = new SolidColorBrush(Color.FromArgb(
                                                    Convert.ToByte(_model.SliderValueA), 
                                                    Convert.ToByte(_model.SliderValueR),
                                                    Convert.ToByte(_model.SliderValueG), 
                                                    Convert.ToByte(_model.SliderValueB)));
    }

    public void Dispose()
    {
    }
  }
}
