# AEC Hackathon Dynamo Workshop

Learn how to develop Zero Touch Nodes in C#.

## Summary

This workshop will teach you how to set your graph free by developing custom Dynamo nodes using the Zero Touch approach. It will go thorough the different types on nodes and their advantages, then it will teach you how to configure Visual Studio for development and debug. Finally, using simple examples, it will teach you how to build your own nodes.
After this workshop you will be able to add new features, improve workflows and contribute to the Dynamo community.  The workshop will be using Visual Studio and C#, for information on getting started with C# please see the links in the [Additional Resources](#Additional Resources) section.

This workshop will teach you how to set your graph free by developing explicit nodes with a custom UI. This approach is more advanced and complicated than the Zero Touch one, but nodes built this way have the most flexibility and power. You will learn how to implement a custom UI, respond to other nodes and affect the state of the graph. You will also learn how to package your nodes and distribute them using the Dynamo Package Manager. The workshop be using Visual Studio and C#, an intermediate level of programming knowledge is needed, for additional information see the links in the [Additional Resources](#Additional Resources) section.

### Learning objectives

* Learn about the different types of custom Dynamo nodes
* Lear how to set up the Visual Studio environment for development and debug with Dynamo
* Learn how to develop, test and deploy a Zero Touch node
* Learn how to develop, test and deploy explicit custom Dynamo nodes
* Learn how to implement a custom UI
* Lear how to publish your nodes using the package manager

### Tools we’ll use

* [Visual Studio Community 2017](https://www.visualstudio.com/downloads/)

* Autodesk Revit 2018 (or Autodesk Revit 2017 and Dynamo 1.3)

## What are custom nodes?

In Dynamo it is possible to add custom functionalities using special components, these are called custom nodes. They can be really useful for frequently used routines or for adding completely new and advanced features.

### Advantages

* Simplify the graph, keep it clean and intuitive

* Reusability

* Modularity, update all custom nodes of the same type at once

* Better use of conditional statements (if/then) and looping

* Add brand new functionalities

* Integrate with external services/libraries

* Understand better how Dynamo "thinks"

* Contribute to the community

### Disadvantages

* Less intuitive than visual programming

* Hard for novice users/learning curve

* Some custom nodes require compiling DLLs

* With great power comes great responsibility, custom nodes are more prone to bugs, memory abuse or crashes

### Types of custom nodes

There are different types of custom nodes, for all levels and uses:

* *[Dynamo Custom Node](http://dynamoprimer.com/en/09_Custom-Nodes/9-2_Creating.html)*, it’s done by nesting existing nodes into a container, the custom node is saved as a DYF file and can be easily shared

* *[Code Node](http://dynamobim.org/cbns-for-dummies/)*, this one basically consists in having a formula inside a code node, you can’t do complex things but if can be very handy. The code is in Design Script

* *[Python Node](http://dynamoprimer.com/en/09_Custom-Nodes/9-4_Python.html)*, it’s a custom node containing python code, supports modules and packages. It is a very powerful and quick way to add custom functionalities, and you don’t need to compile your code. ([template](https://github.com/DynamoDS/Dynamo/pull/8034))

* *Zero Touch Node*, create or import a custom node written in C#. It is a more complex choice but you will benefit of the .NET framework, a solid IDE, debugging tools and lots of libraries

* *Explicit Custom Node*, basically a native Dynamo node written in C#, it implements the NodeModel interface, can have a custom UI and affect the state of the graph

## ZT nodes
See Part 1

## Explicit nodes
See Part 2

## Publishing nodes to the Package Manager

Publishing a package to the package manager is a very simple process especially given how we have set up our Visual Studio projects. Only publish packages that you own and that you have tested thoroughly!

Publishing can only be done from Dynamo for Revit or Dynamo Studio, not from the Sandbox version.

Click on Packages > Manage Packages...

![1510612119525](assets/1510612119525.png)

In the next screen make sure all the information is correct and that only the required dlls are being included (remember when we had to manually set `Copy Local` to `False` on the references?).

As you click Publish Online it will be on the Package Manager, to upload new version use `Publish Version...` instead.

Also note that packages cannot be deleted, but only deprecated.  

![1510612834682](assets/1510612834682.png)



## Conclusion

The boilerplate poject we have created in part 1, should get you jump-started in developing for Dynamo. Don't be afraid of Visual Studio, it's a friend and it can provide very helpful insights during development and debug. We have also gone through sample code on how to interact with Dynamo and Revit geometry/elements, you should now be able to start developing your own nodes. There are some additional things to be aware of:

* Version updates - releasing updates to an existing node should be done carefully, it could brake existing user graphs and workflows
* Dll conflicts - if other nodes in use by Dynamo depend on external dlls, and your nodes too, there might be conflicts

We have seen the principles behind explicit custom nodes, and this workshop has given you the basis to get started with development. There are some technical challenges but also great benefits if you decide to build and use this type of custom node. WPF is a very powerful and widely useful framework, you'll be able to find lots of resources online and existing UI components to reuse. We have also seen how to publish your nodes online and contribute to the Dynamo community, if is a very straightforward process once you have set up your project correctly.
Happy coding!

##  Additional Resources

* C# Interfaces: https://www.tutorialspoint.com/csharp/csharp_interfaces.htm
* WPF Tutorial: https://www.tutorialspoint.com//wpf/index.htm
* C# Classes : https://www.tutorialspoint.com/csharp/csharp_classes.htm
* C# Namespaces: https://www.tutorialspoint.com/csharp/csharp_namespaces.htm
* Adding Icons for a Zero Touch Assembly: https://github.com/DynamoDS/Dynamo/wiki/Add-Icons-for-a-Zero-Touch-Assembly
* Revit API online documentation: http://www.revitapidocs.com/
* Dynamo Primer: [http://dynamoprimer.com/en/09_Custom-Nodes/9-1_Introduction.html](http://dynamoprimer.com/en/09_Custom-Nodes/9-1_Introduction.html)
* Zero Touch Plugin Development: [https://github.com/DynamoDS/Dynamo/wiki/Zero-Touch-Plugin-Development](https://github.com/DynamoDS/Dynamo/wiki/Zero-Touch-Plugin-Development)
* How to Create Your Own Nodes: [https://github.com/DynamoDS/Dynamo/wiki/How-To-Create-Your-Own-Nodes](https://github.com/DynamoDS/Dynamo/wiki/How-To-Create-Your-Own-Nodes)
