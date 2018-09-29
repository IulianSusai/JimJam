using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lever : MonoBehaviour {

	[SerializeField] private GameObject interactTip;

	public void ShowInteractTip() {
		interactTip.SetActive(true);
	}

	public void HideInteractTip() {
		interactTip.SetActive(false);
	}

}
