using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BehaviourTree : MonoBehaviour
{
    protected Context Context;

    /// <summary>
    /// The starting node to ping.
    /// Usually, a Repeaternode.
    /// </summary>
    private Node _parentNode;

    private void Awake()
    {       
        OnAwake();
    }

    private void Start()
    {
        Context = new Context(gameObject);
        _parentNode = DefineBehaviour();
    }

    protected virtual void OnAwake()
    {
    }

    /// <summary>
    /// Define the behavior in this method and return the parent node.
    /// </summary>
    /// <returns></returns>
    protected abstract Node DefineBehaviour();

    private void Update()
    {
        _parentNode.Tick(Context);
    }
}
