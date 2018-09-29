using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GirlCharacter : MonoBehaviour {

	[SerializeField] private Vector2 startPosition;

	private void Start() {
		ActionsController.Instance.onStartGame += OnStartGame;
		ActionsController.Instance.onEndGame += OnEndGame;
		ActionsController.Instance.onDidKill += OnDidKill;
	}

	private void OnStartGame() {
		transform.localPosition = startPosition;
	}
	
	private void OnDidKill() {
		CancelInvoke();
	}

	private void OnEndGame() {
		CancelInvoke();
	}

	private void OnTriggerEnter2D(Collider2D collision) {
		if (collision.CompareTag("Obstacle")) {
			ActionsController.Instance.SendOnResetGirl();
			if (!PlayerController.Instance.didKill) {
				Invoke("ResetPosition", 1f);
			}
		}
	}

	private void ResetPosition() {
		transform.localPosition = startPosition;
	}

}
