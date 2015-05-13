using UnityEngine;
using System.Collections;

public class StartPageHandler : MonoBehaviour {

	[SerializeField] Animator maskAnim;
	[SerializeField] Canvas startCanvas;

	void StartButtonClick () {
		maskAnim.SetBool ("show", true);
		Invoke ("TurnOffStartThings", 3f);
	}

	void TurnOffStartThings () {

		GameManager.CheckState (GameManager.State.Previous);

		// turn off start things
		GetComponent<Camera> ().enabled = false;
		GetComponent<AudioListener> ().enabled = false;
		startCanvas.enabled = false;

		// fade out
		maskAnim.SetBool ("show", false);
	}

	void ExitButtonClick () {
		Application.Quit ();
	}
}
