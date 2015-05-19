using UnityEngine;
using System.Collections;

public class SaveSpot : MonoBehaviour {

	void OnTriggerEnter () {
		PlayerPrefs.SetString ("SpawnSpot", transform.name);
	}
}
