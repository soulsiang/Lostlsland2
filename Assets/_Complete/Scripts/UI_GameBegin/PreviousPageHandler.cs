using UnityEngine;
using UnityEngine.Audio;
using System.Collections;

public class PreviousPageHandler : MonoBehaviour {

	[SerializeField] Animator maskAnim;
	[SerializeField] Animator cutSceneAnim;

	bool previousStart = false;

	void FixedUpdate () {
		if (previousStart)
			transform.position = transform.TransformPoint (Vector3.forward * .05f);
	}

	void TurnOnPreviousThings () {
		previousStart = true;

		GetComponent<Camera> ().enabled = true;
		GetComponent<AudioListener> ().enabled = true;
		GetComponent<AudioSource> ().enabled = true;
		cutSceneAnim.SetTrigger ("murmur");
	}

	void TurnOffPreviousThings () {

		GameManager.CheckState (GameManager.State.Landing);

		// turn off preivous things
		GetComponent<Camera> ().enabled = false;
		GetComponent<AudioListener> ().enabled = false;
		GetComponent<AudioSource> ().enabled = false;

		// fade out
		maskAnim.SetBool ("show", false);
	}
}
