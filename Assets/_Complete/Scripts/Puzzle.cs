using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Puzzle : MonoBehaviour {

	public string questItem;
	public string questMsg;
	public string QuestItem {
		get {
			return questItem;
		}
	}
	public 	string QuestMsg {
		get {
			return questMsg;
		}
	}
	bool fadeOut = false;

	public bool Solve (string item) {
		if (item == questItem)
			return true;
		else
			return false;
	}
}
