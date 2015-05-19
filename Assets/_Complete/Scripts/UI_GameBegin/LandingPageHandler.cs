using UnityEngine;
using UnityEngine.Audio;
using System.Collections;

public class LandingPageHandler : MonoBehaviour {

	[SerializeField] Transform player;
	[SerializeField] Transform boatCamera;
	[SerializeField] Animator boatAnim;

	void TurnOnLandingThings () {
		boatCamera.GetComponent<Camera> ().enabled = true;
		boatCamera.GetComponent<AudioListener> ().enabled = true;
		boatAnim.SetTrigger ("landing");
		Invoke ("SpawnPlayer", 5f);
	}

	void SpawnPlayer () {
		boatCamera.GetComponent<Camera> ().enabled = false;
		boatCamera.GetComponent<AudioListener> ().enabled = false;
		GameManager.CheckState (GameManager.State.Startover);
	}
}
