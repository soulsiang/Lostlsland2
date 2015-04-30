using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ContinueHandler : MonoBehaviour {

	[SerializeField] Animator maskAnim;

	void Start () {
		if (PlayerPrefs.GetString ("SpawnPoint") != "") {
			GetComponent<Button>().interactable = true;
			transform.Find ("Text").GetComponent<Text>().color = new Color(.48f, 0f, 0f);
		}
	}

	public void ContinueButtonClick () {
		maskAnim.SetBool ("show", true);
		Invoke ("TurnOnContinueThings", 3f);
	}

	void TurnOnContinueThings () {
		maskAnim.SetBool ("show", false);
		GameObject.Find ("Landing").SendMessage ("TurnOnLandingThings");
	}
}
