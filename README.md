# Dynamo Development - London Hackathon 2019

There are multiple ways to improve Dynamo creating your custom functionality, with varying levels of difficulty. Learn the basic of custom development and more advance improvement using c#.

## Learning objectives

* Learn about the different types of custom Dynamo nodes.
* Lear how to set up the Visual Studio environment for development and debugging with Dynamo
* Learn how to develop, test and deploy a Zero Touch node
* Learn how to implement a custom UI
* Learn how to develop, test and deploy explicit custom Dynamo nodes
* Lear how to publish your nodes using the package manager

## Table of Contents

### [Development in Dynamo](./00-DevelopmentInDynamo/00-Introduction.md)
Get a high-level understanding of the different approaches to follow in order to customize and create new features on Dynamo.

### [Custom Nested Nodes](./01-CustomNodes/00-Introduction.md)
Section to briefly introduce and/or refresh what **Custom Nested Nodes** are and their benefits/disadvantages.

### [Python Script](./02-PythonScript/00-Introduction.md)
Python is one of the best first options to use *text-base* programming within the Dynamo environment.

### [ZeroTouch Nodes](./03-ZeroTouch/00-Introduction.md)
Learn to develop custom nodes in Dynamo using ZeroTouch.

### [Explicit Nodes](./04-ExplicitNodes/00-Introduction.md)
Learn to develop nodes with custom UI in Dynamo using Explicit nodes.

### [Extensions](./05-Extension/00-Introduction.md)
Power-up your development by extending Dynamo's capabilities by adding your custom logic and UI on top of Dynamo.

### Tools we’ll use

* [Visual Studio Community 2017](https://www.visualstudio.com/downloads/)
* [Dynamo 2.0.1](http://dyn-builds-data.s3-us-west-2.amazonaws.com/DynamoInstall2.0.1.exe)

##  Additional Resources

### Visual Studio Templates

One of the most daunting process if you are not familiar with Visual Studio or C#, is how to setup your environment to seamlessly develop for Dynamo. The [ZeroTouch Nodes > Setup](./03-ZeroTouch/01-Setup.md) chapter goes in detail on how to configure Visual Studio an it is a highly recommended reading.

Although is important to understand how and why Dynamo requires a particular setup for Visual Studio, it would be nuts to do it every time you want ot create a new project or even just a quick test. That's where the [Dynamo Development Starter Kit](https://github.com/alvpickmans/Dynamo-Dev-Starter-Kit) can come in handy. This project is a Visual Studio Extension that adds some Dynamo Project Templates to your environment, so setting a new Dynamo project is just a matter of a couple of clicks to have it up an running.

Go to the [project's repository](https://github.com/alvpickmans/Dynamo-Dev-Starter-Kit) to learn more about it, or download the [latest release](https://github.com/alvpickmans/Dynamo-Dev-Starter-Kit/releases/latest) to install it.

### C Sharp
* C# Interfaces: https://www.tutorialspoint.com/csharp/csharp_interfaces.htm
* C# Classes : https://www.tutorialspoint.com/csharp/csharp_classes.htm
* C# Namespaces: https://www.tutorialspoint.com/csharp/csharp_namespaces.htm

### WPF
* WPF Tutorial: https://www.tutorialspoint.com//wpf/index.htm

### Dynamo & Revit API
* [Revit API online documentation](http://www.revitapidocs.com/)
* Dynamo Primer: [http://dynamoprimer.com/en/09_Custom-Nodes/9-1_Introduction.html](http://dynamoprimer.com/en/09_Custom-Nodes/9-1_Introduction.html)
* How to Create Your Own Nodes: [https://github.com/DynamoDS/Dynamo/wiki/How-To-Create-Your-Own-Nodes](https://github.com/DynamoDS/Dynamo/wiki/How-To-Create-Your-Own-Nodes)
* Zero Touch Plugin Development: [https://github.com/DynamoDS/Dynamo/wiki/Zero-Touch-Plugin-Development](https://github.com/DynamoDS/Dynamo/wiki/Zero-Touch-Plugin-Development)
* Adding Icons for a Zero Touch Assembly: https://github.com/DynamoDS/Dynamo/wiki/Add-Icons-for-a-Zero-Touch-Assembly


## Acknowledgment

Big part of this material is based and reused from the [AEC Hackathon Dynamo Workshop](https://github.com/radumg/AEC-hackathon-Dynamo-Workshop), which in turn is an extended version from the original [Dynamo User Group Computational Design Workshop](https://github.com/teocomi/dug-dynamo-unchained).

I also recaps some of the contents taught during the [Dynamo Developer Workshop](https://github.com/DynamoDS/DeveloperWorkshop) on AU Las Vegas 2019.
