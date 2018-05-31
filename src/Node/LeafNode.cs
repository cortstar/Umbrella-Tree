using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

/// <summary>
/// Leaf nodes have no children and are intended to hold behaviours.
/// </summary>
public abstract class LeafNode : Node
{
    public sealed override NodeStatus Tick(Context context)
    {
        NodeStatus n = OnTick(context);          
        return n;
    }

    protected abstract NodeStatus OnTick(Context context);
}
