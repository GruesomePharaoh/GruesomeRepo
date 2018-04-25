using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

/*	This script controls enemy movement AI. It does not handle combat. 
	Created by Brandocks.
*/

public class EnemyController : MonoBehaviour {
	
	//Enemy viewing distance
	public float lookRadius = 10f;

	//Reference to target player
	Transform target;

	//Reference to NavMeshAgent (enemy self)
	NavMeshAgent agent;

	//Enemy look rotation speed modifier
	public float lookRotationSpeed = 5f;

	
	void Start () {
		//Set target to player. See PlayerManager.cs
		target = PlayerManager.instance.player.transform;
		//Set agent to the NavMeshAgent
		agent = GetComponent<NavMeshAgent>();
	}
	
	
	void Update () {
		//Get distance from enemy to player
		float distance = Vector3.Distance(target.position, transform.position);
		//Check if the distance is equal to look radius
		
		if (distance <= lookRadius) {
			//Chase the player
			agent.SetDestination(target.position);

			//If the enemy agent is close enough to the player
			if (distance <= agent.stoppingDistance) {
				//Attack the player
				//Face the player
				FaceTarget();
				

			}
		}
		
	}
	
	void FaceTarget() {
		//Get a direction to the target
		Vector3 direction = (target.position - transform.position).normalized;
		//Get a rotation for pointing at the target
		Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));
		//Rotate toward that target. Quaternion.Slerp applied for smoothing.
		transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * lookRotationSpeed);
	}

	//Draw a red wire sphere around the enemy to define its look radius
	void OnDrawGizmosSelected() {
		Gizmos.color = Color.red;
		Gizmos.DrawWireSphere(transform.position, lookRadius);
	}
}
