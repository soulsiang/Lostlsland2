using UnityEngine;
using System.Collections;

public class PlayerKillEnemy : MonoBehaviour {

	[SerializeField] AudioClip[] audioClips;
	public float rayLength = 2f;

	void FixedUpdate () {
		Debug.DrawRay(transform.parent.position, transform.parent.forward * rayLength, Color.red);
	}

	public void KillEnemy () {
		Ray ray = new Ray (transform.parent.position, transform.parent.forward);
		RaycastHit hit;

		if (Physics.Raycast (ray, out hit, rayLength)) {
			if (hit.transform.tag == "Enemy") {
				hit.transform.SendMessage("UnderAttack");
				KnifeSFX (1);
			}
		}
		else {
			KnifeSFX (0);
		}
	}

	void KnifeSFX (int n) {
		GetComponent<AudioSource>().clip = audioClips[n];
		GetComponent<AudioSource>().Play ();
	}
}
