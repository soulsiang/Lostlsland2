using UnityEngine;
using System.Collections;
using UnityStandardAssets.Characters.FirstPerson;

public class EnemyFollow : MonoBehaviour {

	[SerializeField] Animator anim;
	[SerializeField] NavMeshAgent navMeshAgent;
	bool runningMan = false;
	bool isAttacking = false;
	int attackType = 0;
	bool isDead = false;
	public bool isDying = false;
	public float distanceToPlayer = 0f;

	Transform target;
	void Start () {
		anim.SetInteger ("idle", Random.Range (0, 4));
		target = GameObject.Find ("Player").transform;
		runningMan = (Random.Range (0, 2)==1)?true:false;
		attackType = Random.Range (0, 2);
	}

	void FixedUpdate () {
		// Debug.Log (Vector3.Distance (transform.position, target.position));

		if (!isDead && isDying) {
			isDead = true;
			anim.SetTrigger("dead");
			anim.SetBool("walk", false);
			anim.SetBool("run", false);
			anim.SetInteger("idle", attackType+1);
			target.GetComponent<FirstPersonController> ().enabled = true;
		}
		else if (!isDead) {
			if (!isAttacking && Vector3.Distance (transform.position, target.position) <= 2.5f) {
				navMeshAgent.speed = 0f;
				if (
					anim.GetCurrentAnimatorStateInfo (0).IsName ("walk") ||
					anim.GetCurrentAnimatorStateInfo (0).IsName ("run")
					) {
					isAttacking = true;
					if (attackType == 0) {
						anim.SetTrigger ("attack");
						StartCoroutine (WaitThenEscape(2f));
					} else if (attackType == 1) {
						anim.SetTrigger ("bite");
						StartCoroutine (WaitThenEscape(4f));
					}
				} else if (anim.GetCurrentAnimatorStateInfo (0).IsName ("crawl")) {
					isAttacking = true;
					anim.SetTrigger ("eat");
					StartCoroutine (WaitThenEscape(3f));
				}
			}
			else if (!isAttacking && anim.GetBool ("walk")) {

				if (anim.GetCurrentAnimatorStateInfo (0).IsName ("walk")) {
					navMeshAgent.speed = 1f;
					distanceToPlayer = 1.8f;
					Tracing ();
				}
				if (anim.GetCurrentAnimatorStateInfo (0).IsName ("run")) {
					navMeshAgent.speed = 2f;
					distanceToPlayer = 1.8f;
					Tracing ();
				}
				if (anim.GetCurrentAnimatorStateInfo (0).IsName ("crawl")) {
					navMeshAgent.speed = 0.5f;
					distanceToPlayer = 1f;
					Tracing ();
				}
			}
			else {
				if (
					anim.GetCurrentAnimatorStateInfo (0).IsName ("death") ||
					anim.GetCurrentAnimatorStateInfo (0).IsName ("death2")
				) {
					navMeshAgent.speed = 0f;
				}
			}
		}
	}

	IEnumerator WaitThenEscape (float secs) {
		navMeshAgent.enabled = false;
		target.GetComponent<FirstPersonController>().enabled = false;
		yield return new WaitForSeconds (secs);
		isAttacking = false;
		navMeshAgent.enabled = true;
		target.GetComponent<FirstPersonController> ().enabled = true;
	}

	void Tracing () {
		if (PlayerStatus.hp <= 0f) {
			anim.SetBool("walk", false);
			navMeshAgent.enabled = false;
		} else {
			navMeshAgent.SetDestination(target.TransformPoint(Vector3.forward * distanceToPlayer));
			transform.LookAt(target);
		}
	}

	void OnTriggerEnter (Collider other) {
		if (other.tag == "Player") {
			anim.SetBool("walk", true);
			if(runningMan) {
				anim.SetBool ("run", true);
			}
		}
	}
}
