![ZT Icon](assets/00-ZT-icon.png)

# ZeroTouch Nodes Development for Dynamo

This material will go through on how to start creating your own Dynamo ZeroTouch nodes using Visual Studio 2017.

A Zero Touch Node (ZTN), is a custom node written in C#. A ZTN can be obtained by simply [importing a DLL inside of Dynamo](http://dynamoprimer.com/en/10_Packages/10-5_Zero-Touch.html). It's called zero-touch because that's all you need to do : Dynamo is smart and will automatically map all methods & properties from public classes to nodes :
- `public static` **methods** that return the class type will appear as constructor nodes in Dynamo, identified with a green `+` icon
- `public` **methods** will appear as action nodes, identified with a red `⚡` icon
- `public` **properties** will appear as query nodes, identified with a blue `?` icon

By writing your own ZTN you will benefit from
- the .NET framework
- a solid IDE
- debugging tools
- and lots of libraries
- performance : C# nodes are more performant than Python ones most of the time. 

This type of node (ZTN) needs to be compiled into a `DLL` every time you want to make a change, which means your code is safer if you are going to distribute it, but it does make graphs dependant on this external `DLL` file. This means that for small tasks, Python nodes might still be a better solution as the code is embedded in the Dynamo `.dyn` file itself.

---

Original source: [AEC Hackathon 2018 - Dynamo Workshop Part 1](https://github.com/radumg/AEC-hackathon-Dynamo-Workshop/tree/master/Part%201%20-%20ZeroTouch)

