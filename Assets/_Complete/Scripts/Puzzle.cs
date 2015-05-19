using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Puzzle : MonoBehaviour {

	[SerializeField] string puzzleName;
	[SerializeField] bool isDone = false;
	[SerializeField] bool isEvent = false;
	[SerializeField] string questItem = "";
	[SerializeField] string questMsg = "";
	[SerializeField] string resultMsg = "";
	[SerializeField] float duration = 3f;
	public string PuzzleName {
		get { return puzzleName; }
	}
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
		anim = GetComponent<Animator> ();
		puzzleName = transform.parent.name;
	}

	public bool Solve (string item) {
		if (!isDone && item == questItem) {
			isDone = true;
			return true;
		}
		else {
			return false;
		}
	}

	public void DonePuzzle () {
		isDone = true;
		anim.SetBool ("open", true);
		Destroy (GameObject.Find (questItem));
	}
}
