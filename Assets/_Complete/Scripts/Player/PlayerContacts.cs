using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PlayerContacts : MonoBehaviour {

	[SerializeField] Text message;

	bool startFadeOut = false;
	float duration = 3f;
	float t = 0;
	void FixedUpdate () {
		if(startFadeOut)
			message.color = Color.Lerp (Color.clear, Color.white, t);
		else
			message.color = Color.Lerp (Color.white, Color.clear, t);

		if (t < 1){
			t += Time.deltaTime;
		}
	}

	void OnTriggerEnter (Collider target) {
		if (target.tag == "Puzzle") {
			message.text = target.GetComponent<Puzzle>().QuestMsg;
			t = 0; startFadeOut = true;
			StartCoroutine("AutoFadeIn");
		}
	}

	IEnumerator AutoFadeIn () {
		yield return new WaitForSeconds (3f);
		t = 0; startFadeOut = false;
	}

//	void OnTriggerExit (Collider target) {
//		if (target.tag == "Puzzle") {
//			message.text = target.GetComponent<Puzzle>().QuestMsg;
//			t = 0; startFadeOut = false;
//		}
//	}
}
