using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityStandardAssets.Characters.FirstPerson;

namespace Player {
	public class PlayerContacts : MonoBehaviour {

		void OnTriggerEnter (Collider target) {
			if (target.tag == "Puzzle") {
				bool isDone = target.GetComponent<Puzzle>().IsDone;
				bool isEvent = target.GetComponent<Puzzle>().IsEvent;
				if(!isDone && isEvent) {
					float duration = target.GetComponent<Puzzle>().Duration;
					StartCoroutine(AutoDestruct(target.gameObject, duration));
				}
			}
		}

		IEnumerator AutoDestruct (GameObject obj, float duration) {
			yield return new WaitForSeconds (duration);
			Destroy (obj);
		}
	}
}