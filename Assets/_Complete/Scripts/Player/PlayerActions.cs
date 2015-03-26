using UnityEngine;
using System.Collections;
using UnityStandardAssets.Characters.FirstPerson;

namespace Player {
	public class PlayerActions : MonoBehaviour {

		[SerializeField] Animator weaponAnim;
		[SerializeField] FirstPersonController fpsCtrl;
		public static bool ableToUse = false;
		bool atkCoolDown = false;

		void Update () {
			if (ableToUse) {
				if (!atkCoolDown && Input.GetButtonDown ("Fire1")) {
					StartCoroutine ("AttackCoolDown");
					weaponAnim.SetTrigger ("slash");
				}

				if (Input.GetButton ("Fire2")) {
					PlayerStatus.isDefending = true;
					weaponAnim.SetBool ("defend", true);
				} else {
					PlayerStatus.isDefending = false;
					weaponAnim.SetBool ("defend", false);
				}

				if (!fpsCtrl.IsWalking) {
					weaponAnim.SetBool ("swing", true);
					weaponAnim.ResetTrigger ("slash");
				} else {
					weaponAnim.SetBool ("swing", false);
				}
			}
		}

		IEnumerator AttackCoolDown () {
			atkCoolDown = true;
			yield return new WaitForSeconds (.6f);
			atkCoolDown = false;
		}
	}
}