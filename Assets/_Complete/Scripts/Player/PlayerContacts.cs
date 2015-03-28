using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityStandardAssets.Characters.FirstPerson;

namespace Player {
	public class PlayerContacts : MonoBehaviour {

		[SerializeField] Text message;
		[SerializeField] FirstPersonController fpsCtrl;

		bool startFadeOut = false;
		float t = 0;

		void FixedUpdate () {
			if(startFadeOut)
				message.color = Color.Lerp (Color.clear, Color.white, t);
			else
				message.color = Color.Lerp (Color.white, Color.clear, t);

			if (t < 1) {
				t += Time.deltaTime;
			}
		}

		void OnTriggerEnter (Collider target) {
			if (target.tag == "Puzzle") {
				bool isDone = target.GetComponent<Puzzle>().IsDone;
				bool isEvent = target.GetComponent<Puzzle>().IsEvent;
				if(!isDone) {
					message.text = target.GetComponent<Puzzle>().QuestMsg;
					float duration = target.GetComponent<Puzzle>().Duration;
					t = 0; startFadeOut = true;
					StartCoroutine(AutoFadeIn(duration));
					if(isEvent)StartCoroutine(AutoDestruct(target.gameObject, duration));
				}
			}
		}

		IEnumerator AutoFadeIn (float duration) {
			fpsCtrl.enabled = false;
			yield return new WaitForSeconds (duration);
			t = 0; startFadeOut = false;
			fpsCtrl.enabled = true;
		}

		IEnumerator AutoDestruct (GameObject obj, float duration) {
			yield return new WaitForSeconds (duration);
			Destroy (obj);
		}

	//	void OnTriggerExit (Collider target) {
	//		if (target.tag == "Puzzle") {
	//			message.text = target.GetComponent<Puzzle>().QuestMsg;
	//			t = 0; startFadeOut = false;
	//		}
	//	}
	}
}