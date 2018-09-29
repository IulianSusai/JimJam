using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cage : MonoBehaviour {

	[SerializeField] private Animator anim;

	private void Start() {
		ActionsController.Instance.onCanKill += OnCanKill;
		ActionsController.Instance.onResetGirl += OnResetGirl;
		ActionsController.Instance.onDidKill += OnDidKill;
	}

	private void OnCanKill(bool canKill) {
		Debug.Log("can kill" + canKill);
		if (!canKill && !PlayerController.Instance.didKill) {
			anim.SetBool("Kill", true);
		}
	}

	private void OnResetGirl() {
		anim.SetBool("Kill", false);
	}

	private void OnDidKill() {
		anim.SetBool("Kill", true);
	}
}
