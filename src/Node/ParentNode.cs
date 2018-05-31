using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// A node with a function which allows it to define it's own child.
/// Good for use as a starting node in a behaviourtree.
/// </summary>
public abstract class ParentNode : Node
{
    protected Node Child;
    protected override void Init()
    {
        Child = DefineBehaviour();
    }

    protected abstract Node DefineBehaviour();

    public override NodeStatus Tick(Context context)
    {
        return Child.Tick(context);
    }

}
