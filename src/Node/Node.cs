using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Parent class for all nodes.
/// </summary>
public abstract class Node
{
    public enum NodeStatus {Running, Fail, Success}
    
    public abstract NodeStatus Tick(Context context);

    protected virtual void Init() {}

    public Node()
    {
        Init();
    }
}
