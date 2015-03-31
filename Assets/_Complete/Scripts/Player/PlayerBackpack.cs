using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

namespace Player {
	public class PlayerBackpack : MonoBehaviour {

		[SerializeField] PlayerE playerE;
		[SerializeField] Transform knifeModel;
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

		GameObject obj;

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
						PlayerActions.ableToUseWeapon = true;
						knifeModel.GetComponent<MeshRenderer> ().enabled = true;
						knifeModel.parent.GetComponent<PlayerKillEnemy>().enabled = true;
						itemSlot [index] = null;
						Debug.Log ("You can use knife now.");
					break;
					case "Torch":
						obj = ValidatePuzzle(itemSlot [index]);
						if(obj != null) {
							Destroy(obj);
							light.intensity = 8;
							itemSlot [index] = null;
							Debug.Log ("Rise and shine.");
						}
					break;
					case "Keycard":
						obj = ValidatePuzzle(itemSlot [index]);
						if(obj != null) {
							obj.GetComponent<Animator>().SetTrigger("unlock");
							obj.GetComponent<Animator>().SetBool("open", true);
							itemSlot [index] = null;
							Debug.Log ("You shall pass!");
						}
					break;
				}
				RenderItemIcon ();
			}
		}

		GameObject ValidatePuzzle (string item) {
			Transform target = playerE.ShootIt("Puzzle");
			if(target != null) {
				if(target.GetComponent<Puzzle>().Solve(item)) {
					Debug.Log("You solve "+target.name+" puzzle!");
					return target.gameObject;
				}
				else {
					Debug.Log ("Can't use "+item+" here.");
					return null;
				}
			}
			Debug.Log ("There's no target.");
			return null;
		}
	}
}