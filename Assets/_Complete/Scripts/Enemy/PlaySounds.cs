using UnityEngine;
using System.Collections;

public class PlaySounds : MonoBehaviour {

	[SerializeField] AudioClip[] audioClips; // 0=atk, 1=hit, 2=dead

	void SFX (int n) {
		GetComponent<AudioSource>().clip = audioClips[n-1];
		GetComponent<AudioSource>().Stop();
		GetComponent<AudioSource>().Play();
	}
}
