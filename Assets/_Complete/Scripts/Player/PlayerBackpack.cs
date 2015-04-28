using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

namespace Player {
	public class PlayerBackpack : MonoBehaviour {

		bool isBinded = false;
		Message msg;
		PlayerE playerE;
		Transform knifeModel;
		Light light;
		string[] itemSlot;
		Sprite[] itemIcon;

		void Bind () {
			isBinded = true;
			msg = GameObject.Find ("Message").GetComponent<Message> ();
			playerE = GameObject.Find ("Player").GetComponent<PlayerE> ();
			knifeModel = GameObject.Find ("Player").transform.Find ("Camera").Find ("Weapon").Find ("Model");
			light = GameObject.Find ("Player").transform.Find ("Light").GetComponent<Light>();

			itemSlot = new string[3];
			itemIcon = Resources.LoadAll<Sprite>("Item");
		}

		void Update () {
			if (isBinded) {
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
		}
		
		public bool GetItem (string name) {
			if(itemSlot[0]==null)itemSlot[0] = name;
			else if(itemSlot[1]==null)itemSlot[1] = name;
			else if(itemSlot[2]==null)itemSlot[2] = name;
			else {
				msg.ShowMessageForSeconds("你帶不了更多的東西了。", 2f);
				return false;
			}
			msg.ShowMessageForSeconds("取得 "+name+" 。", 2f);
			RenderItemIcon ();
			return true;
		}

		void RenderItemIcon () {
			for (int i=0;i<itemSlot.Length;i++) {
				string str = itemSlot[i];
				if(str == null) {
					transform.Find ("Slot"+(i+1)).Find ("Image").GetComponent<Image>().sprite = null;
					transform.Find ("Slot"+(i+1)).Find ("Image").GetComponent<Image>().color = Color.clear;
				}
				else {
					foreach (Sprite icon in itemIcon) {
						if(icon.name == str) {
							transform.Find ("Slot"+(i+1)).Find ("Image").GetComponent<Image>().sprite = icon;
							transform.Find ("Slot"+(i+1)).Find ("Image").GetComponent<Image>().color = Color.white;
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
					break;
					case "Knife":
						PlayerActions.ableToUseWeapon = true;
						knifeModel.GetComponent<MeshRenderer> ().enabled = true;
						knifeModel.parent.GetComponent<PlayerKillEnemy>().enabled = true;
						itemSlot [index] = null;
					break;
					case "Torch":
					case "Keycard":
					case "Axe":
						obj = ValidatePuzzle(itemSlot [index]);
						if(obj != null) {
							if(itemSlot [index] == "Torch")light.intensity = 8;
							msg.ShowMessageForSeconds(obj.GetComponent<Puzzle>().ResultMsg, obj.GetComponent<Puzzle>().Duration);
							obj.GetComponent<Animator>().SetTrigger("unlock");
							PlayerPrefs.SetInt(itemSlot [index]+"_Puzzle", 1);
							itemSlot [index] = null;
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
					return target.gameObject;
				}
				else {
					msg.ShowMessageForSeconds(item+" 好像不是用在這裡的...", 2f);
					return null;
				}
			}
			return null;
		}
	}
}