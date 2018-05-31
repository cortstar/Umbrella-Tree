using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// This node always returns a success. 
/// </summary>
public class SucceederNode : DecoratorNode {

    public SucceederNode(Node child) : base(child)
    {
    }

    public override NodeStatus Tick(Context context)
    {
        Child.Tick(context);
        return NodeStatus.Success;
    }

}
