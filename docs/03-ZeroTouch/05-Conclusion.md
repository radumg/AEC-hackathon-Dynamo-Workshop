## Conclusion

The boilerplate project we have created in this tutorial should get you jump-started in developing for Dynamo.

We have also gone through sample code on how to interact with Dynamo and Revit geometry/elements, so you should now be able to start developing your own nodes. 

Some additional things to be aware of:

* Version updates - releasing updates to an existing node should be done carefully, it could brake existing user graphs and workflows. Most developers choose to use the [SemVer](https://semver.org/) method to number versions, which also helps aleviate & communicate the impacts of changes to users. 

* Dll conflicts - if other nodes in use by Dynamo depend on external dlls, and your nodes too, there might be conflicts. Dynamo will report any conflicts in its `Notifications` panel, so check it out if something is misbehaving!