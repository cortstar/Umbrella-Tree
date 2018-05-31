using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RedSphereBehaviour : ParentNode {
	
	protected override Node DefineBehaviour()
	{
		return new RepeaterNode(
			new SequenceNode(new TimedNoBehaviour(5f), new PatrolWaypoints())		
			);
	}
}
