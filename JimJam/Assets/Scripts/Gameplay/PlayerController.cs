using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {
	
	public static PlayerController Instance { private set; get; }
	private void Awake() {
		if(Instance == null) {
			Instance = this;
		} else {
			Destroy(gameObject);
		}
	}

	[SerializeField] private Vector3 startPosition;
	[SerializeField] private MainCharacter character;

	private bool gameStarted;

	private bool canKill;
	private bool didKill;

	private void Start() {
		ActionsController.Instance.onStartGame += StartGame;
		ActionsController.Instance.onEndGame -= EndGame;
	}

	private void StartGame() {
		gameStarted = true;
		canKill = false;
		didKill = false;
		character.transform.position = startPosition;
	}

	private void EndGame() {
		gameStarted = false;
	}

	private void Update() {
		if (gameStarted) {
			if (Input.GetKeyDown(KeyCode.W)) {
				character.Jump();
			}
			if (Input.GetKeyDown(KeyCode.A)) {
				character.MoveLeft();
			} else if (Input.GetKeyDown(KeyCode.D)) {
				character.MoveRight();
			} else if (Input.GetKeyUp(KeyCode.A) || Input.GetKeyUp(KeyCode.D)) {
				character.StopMovement();
			}

			if (Input.GetKeyUp(KeyCode.A) && Input.GetKey(KeyCode.D)) {
				character.MoveRight();
			} else if (Input.GetKeyUp(KeyCode.D) && Input.GetKey(KeyCode.A)) {
				character.MoveLeft();
			}

			if (Input.GetKeyDown(KeyCode.E)) {
				Interact();
			}
		}

		if (Input.GetKeyDown(KeyCode.Escape)) {
			ActionsController.Instance.SendOnEscPressed();
		} else if (Input.GetKeyDown(KeyCode.Return)) {
			ActionsController.Instance.SendOnEnterPressed();
		} else if (Input.GetKeyDown(KeyCode.Space)) {
			ActionsController.Instance.SendOnSpacePressed();
		}
	}

	private void Interact() {
		if (canKill && character.canInteract) {
			didKill = true;
		}
	}

}
