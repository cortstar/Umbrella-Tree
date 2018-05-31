using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Node that repeats operation of the child until it fails.
/// </summary>
public class RepeatUntilFailNode : DecoratorNode {

    public RepeatUntilFailNode(Node child) : base(child)
    {
    }

    public override NodeStatus Tick(Context context)
    {
        var status = Child.Tick(context);

        switch (status)
        {
            case NodeStatus.Running:
                return NodeStatus.Running;
            case NodeStatus.Fail:
                return NodeStatus.Fail;
            case NodeStatus.Success:
                return NodeStatus.Running;
            default:
                throw new ArgumentOutOfRangeException();
        }
    }
}
