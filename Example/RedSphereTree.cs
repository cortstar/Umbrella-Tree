using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RedSphereTree : BehaviourTree {
	
	protected override Node DefineBehaviour()
	{
		return new RedSphereBehaviour();
	}
}
