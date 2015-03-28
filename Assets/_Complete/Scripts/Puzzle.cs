using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Puzzle : MonoBehaviour {

	[SerializeField] bool isDone = false;
	[SerializeField] bool isEvent = false;
	[SerializeField] string questItem = "(need no item when is event)";
	[SerializeField] string questMsg;
	[SerializeField] float duration = 3f;
	public bool IsDone {
		get { return isDone; }
	}
	public bool IsEvent {
		get { return isEvent; }
	}
	public string QuestItem {
		get { return questItem; }
	}
	public string QuestMsg {
		get { return questMsg; }
	}
	public float Duration {
		get { return duration; }
	}

	public bool Solve (string item) {
		if (item == questItem) {
			isDone = true;
			return true;
		} else {
			return false;
		}
	}
}
