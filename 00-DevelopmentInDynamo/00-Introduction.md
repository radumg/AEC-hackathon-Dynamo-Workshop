## Development in Dynamo

Dynamo is one of the tools on the AEC that has gained attraction in a very short time for multiple reasons, like its open-source nature, easy to use and its ability to enhance Revit functionality.

Apart from the general *out of the box* use, Dynamo allows us to extend and improve existing functionality, or even add our own custom tools. These can be done through different methods, varying in difficulty.  

### Advantages

* Simplify the graph, keep it clean and intuitive
* Reusability
* Better use of conditional statements (if/then) and looping
* Add brand new functionalities
* Integrate with external services/libraries
* Understand better how Dynamo "thinks"
* Contribute to the community

### Disadvantages

* Less intuitive than visual programming
* Hard for novice users/learning curve
* Might require the use of and IDE (Integrated Development Environment).
* With great power comes great responsibility, custom development is more prone to bugs, memory abuse or crashes

### Developing Custom Nodes

There are different types of custom nodes, for all levels and uses:

![Dynamo custom nodes](assets/Node%20types%20image.png "Part 0 - Custom nodes")


- *[Code Node](http://dynamobim.org/cbns-for-dummies/)*, this one basically consists on having a formula inside a code node, you can’t do complex things but if can be very handy. The code is in Design Script.
  
- *[Dynamo Custom Node](http://dynamoprimer.com/en/09_Custom-Nodes/9-2_Creating.html)*, it’s done by nesting existing nodes into a container, the custom node is saved as a DYF file and can be easily shared.
  
- *[Python Node](http://dynamoprimer.com/en/09_Custom-Nodes/9-4_Python.html)*, it’s a custom node containing python code, supports modules and packages. It is a very powerful and quick way to add custom functionalities, and you don’t need to compile your code.

- *[Zero Touch Node](https://github.com/DynamoDS/Dynamo/wiki/Zero-Touch-Plugin-Development)*, create or import a custom node written in C#. It is a more complex choice but you will benefit of the .NET framework, a solid IDE, debugging tools and lots of libraries.

- *[Explicit Custom Node](https://github.com/DynamoDS/Dynamo/wiki/How-To-Create-Your-Own-Nodes#method-3-nodes-with-custom-ui)*, basically a native Dynamo node written in C#, it implements the NodeModel interface, can have a custom UI and affect the state of the graph.

### Other types of development

Around January 2018, the Dynamo team released a new approach of developing in Dynamo, slightly different than creating your own nodes.

**Extensions** and **ViewExtensions** allow the developer to *"tap"* into Dynamo itself and make use of its API to drive custom functionality, respond to events and add your own UI on top od Dynamo. 

For more info, visit the [blog post](https://dynamobim.org/extending-dynamo-a-london-workshop-on-extensions/) or watch the [recording](https://www.youtube.com/watch?v=qLGsRcIOwzc&feature=youtu.be) from the workshop held in London on February 2018.
