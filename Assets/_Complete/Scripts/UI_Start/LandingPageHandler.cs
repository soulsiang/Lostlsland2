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
		playerCamera.GetComponent<Camera> ().enabled = true;
		playerCamera.GetComponent<AudioListener> ().enabled = true;

		string spawnPointId = PlayerPrefs.GetString ("SpawnPoint");
		if (spawnPointId == "") {
			boatAnim.SetTrigger ("landing");
			Invoke ("SpawnPlayer", 5f);
		} else {
			player.position = GameObject.Find (spawnPointId).transform.position;
			player.rotation = GameObject.Find (spawnPointId).transform.rotation;
			Invoke ("SpawnPlayer", .01f);
		}
	}

	void SpawnPlayer () {
		playerCamera.GetComponent<Camera> ().enabled = false;
		playerCamera.GetComponent<AudioListener> ().enabled = false;
		player.gameObject.SetActive (true);
		player.parent = GameObject.Find ("PlayerCanvas").transform.parent;
		RenderSettings.fogDensity = 0.01f;
		Destroy (GameObject.Find ("StartCamera"));
		Destroy (GameObject.Find ("StartCanvas"));
		Destroy (GameObject.Find ("PreviousCamera"));
		Destroy (GameObject.Find ("PreviousCanvas"));
	}
}
