using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {

	public enum State { Menu, Previous, Landing, Continue, Startover, Playing };
	public static State nowState;

	void Start () {
		CheckState (State.Menu);
	}
	
	public static void CheckState (State nextState) {
		
		nowState = nextState;
		
		switch (nowState) {
			
		case State.Menu:
			RenderSettings.fogDensity = 0.008f;
			break;

		case State.Previous:
			// turn on preivous things
			GameObject.Find ("PreviousCamera").SendMessage ("TurnOnPreviousThings");
			break;
		
		case State.Landing:
			// turn on landing things
			GameObject.Find ("Landing").SendMessage ("TurnOnLandingThings");
			break;

		case State.Continue:
			GameObject.Find ("GameManager").SendMessage("LoadProgress");
			CheckState (State.Playing);
			break;
		case State.Startover:
			GameObject.Find ("GameManager").SendMessage("StartOver");
			CheckState (State.Playing);
			break;
		case State.Playing:
			RenderSettings.fogDensity = 0.02f;
			Destroy (GameObject.Find ("BoatCamera"));
			Destroy (GameObject.Find ("StartCamera"));
			Destroy (GameObject.Find ("StartCanvas"));
			Destroy (GameObject.Find ("PreviousCamera"));
			Destroy (GameObject.Find ("PreviousCanvas"));
			break;
		}
	}
}
