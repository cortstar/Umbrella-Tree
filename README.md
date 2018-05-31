## Umbrella Tree


Umbrella Tree is a skeletal, bare-bones implementation of an AI behaviour tree for your next Unity project. Umbrella Tree is designed to use no dependencies on other assets or code (and even limits it's interface with the Unity editor). The design of the tree is based on [this excellent blog post by Chris Simpson](https://www.gamasutra.com/blogs/ChrisSimpson/20140717/221339/Behavior_trees_for_AI_How_they_work.php), except it is written in C# and requires no XML.




## Installation


Download and extract the files in SRC to your Unity project. You're done!



## Usage
 

1. Create a new Component that inherits from BehaviourTree. Also, create LeafNodes encapsulating individual behaviours.
 
2. Define your tree with your nodes.. Start with a ParentNode. For an example, see the RedSphereBehaviour node in /example.
 
3. Add the new Component to the object which you wish to behave.
 
4. You're done! The hard part is writing the LeafNode behaviours.



## Contexts


Each of your nodes will have access to a Context object which is per-object. The Context object extends the functionality of the tree by adding access to semi-global context variables. You can add keyed data to the context with SetContextData and recover keyed data of an expected type by using GetContextData\<T\>. **Avoid using context variables unless it is really necessary. Abuse of context variables will invariably overcomplicate your tree.**



## Contact

Please raise GitHub issues on this project if you feel like Umbrella Tree is missing a feature or has a bug.
