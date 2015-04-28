using UnityEngine;
using UnityEngine.Audio;
using System.Collections;

public class LandingPageHandler : MonoBehaviour {

	[SerializeField] Transform player;
	[SerializeField] Transform playerCamera;
	[SerializeField] Animator boatAnim;
	[SerializeField] AudioMixerSnapshot beachTheme;
	[SerializeField] AudioSource forest;
	[SerializeField] AudioSource sea;

	void TurnOnLandingThings () {
		forest.Play ();
		sea.Play ();
		beachTheme.TransitionTo (.1f);
		boatAnim.SetTrigger ("landing");
		playerCamera.GetComponent<Camera> ().enabled = true;
		playerCamera.GetComponent<AudioListener> ().enabled = true;
		Invoke ("SpawnPlayer", 5f);
	}

	void SpawnPlayer () {
		playerCamera.GetComponent<Camera> ().enabled = false;
		playerCamera.GetComponent<AudioListener> ().enabled = false;
//		GameObject player = (GameObject)Instantiate (playerPrefab, playerCamera.position, playerCamera.rotation);
//		player.name = "Player";
		player.gameObject.SetActive (true);
		player.parent = GameObject.Find ("PlayerCanvas").transform.parent;
		RenderSettings.fogDensity = 0.02f;
		Destroy (GameObject.Find ("StartCamera"));
		Destroy (GameObject.Find ("StartCanvas"));
		Destroy (GameObject.Find ("PreviousCamera"));
		Destroy (GameObject.Find ("PreviousCanvas"));
	}
}
