using UnityEngine;
using System.Collections;

public class SaveLoad : MonoBehaviour {

	[SerializeField] Transform player;

	void StartOver () {
		player.gameObject.SetActive (true);
	}

	void LoadProgress () {
		player.gameObject.SetActive (true);
		// player's position and rotation
		string spot = PlayerPrefs.GetString ("SpawnSpot");
		player.position = GameObject.Find (spot).transform.position;
		player.rotation = GameObject.Find (spot).transform.rotation;

		// puzzle solving
		foreach (Transform puzTrans in GameObject.Find ("Puzzle").transform) {
			if (PlayerPrefs.GetInt (puzTrans.name+"_Puzzle") == 1) {
				puzTrans.GetComponentInChildren<Puzzle>().DonePuzzle ();
			}
		}
	}
}
