using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimedNoBehaviour : LeafNode
{
    private Timer _timer;

    /// <summary>
    /// Returns success after a given time.
    /// </summary>
    /// <param name="seconds">How long to wait before returning success.</param>
    public TimedNoBehaviour(float seconds) 
    {
        _timer = new Timer(seconds);
    }
    protected override NodeStatus OnTick(Context context)
    {
        _timer.Update();

        if (!_timer.IsComplete)
        {
            return NodeStatus.Running;
        }
        
        _timer.Reset();
        return NodeStatus.Success;

    }

}
