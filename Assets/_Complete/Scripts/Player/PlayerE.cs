using UnityEngine;
using UnityEngine.UI;
using System.Collections;

namespace Player {
	public class PlayerE : MonoBehaviour {

		Message message;
		PlayerBackpack backpack;
		public float rayLength = 3f;

		void Start () {
			GameObject.Find ("PlayerCanvas").GetComponent<Canvas> ().enabled = true;
			GameObject.Find ("PlayerBackpack").SendMessage ("Bind");

			backpack = GameObject.Find ("PlayerBackpack").GetComponent<PlayerBackpack> ();
			message = GameObject.Find ("Message").GetComponent<Message> ();
			Cursor.visible = false;
		}

		void Update () {
//			Debug.DrawRay(transform.Find ("Camera").position, transform.Find ("Camera").forward * rayLength, Color.red);

			if (Input.GetKeyDown (KeyCode.E)) {
				Transform target = ShootIt ("Item");
				// pick up item
				if(target != null && backpack.GetItem(target.transform.name)) {
						Destroy (target.transform.gameObject);
				}

				// solve puzzle
				target = ShootIt ("Puzzle");
				if(target != null) {
					if (target.tag == "Puzzle") {
						Puzzle puz = target.GetComponent<Puzzle>();
						bool isDone = puz.IsDone;
						bool isEvent = puz.IsEvent;
						if(!isDone) {
							message.ShowMessageForSeconds(puz.QuestMsg, puz.Duration);
						}
					}
				}
			}
		}

		public Transform ShootIt (string tag) {
			RaycastHit[] hits = Physics.RaycastAll (transform.Find ("Camera").position, transform.Find ("Camera").forward, rayLength);
			
			foreach(RaycastHit hit in hits) {
				if (hit.transform.tag == tag) {
					return hit.transform;
				}
			}
			return null;
		}
	}
}