using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class Backpack : MonoBehaviour {

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
						switch(str) {
							case "Healpack":
								transform.Find ("Slot"+(i+1)).Find ("Image").GetComponent<Image>().sprite = icon;
							break;
						}
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
				break;
			}
			itemSlot [index] = null;
			RenderItemIcon ();
		}
	}
}
