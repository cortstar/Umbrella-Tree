using System.Collections.Generic;


/// <summary>
/// Composite nodes have one or more children.
/// </summary>
public abstract class CompositeNode : Node
{
    protected List<Node> Children = new List<Node>();

    protected int ActiveNodeIndex;

    protected CompositeNode(params Node[] childNodes)    
    {
        if (childNodes.Length <= 0)
        {
            Children.Add(new EmptyNode());
        }

        foreach (var n in childNodes)
        {
            Children.Add(n);
        }
    }

    protected void Reset()
    {
        ActiveNodeIndex = 0;
    }

    protected bool TryMoveToNextNode()
    {
        if (ActiveNodeIndex < Children.Count - 1 )
        {
            ActiveNodeIndex++;
            return true;
        }
        else
        {
            ActiveNodeIndex = 0;
            return false;
        }
    }
}
