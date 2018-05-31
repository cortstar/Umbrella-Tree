using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// A decorator node has a single child, and affects it's behaviour in some way.
/// </summary>
public abstract class DecoratorNode : Node {
     
	protected Node Child;

    protected DecoratorNode(Node child)
    {
        Child = child;
    }
}
