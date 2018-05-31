using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// A node which runs all children at the same time. The node decides it's state when the node success rate is either 
/// above (sucess) or below (fail) the supplied success rate.
/// </summary>
public class ParallelNode : CompositeNode
{
    private readonly float _requiredSuccesses;

    /// <summary>
    /// Build a new ParallelNode.
    /// </summary>
    /// <param name="requiredSuccessRate">The required success rate as a percent (0-1f)</param>
    /// <param name="childNodes">The nodes to run in sequence.</param>
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
