using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityStandardAssets.Characters.FirstPerson;

public class PlayerStatus : MonoBehaviour {

	[SerializeField] Slider hpSlider;
	[SerializeField] FirstPersonController fpsCtrler;
	[SerializeField] Animator cameraAnim;
	[SerializeField] Animator maskAnim;

	public static float maxHP = 100f;
	public static float hp;
	public static bool isDefending = false;
	bool isDied = false;

	void Start () {
		hp = maxHP;
		hpSlider.maxValue = maxHP;
	}

	void FixedUpdate () {
		if (!isDied) {
			hpSlider.value = hp;

			if (hp <= 0f) {
				isDied = true;
				StartCoroutine("GameOver");
			}
		}
	}

	public static void AddHP (float amt) {
		if (hp + amt > maxHP)
			hp = 100f;
		else if (hp + amt < 0)
			hp = 0f;
		else {
			if(amt < 0 && isDefending) {
				hp += amt / 2;
			}
			else {
				hp += amt;
			}
		}
	}

	IEnumerator GameOver () {
		fpsCtrler.enabled = false;
		cameraAnim.enabled = true;
		yield return new WaitForSeconds(.5f);
		cameraAnim.SetBool ("die", true);
		maskAnim.SetBool ("show", true);
		yield return new WaitForSeconds (3f);
		Application.LoadLevel (0);
	}
}
