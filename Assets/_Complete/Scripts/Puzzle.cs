using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Puzzle : MonoBehaviour {

	[SerializeField] bool isDone = false;
	[SerializeField] bool isEvent = false;
	[SerializeField] string questItem = "(need no item when is event)";
	[SerializeField] string questMsg;
	[SerializeField] string resultMsg;
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
	public string ResultMsg {
		get { return resultMsg; }
	}
	public float Duration {
		get { return duration; }
	}

	Animator anim;

	void Start () {

		Debug.Log (questItem + "_Puzzle:" + PlayerPrefs.GetInt (questItem + "_Puzzle"));
		// check is puzzle already been solved?
		if (PlayerPrefs.GetInt (questItem + "_Puzzle") == 1) {
			isDone = true;
			anim = GetComponent<Animator> ();
			anim.SetBool ("open", true);
			Destroy (GameObject.Find (questItem));
		}
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
