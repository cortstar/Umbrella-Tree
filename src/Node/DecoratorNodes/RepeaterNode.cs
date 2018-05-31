using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Repeats the child node on failure.
/// Use sparingly as this can lead to undesirable behaviour loops.
/// Should be the parent node of every behaviourTree.
/// </summary>
public class RepeaterNode : DecoratorNode {

    public RepeaterNode(Node child) : base(child)
    {
    }

    public override NodeStatus Tick(Context context)
    {
        Child.Tick(context);
        return NodeStatus.Running;
    }
}
