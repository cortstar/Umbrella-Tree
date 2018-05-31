using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//This node runs for one tick and is always a success.
public class EmptyNode : LeafNode
{
    protected override NodeStatus OnTick(Context context)
    {
        return NodeStatus.Success;
    }

    
}
