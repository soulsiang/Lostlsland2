using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

namespace Player {
	public class PlayerBackpack : MonoBehaviour {

		[SerializeField] PlayerE playerE;
		[SerializeField] MeshRenderer knife;
		[SerializeField] Light light;
		string[] itemSlot;
		Sprite[] itemIcon;

		void Start () {
			itemSlot = new string[3];
			itemIcon = Resources.LoadAll<Sprite>("Item");
		}

		void Update () {
			if (Input.GetKeyDown (KeyCode.Alpha1)) {
				UseItem (0);
			}
			if (Input.GetKeyDown (KeyCode.Alpha2)) {
				UseItem (1);
			}
			if (Input.GetKeyDown (KeyCode.Alpha3)) {
				UseItem (2);
			}
		}
		
		public bool GetItem (string name) {
			if(itemSlot[0]==null)itemSlot[0] = name;
			else if(itemSlot[1]==null)itemSlot[1] = name;
			else if(itemSlot[2]==null)itemSlot[2] = name;
			else {
				Debug.Log ("Your backpack is full!");
				return false;
			}
			Debug.Log ("Get "+itemSlot[0]);
			RenderItemIcon ();
			return true;
		}

		void RenderItemIcon () {
			for (int i=0;i<itemSlot.Length;i++) {
				string str = itemSlot[i];
				if(str == null) {
					transform.Find ("Slot"+(i+1)).Find ("Image").GetComponent<Image>().sprite = null;
				}
				else {
					foreach (Sprite icon in itemIcon) {
						if(icon.name == str) {
							transform.Find ("Slot"+(i+1)).Find ("Image").GetComponent<Image>().sprite = icon;
						}
					}
				}
			}
		}

		void UseItem (int index) {
			if (itemSlot [index] != null) {
				Debug.Log ("Use " + itemSlot [index]);
				switch(itemSlot [index]) {
					case "Healpack":
						PlayerStatus.AddHP(50);
						itemSlot [index] = null;
						Debug.Log ("You feel better. (hp+50)");
					break;
					case "Knife":
						PlayerActions.ableToUse = true;
						knife.enabled = true;
						itemSlot [index] = null;
						Debug.Log ("You can use knife now.");
					break;
					case "Torch":
						light.intensity = 10;
						itemSlot [index] = null;
						Destroy (GameObject.Find ("Forest"));
						Debug.Log ("Rise and shine.");
					break;
					case "Keycard":
						Transform target = playerE.ShootIt("Puzzle");
						if(target != null) {
							if(target.GetComponent<Puzzle>().Solve(itemSlot [index])) {
								itemSlot [index] = null;
								Destroy(target.gameObject);
								Debug.Log("You solve "+target.name+" puzzle!");
							}
							else Debug.Log ("Can't use "+itemSlot [index]+" here.");
						}
					break;
				}
				RenderItemIcon ();
			}
		}
	}
}