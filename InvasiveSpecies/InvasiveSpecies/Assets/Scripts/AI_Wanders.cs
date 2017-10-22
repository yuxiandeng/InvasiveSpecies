﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.AI;
using Type;

public class AI_Wanders : MonoBehaviour {

	Critter myCritter;
    AI_SeekFood hunger;

	Vector3 fromDir;
	Vector3 toDir;

    float speed = 1;

    NavMeshAgent agent;

	// Use this for initialization
	void Start () {
		myCritter = GetComponent<Critter>();
        hunger = GetComponent<AI_SeekFood>();
        //fromDir = Random.onUnitSphere;
        //toDir = Random.onUnitSphere;

        if (GetComponent<NavMeshAgent>())
            agent = GetComponent<NavMeshAgent>();

        InvokeRepeating("SetNewDir", 1, 1.5f);
    }

    void SetNewDir()
    {
        fromDir = Random.onUnitSphere;
        toDir = Random.onUnitSphere;

        if (speed == 0)
            speed = 1;
        else
            speed = 0;

        if(agent)
        {
            NavMeshPath path = new NavMeshPath();
            agent.CalculatePath((toDir - fromDir) + transform.position, path);
            if (myCritter.paths.ContainsKey(PathType.WANDER.ToString()))
                myCritter.paths[PathType.WANDER.ToString()] = path;
            else
                myCritter.paths.Add(PathType.WANDER.ToString(), path);
        }

    }

	//void DoAIBehaviour() {
	//	Vector3 dir = toDir - fromDir;
 //       WeightedDirection wd;

 //       if (hunger.isHungry == false)
 //           wd = new WeightedDirection(dir, 0.01f, speed, WeightedDirection.BlendingType.FALLBACK);
 //       else
 //           wd = new WeightedDirection(dir, 0);

 //       myCritter.desiredDirections.Add( wd );


	//}

}
