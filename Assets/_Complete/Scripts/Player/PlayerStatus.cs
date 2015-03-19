using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PlayerStatus : MonoBehaviour {

	[SerializeField]
	Slider hpSlider;
	[SerializeField]
	Animator cameraAnim;

	public static float maxHP = 100f;
	public static float hp;
	public static bool isDefending = false;
	bool isDied = false;

	void Start () {
		hp = maxHP;
	}

	void FixedUpdate () {
		if (!isDied) {
			hpSlider.value = hp / maxHP;

			if (hp <= 0f) {
				isDied = true;
				cameraAnim.SetTrigger("dying");
				cameraAnim.SetBool("died", true);
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
		yield return new WaitForSeconds(3);
		Application.LoadLevel (0);
	}
}
