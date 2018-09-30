using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lever : MonoBehaviour {

	[SerializeField] private Animator anim;
	[SerializeField] private GameObject interactTip;

	private bool isInTrigger;

	private void Start() {
		ActionsController.Instance.onPlayLeverAnim += PlayAnim;
	}

	public void ShowInteractTip() {
		if (PlayerController.Instance.canKill) {
			interactTip.SetActive(true);
		}
		isInTrigger = true;
	}

	public void HideInteractTip() {
		interactTip.SetActive(false);
		isInTrigger = false;
	}

	private void Update() {
		if (isInTrigger && PlayerController.Instance.canKill) {
			interactTip.SetActive(true);
		}
	}

	private void PlayAnim() {
		anim.SetBool("StartAnim", true);
		Invoke("StopAnim", 1.0f);
	}

	private void StopAnim() {
		anim.SetBool("StartAnim", false);
	}

}
