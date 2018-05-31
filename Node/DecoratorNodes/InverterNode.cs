using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Inverter nodes return the opposite result of their child.
/// </summary>
public class InverterNode : DecoratorNode {

    public InverterNode(Node child) : base(child)
    {
    }

    public override NodeStatus Tick(Context context)
    {
        var status = Child.Tick(context);

        switch (status) {
            case NodeStatus.Running:
                return NodeStatus.Running;
            case NodeStatus.Fail:
                return NodeStatus.Success;
            case NodeStatus.Success:
                return NodeStatus.Fail;
            default:
                throw new ArgumentOutOfRangeException();
        }

    }
}
