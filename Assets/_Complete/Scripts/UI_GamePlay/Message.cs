using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Message : MonoBehaviour {

	Text text;

	void Start () {
		text = GetComponent<Text> ();
		text.text = "";
	}
	
	public void ShowMessageForSeconds (string msg, float duration) {
		text.text = msg;
		StartCoroutine (WaitThenShowText (duration));
	}

	IEnumerator WaitThenShowText (float duration) {
		yield return new WaitForSeconds (duration);
		text.text = "";
	}
}
