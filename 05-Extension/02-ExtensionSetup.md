# 5.2 - Extension Setup  <!-- omit in toc --> 

After seen the "physical" requirements an Extension must follow so Dynamo can find them, we now will see the coding requirements so that it can be loaded. This is, implement the necessary [interfaces](https://docs.microsoft.com/en-us/dotnet/csharp/programming-guide/interfaces/) so Dynamo can call the appropriate methods.

- [Visual Studio Setup](#visual-studio-setup)
  - [Dynamo References](#dynamo-references)
  - [AfterBuild Targets](#afterbuild-targets)
- [IExtension and IViewExtension](#iextension-and-iviewextension)
- [Hello World!](#hello-world)
- [Adding Menus](#adding-menus)

## Visual Studio Setup

Before being able to write your own Extensions, Visual Studio should be configured to ensure you have the correct libraries installed and minimize the repetitive work when debugging and testing.

We are going to follow the same steps as in the [ZeroTouch chapter](../03-ZeroTouch/01-Setup.md), just with minimal changes.

### Dynamo References

As on ZeroTouch development, all Dynamo references are loaded and managed from **Nuget**. For Extensions, we just need to install the following references:
- DynamoVisualProgramming.Core
- DynamoVisualProgramming.WpfUILibrary

![Nuget](assets/02-NugetReferences.png)

These two install will install all the other required references as dependencies. Again, on this step is **very important** to set all Dynamo reference to `Copy Local = False`, to avoid duplication on libraries and possible exceptions during Dynamo execution.

![CopyLocal](assets/02-CopyLocal.png)

### AfterBuild Targets
Although there are other ways to automatically copy the necessary files to the appropriate package folder, we are going to use the `AfterBuild` target on the `.csproj` file. As a reminder of the multiple forms this configuration can have, below is a different snippet from the one on [ZeroTouch chapter](../03-ZeroTouch/01-Setup.md#csproject-afterbuild-targets).

```xml
[...]
<PropertyGroup>
    <DynamoVersion>2.0</DynamoVersion>
    <PackageName>Dynamo_ViewExtension1</PackageName>
    <PackageFolder>$(ProjectDir)dist\$(PackageName)\</PackageFolder>
    <BinFolder>$(PackageFolder)bin\</BinFolder>
    <ExtraFolder>$(PackageFolder)extra\</ExtraFolder>
    <DyfFolder>$(PackageFolder)dyf\</DyfFolder>
  </PropertyGroup>
  <Target Name="AfterBuild">
    <ItemGroup>
      <Dlls Include="$(OutDir)*.dll" />
      <Pdbs Include="$(OutDir)*.pdb" />
      <Xmls Include="$(OutDir)*.xml" />
      <Xmls Include="$(ProjectDir)manifests\*.xml" />
      <PackageJson Include="$(ProjectDir)manifests\pkg.json" />
    </ItemGroup>
    <Copy SourceFiles="@(Dlls)" DestinationFolder="$(BinFolder)" />
    <Copy SourceFiles="@(Pdbs)" DestinationFolder="$(BinFolder)" />
    <Copy SourceFiles="@(Xmls)" DestinationFolder="$(BinFolder)" />
    <Copy SourceFiles="@(PackageJson)" DestinationFolder="$(PackageFolder)" />
    <MakeDir Directories="$(ExtraFolder)" Condition="!Exists($(ExtraFolder))">
    </MakeDir>
    <MakeDir Directories="$(DyfFolder)" Condition="!Exists($(DyfFolder))">
    </MakeDir>
    <CallTarget Condition="'$(Configuration)' == 'Debug'" Targets="PackageDeploy" />
  </Target>
  <Target Name="PackageDeploy">
    <ItemGroup>
      <SourcePackage Include="$(PackageFolder)**\*" />
    </ItemGroup>
    <PropertyGroup>
      <DynamoCore>$(AppData)\Dynamo\Dynamo Core\$(DynamoVersion)\packages</DynamoCore>
      <DynamoRevit>$(AppData)\Dynamo\Dynamo Revit\$(DynamoVersion)\packages</DynamoRevit>
    </PropertyGroup>
    <!--Copying to Package Folder-->
    <Message Importance="high" Text="Dynamo Core Package Folder = $(DynamoCore)" />
    <Message Importance="high" Text="Dynamo Revit Package Folder = $(DynamoRevit)" />
    <Copy SourceFiles="@(SourcePackage)" Condition="Exists($(DynamoCore))" DestinationFolder="$(DynamoCore)\$(PackageName)\%(RecursiveDir)" />
    <Copy SourceFiles="@(SourcePackage)" Condition="Exists($(DynamoRevit))" DestinationFolder="$(DynamoRevit)\$(PackageName)\%(RecursiveDir)" />
  </Target>
[...]
```

## IExtension and IViewExtension

An `Interface` in C# is an element use as mechanism to guide and ensure that one or more classes complies with a set of common rules They are use to "force" a class to have certain methods and properties so that any other part of a program knows that what to expect as a minimum.

Dynamo uses the `IExtension` and `IViewExtension` interfaces to drive the minimum structure of a class so it can be loaded as an extension. The following snippets show the minimum required implementation for Extensions and ViewExtensions.

```csharp
namespace Dynamo.Extensions
{
    public interface IExtension : IDisposable
    {
        string UniqueId { get; }
        string Name { get; }

        void Ready(ReadyParams sp);
        void Shutdown();
        void Startup(StartupParams sp);
    }
}
```
```csharp
namespace Dynamo.Wpf.Extensions
{
    public interface IViewExtension : IDisposable
    {
        string UniqueId { get; }
        string Name { get; }

        void Loaded(ViewLoadedParams p);
        void Shutdown();
        void Startup(ViewStartupParams p);
    }
}
```

As you can see by using interfaces, Dynamo ensures that in order to write any type of extension you are force to implement the [extension's lifecycle](./01-ExtensionAnatomy#extensions-lifecycle) methods it expects to properly instantiate all extensions.

## Hello World!

Now that we are up and running, let's create some `Hello World` extensions that will also serve to showcase the Extension's Lifecycle.

```csharp
using System.Windows;
using Dynamo.Extensions;

namespace HelloDynamo
{
  public class ExtensionExample : IExtension
  {
    public string UniqueId => "3B234622-43B7-4EA8-86DA-54FB390BE29E";

    public string Name => "Hello Extension World";

    public void Dispose() { }

    public void Ready(ReadyParams rp)
    {
      MessageBox.Show("Extension is ready!");
    }

    public void Shutdown()
    { 
        MessageBox.Show("Extension is shutting down!");
    }

    public void Startup(StartupParams sp) { }
  }
}
```

```csharp
using System.Windows;
using Dynamo.Wpf.Extensions;

namespace HelloDynamo
{
  public class ViewExtensionExample : IViewExtension
  {
    public string UniqueId => "5E85F38F-0A19-4F24-9E18-96845764780C";

    public string Name => "Hello ViewExtension World";

    public void Loaded(ViewLoadedParams p)
    {
      MessageBox.Show("ViewExtension has loaded!");
    }

    public void Dispose() { }

    public void Shutdown()
    { 
      MessageBox.Show("ViewExtension is shutting down! Bye " + Environment.UserName);
    }

    public void Startup(ViewStartupParams p) { }
  }
}
```

## Adding Menus

Among the APIs that Dynamo exposes through the `ViewLoadedParams` argument, is the ability to add custom menu tabs to Dynamo's interface.
Using the previous ViewExtension snippet:

Let's add a `private` property that will hold the `ViewLoadedParams` so it can be access by all the class' methods, and a `MenuItem` property to hold a reference of our own menu tab.

```csharp
[...]
private readonly ViewLoadedParams loadedParams { get; };
private MenuItem extensionMenu;

public void Loaded(ViewLoadedParams p)
{
    this.loadedParams = p;
    [...]
}
[...]
```

Now, we can make another method within that will handle the creation of our own Menu Tab

```csharp
[...]

public void MakeMenuItems()
{
    // Creating our custom Menu Tab
    extensionMenu = new MenuItem { Header = "Extensions Workshop" };

    // Creating a sub-menu
    var sayHelloMenuItem = new MenuItem { Header = "Say Hello" };

    // Registering a click event action to the sub-menu
    sayHelloMenuItem.Click += (sender, args) =>
    {
        MessageBox.Show("Hello " + Environment.UserName);
    };

    // Adding sub-menu to our custom menu tab
    extensionMenu.Items.Add(sayHelloMenuItem);

    // Adding menu tab to Dynamo's interface
    loadedParams.dynamoMenu.Items.Add(extensionMenu);
}

[...]
```

Finally, we need to call the `MakeMenuItems` once the ViewExtension is ready:

```csharp
[...]
public void Loaded(ViewLoadedParams p)
{
    [...]
    
    this.MakeMenuItems();
}
[...]
```

