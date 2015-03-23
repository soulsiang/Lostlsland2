using UnityEngine;
using System.Collections;

public class EnemyAttack : MonoBehaviour {

	public float rayLength = 3f;
	bool canAttack = true;

	void FixedUpdate () {
		Ray ray = new Ray (transform.position, transform.forward);
		RaycastHit hit;
		if (Physics.Raycast (ray, out hit, rayLength)) {
			if (hit.transform.tag == "Player" && canAttack) {
				canAttack = false;
				StartCoroutine("AttackCoolDown");
				hit.transform.GetComponentInChildren<Animator>().SetTrigger("underattack");
				PlayerStatus.AddHP(-20);
			}
		}

		Debug.DrawRay(transform.position, transform.forward * rayLength, Color.green);
	}

	IEnumerator AttackCoolDown () {
		yield return new WaitForSeconds (1f);
		canAttack = true;
	}
}
