using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GirlCharacter : MonoBehaviour {

	[SerializeField] private SpriteRenderer rend;
	[SerializeField] private Vector2 startPosition;
	[SerializeField] private ParticleSystem diePs;

	private void Start() {
		ActionsController.Instance.onStartGame += OnStartGame;
		ActionsController.Instance.onEndGame += OnEndGame;
		ActionsController.Instance.onDidKill += OnDidKill;
	}

	private void OnStartGame() {
		transform.localPosition = startPosition;
		rend.enabled = true;
		diePs.gameObject.SetActive(false);
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
				ActionsController.Instance.SendOnPlayerDeath();
				rend.enabled = false;
				diePs.gameObject.SetActive(true);
				diePs.Play();
				Invoke("ResetPosition", 3f);
			} else {
				rend.enabled = false;
				diePs.gameObject.SetActive(true);
				diePs.Play();
			}
		}
	}

	private void ResetPosition() {
		rend.enabled = true;
		diePs.gameObject.SetActive(false);
		transform.localPosition = startPosition;
	}

}
