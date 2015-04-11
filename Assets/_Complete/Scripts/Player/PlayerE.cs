using UnityEngine;
using System.Collections;

namespace Player {
	public class PlayerE : MonoBehaviour {

		PlayerBackpack backpack;
		public float rayLength = 3f;

		void Start () {
			backpack = GameObject.Find ("PlayerBackpack").GetComponent<PlayerBackpack> ();
			Cursor.visible = false;
		}

		void Update () {
//			Debug.DrawRay(transform.Find ("Camera").position, transform.Find ("Camera").forward * rayLength, Color.red);

			if (Input.GetKeyDown (KeyCode.E)) {
				Transform target = ShootIt ("Item");
				if(target != null) { // pick up item
					if(backpack.GetItem(target.transform.name))Destroy (target.transform.gameObject);
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