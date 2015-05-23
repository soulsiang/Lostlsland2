using UnityEngine;
using System.Collections;

public class MonsterPoint : MonoBehaviour {

	[SerializeField] GameObject monsterPack;

	void OnTriggerEnter (Collider other) {
		if (other.tag == "Player") {
			Instantiate (monsterPack);
			Destroy (gameObject, 2f);
		}
	}
}
