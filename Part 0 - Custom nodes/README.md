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

![Dynamo custom nodes](assets/Node%20types%20image.png "Part 0 - Custom nodes")


* *[Dynamo Custom Node](http://dynamoprimer.com/en/09_Custom-Nodes/9-2_Creating.html)*, it’s done by nesting existing nodes into a container, the custom node is saved as a DYF file and can be easily shared

* *[Code Node](http://dynamobim.org/cbns-for-dummies/)*, this one basically consists in having a formula inside a code node, you can’t do complex things but if can be very handy. The code is in Design Script

* *[Python Node](http://dynamoprimer.com/en/09_Custom-Nodes/9-4_Python.html)*, it’s a custom node containing python code, supports modules and packages. It is a very powerful and quick way to add custom functionalities, and you don’t need to compile your code. ([template](https://github.com/DynamoDS/Dynamo/pull/8034))

* *[Zero Touch Node](https://github.com/DynamoDS/Dynamo/wiki/Zero-Touch-Plugin-Development)*, create or import a custom node written in C#. It is a more complex choice but you will benefit of the .NET framework, a solid IDE, debugging tools and lots of libraries. Covered in [Part 1 of the workshop](https://github.com/radumg/AEC-hackathon-Dynamo-Workshop/tree/master/Part%201%20-%20ZeroTouch).

* *[Explicit Custom Node](https://github.com/DynamoDS/Dynamo/wiki/How-To-Create-Your-Own-Nodes#method-3-nodes-with-custom-ui)*, basically a native Dynamo node written in C#, it implements the NodeModel interface, can have a custom UI and affect the state of the graph. Covered in [Part 2 of the workshop](https://github.com/radumg/AEC-hackathon-Dynamo-Workshop/tree/master/Part%202%20-%20Explicit%20nodes).

## Next
Let's dive into custom node creation by learning to build ZeroTouch nodes !
Head over to [Part 1](https://github.com/radumg/AEC-hackathon-Dynamo-Workshop/tree/master/Part%201%20-%20ZeroTouch) of the workshop.
