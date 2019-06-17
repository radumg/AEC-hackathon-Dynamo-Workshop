# 5.4 - Events <!-- omit in toc --> 

On this final section, we'll learn what **Events** are by creating a simple WPF ViewExtension that tracks changes on Dynamo's canvas.

An event in C# is an occurrence of an action that can be acted upon. Events can be raised by an user when he/she clicks, moves the mouse, presses a key, or programmatically by other means, like for example tracking stock market prices, and event can be automatically raised when the price reaches a predefined value.

- [Tracking events on Dynamo](#tracking-events-on-dynamo)
  - [The View](#the-view)
  - [The ViewModel](#the-viewmodel)
  - [The Model](#the-model)

## Tracking events on Dynamo
*This example is taken from the [Dynamo Developer Workshop from AU Vegas 2019](https://github.com/DynamoDS/DeveloperWorkshop/tree/master/CBW227912%20-%20Leveraging%20Speckle%20in%20Dynamo#tracking-changes)*

Let's now explore another very useful functionality available via the `ViewStartupParams` while making use of the MVVM pattern and data binding. 

With  `ViewStartupParams.CurrentWorkspace` we can access several events:

```c#
viewLoadedParams.CurrentWorkspaceChanged
viewLoadedParams.NotificationRecieved
viewLoadedParams.CurrentWorkspaceModel.NodeAdded
viewLoadedParams.CurrentWorkspaceModel.NodeRemoved
viewLoadedParams.CurrentWorkspaceModel.ConnectorAdded
viewLoadedParams.CurrentWorkspaceModel.ConnectorDeleted
```


### The View

Let's edit our ViewExtension to make use of them. Create a `NodeTracker.xaml` window which will contain the list of our tracked events. This will be our **View**.

```xml
<Window x:Class="HelloDynamo.NodeTracker"
        xmlns="http://schemas.microsoft.com/winfx/2006/xaml/presentation"
        xmlns:x="http://schemas.microsoft.com/winfx/2006/xaml"
        xmlns:d="http://schemas.microsoft.com/expression/blend/2008"
        xmlns:mc="http://schemas.openxmlformats.org/markup-compatibility/2006"
        xmlns:local="clr-namespace:HelloDynamo"
        mc:Ignorable="d"
        Title="NodeTracker" Height="450" Width="400">
  <Grid>
    <ListView ItemsSource="{Binding Actions}"></ListView>
  </Grid>
</Window>
```
> Note: On `xmlns:local`, make sure to use the namespace your `IViewExtension` is declared.

Where `NodeTracker.xaml.cs` looks like:

```C#
using System.Windows;

namespace HelloDynamo
{
  /// <summary>
  /// Tracks and displays events for node/connector added/removed 
  /// </summary>
  public partial class NodeTracker : Window
  {
    public NodeTracker()
    {
      InitializeComponent();
      this.Closing += NodeTracker_Closing;
    }

    private void NodeTracker_Closing(object sender, System.ComponentModel.CancelEventArgs e)
    {
      //hide window instead of closing it, so we keep tracking in the background
      e.Cancel = true;
      this.Hide();
    }
  }
}
```
### The ViewModel

Now let's crate a **ViewModel** that will bind to the window and will keep track of the changes to the `CurrentWorkspaceModel`, create a new class `NodeTrackerViewModel.cs`:

```C#
using System;
using System.Collections.ObjectModel;
using Dynamo.Core;
using Dynamo.Extensions;

namespace HelloDynamo
{
  public class NodeTrackerViewModel: NotificationObject, IDisposable

  {
    private ReadyParams readyParams;

    private ObservableCollection<string> _actions = new ObservableCollection<string> ();
    public ObservableCollection<string> Actions 
    { 
        get 
        { 
            return _actions;
        }
        set 
        { 
            _actions = value;
            RaisePropertyChanged("Actions"); 
        }
    }

    public NodeTrackerViewModel(ReadyParams p)
    {
      readyParams = p;

      RegisterEvents();
    }

    private void RegisterEvents()
    {
        //subscribing to dynamo events
        readyParams.CurrentWorkspaceModel.NodeAdded += CurrentWorkspaceModel_NodeAdded;
        readyParams.CurrentWorkspaceModel.NodeRemoved += CurrentWorkspaceModel_NodeRemoved;
        readyParams.CurrentWorkspaceModel.ConnectorAdded += CurrentWorkspaceModel_ConnectorAdded;
        readyParams.CurrentWorkspaceModel.ConnectorDeleted += CurrentWorkspaceModel_ConnectorDeleted;

        //making sure the binding is updated when elements are added and removed
        Actions.CollectionChanged += Actions_CollectionChanged;
    }

    private void UnregisterEvents()
    {
        readyParams.CurrentWorkspaceModel.NodeAdded -= CurrentWorkspaceModel_NodeAdded;
        readyParams.CurrentWorkspaceModel.NodeRemoved -= CurrentWorkspaceModel_NodeRemoved;
        readyParams.CurrentWorkspaceModel.ConnectorAdded -= CurrentWorkspaceModel_ConnectorAdded;
        readyParams.CurrentWorkspaceModel.ConnectorDeleted -= CurrentWorkspaceModel_ConnectorDeleted;
    }

    private void Actions_CollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
    {
        RaisePropertyChanged("Actions");
    }

    private void CurrentWorkspaceModel_ConnectorDeleted(Dynamo.Graph.Connectors.ConnectorModel obj)
    {
        Actions.Add($"Connector between port {obj.Start.Name} and {obj.End.Name} deleted");
    }

    private void CurrentWorkspaceModel_ConnectorAdded(Dynamo.Graph.Connectors.ConnectorModel obj)
    {
        Actions.Add($"Connector between port {obj.Start.Name} and {obj.End.Name} added");
    }

    private void CurrentWorkspaceModel_NodeRemoved(Dynamo.Graph.Nodes.NodeModel obj)
    {
        Actions.Add($"Node {obj.Name} deleted");
    }

    private void CurrentWorkspaceModel_NodeAdded(Dynamo.Graph.Nodes.NodeModel obj)
    {
        Actions.Add($"Node {obj.Name} created");
    }

    public void Dispose()
    {
      UnregisterEvents();
    }

  }
}
```

Each time a node or connector is added or removed we log that event by adding a string to our `Actions` collection, in this case an `ObservableCollection` so that we can bind it to the `ListView` in the `NodeTracker` window.

### The Model
Finally let's edit `ViewExtensionExample.cs` to start the tracking and to open the window when the user clicks on a menu item:

```C#
using Dynamo.Wpf.Extensions;
using System;
using System.Windows;
using System.Windows.Controls;

namespace HelloDynamo
{
  /// <summary>
  /// Dynamo View Extension that can control both the Dynamo application and its UI (menus, view, canvas, nodes).
  /// </summary>
  public class ViewExtensionExample : IViewExtension
  {
    public string UniqueId => "5E85F38F-0A19-4F24-9E18-96845764780C";
    public string Name => "Hello Dynamo View Extension";

    private MenuItem extensionMenu;
    private ViewLoadedParams viewLoadedParams;
    
    private NodeTracker _nodeTracker = null;

    public void Startup(ViewStartupParams vsp) { }

    public void Loaded(ViewLoadedParams vlp)
    {
      viewLoadedParams = vlp;
	  //instanciating the window and setting the datacontext to bind it to the viewmodel
      var viewModel = new NodeTrackerViewModel(viewLoadedParams);
      _nodeTracker = new NodeTracker
      {
        Owner = viewLoadedParams.DynamoWindow,
        DataContext = viewModel
      };

      MakeMenuItems();
    }

    public void MakeMenuItems()
    {
      extensionMenu = new MenuItem { Header = "AU Workshop" };

      var sayHelloMenuItem = new MenuItem { Header = "Say Hello" };
      sayHelloMenuItem.Click += (sender, args) =>
      {
         MessageBox.Show("Hello " + Environment.UserName);
      };
      //new menu item for our node tracker
      var nodeTrackerMenuItem = new MenuItem { Header = "Node Tracker" };
      nodeTrackerMenuItem.Click += (sender, args) =>
      {
        _nodeTracker.Show();
      };

      extensionMenu.Items.Add(sayHelloMenuItem);
      extensionMenu.Items.Add(nodeTrackerMenuItem);
      viewLoadedParams.dynamoMenu.Items.Add(extensionMenu);
    }

    public void Shutdown() { }

    public void Dispose() { }
  }
}
```
