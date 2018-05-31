using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Breakpoints will stop the execution of their child if their condition is not met.
/// </summary>
public abstract class BreakpointNode : DecoratorNode
{
    protected BreakpointNode(Node child) : base(child)
    {
    }

    /// <summary>
    /// Checks a condition to decide whether to break or not.
    /// If the condition is met, return true.
    /// </summary>
    /// <returns></returns>
    protected abstract bool CheckCondition(Context context);

    public override NodeStatus Tick(Context context)
    {
        return !CheckCondition(context) ? NodeStatus.Fail : Child.Tick(context);
    }

}
