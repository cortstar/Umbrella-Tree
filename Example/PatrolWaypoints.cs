using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatrolWaypoints : LeafNode
{
	private int current_waypoint = 0;
	
	protected override NodeStatus OnTick(Context context)
	{	
		Debug.Log(context);
		Debug.Log(context.agent);
		var wpholder = context.agent.GetComponent<WaypointHolder>();
		//If the agent has no WPholder, or if the wpholder is empty, return failure
		if (wpholder == null || wpholder.waypoints.Length == 0)
		{
			return NodeStatus.Fail;
		}

		//Translate towards waypoint
		context.agent.transform.position =
			Vector3.MoveTowards(context.agent.transform.position,
				wpholder.waypoints[current_waypoint].transform.position, .2f);
		
		//Measure how close the object is to it's destination
		var closeness = 
			(context.agent.transform.position - wpholder.waypoints[current_waypoint].transform.position).magnitude;

		if (closeness > 1f)
		{
			return NodeStatus.Running;
		}
		
		//If we were close enough, move onto the next waypoint.
		current_waypoint += 1;
		if (current_waypoint < wpholder.waypoints.Length)
		{
			return NodeStatus.Running;
		}
		
		//We're done, reset the current wp and return a success
		current_waypoint = 0;
		return NodeStatus.Success;
	}
}
