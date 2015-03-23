using UnityEngine;
using System.Collections;

public class PlayerKillEnemy : MonoBehaviour {

	public float rayLength = 3f;

	public void KillEnemy () {
		Ray ray = new Ray (transform.parent.position, transform.parent.forward);
		RaycastHit hit;
		
		if (Physics.Raycast (ray, out hit, rayLength)) {
			if (hit.transform.tag == "Enemy") {
				Destroy (hit.transform.gameObject);
			}
		}
	}
}
