using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// SequenceNodes have a "Complete" status when the sequence was successfully executed.
/// </summary>
public class SequenceNode : CompositeNode
{
    public SequenceNode(params Node[] childNodes) : base(childNodes)
    {
    }

    public override NodeStatus Tick(Context context)
    {
        NodeStatus result = Children[ActiveNodeIndex].Tick(context);

        switch (result)
            {
                case NodeStatus.Running:
                    return NodeStatus.Running;
                case NodeStatus.Fail:
                    Reset();
                    return NodeStatus.Fail;
                case NodeStatus.Success:
                    var sequenceComplete = !TryMoveToNextNode();
                    return sequenceComplete ? NodeStatus.Success : NodeStatus.Running;
                default:
                    throw new ArgumentOutOfRangeException();
            }
    }
    

}
