using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParallelNode : CompositeNode
{
    private readonly float _requiredSuccesses;

    /// <summary>
    /// A node which runs all children in sequence.
    /// </summary>
    /// <param name="requiredSuccessRate">The required ratio of successes:total nodes for this node to succeed, rounded down</param>
    /// <param name="childNodes">The children of this node</param>
    protected ParallelNode(float requiredSuccessRate, params Node[] childNodes) : base(childNodes)
    {
        requiredSuccessRate.ClampTo(new Range(0f, 1f));
        _requiredSuccesses = (int)Math.Floor(Children.Count * requiredSuccessRate);
    }

    public override NodeStatus Tick(Context context)
    {
        var successes = 0;

        foreach (var n in Children)
        {
            var status = n.Tick(context);
            switch (status)
                {
                    case NodeStatus.Running:
                        break;
                    case NodeStatus.Fail:
                        break;
                    case NodeStatus.Success:
                        successes++;
                        break;
                    default:
                        throw new ArgumentOutOfRangeException();
                }
        }

        return successes >= _requiredSuccesses ? NodeStatus.Success : NodeStatus.Running;
    }
}
