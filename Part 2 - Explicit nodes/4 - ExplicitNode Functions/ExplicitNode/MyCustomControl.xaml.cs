using System.Windows;
using System.Windows.Controls;


namespace DynamoWorkshop.ExplicitNode
{
  /// <summary>
  /// Interaction logic for MyCustomControl.xaml
  /// </summary>
  public partial class MyCustomControl : UserControl
  {
    public MyCustomControl()
    {
      InitializeComponent();
    }

    private void Button_Click(object sender, RoutedEventArgs e)
    {
      MessageBox.Show("Value is " + ValueSlider.Value);
    }
  }
}
