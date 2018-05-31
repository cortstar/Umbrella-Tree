using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Runs all children until a success is reached,
/// </summary>
public class SelectorNode : CompositeNode {

    public override NodeStatus Tick(Context context)
    {
        var status = Children[ActiveNodeIndex].Tick(context);

        switch (status) {
            case NodeStatus.Running:
                return NodeStatus.Running;
            case NodeStatus.Fail:
                var allNodesFailed = !TryMoveToNextNode();
                return allNodesFailed ? NodeStatus.Fail : NodeStatus.Running;            
            case NodeStatus.Success:
                return NodeStatus.Success;
            default:
                throw new ArgumentOutOfRangeException();
        }

    }
}
