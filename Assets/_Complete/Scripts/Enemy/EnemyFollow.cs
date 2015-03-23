using UnityEngine;
using System.Collections;

public class EnemyFollow : MonoBehaviour {

	[SerializeField]
	NavMeshAgent navMeshAgent;

	Transform target;
	void Start () {
		target = GameObject.Find ("Player").transform;
	}

	void FixedUpdate () {
		if (PlayerStatus.hp <= 0f) {
			navMeshAgent.enabled = false;
			GetComponent<Rigidbody>().velocity = Vector3.zero;
		}
		else
			navMeshAgent.SetDestination(target.position);
	}
}
