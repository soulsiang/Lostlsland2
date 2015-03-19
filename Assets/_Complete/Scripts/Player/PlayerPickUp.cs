using UnityEngine;
using System.Collections;

public class PlayerPickUp : MonoBehaviour {

	[SerializeField] Backpack backpack;
	public float rayLength = 3f;

	void Update () {
		Debug.DrawRay(transform.Find ("Camera").position, transform.Find ("Camera").forward * rayLength, Color.red);

		if (Input.GetKeyDown (KeyCode.E)) {
			PickUpItem ();
		}
	}

	void PickUpItem () {

		RaycastHit[] hits = Physics.RaycastAll (transform.Find ("Camera").position, transform.Find ("Camera").forward, rayLength);
		
		foreach(RaycastHit hit in hits) {
			if (hit.transform.tag == "Item") {
				if(backpack.GetItem(hit.transform.name))Destroy (hit.transform.gameObject);
			}
		}
	}
}
