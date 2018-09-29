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
	[SerializeField] private Vector3 resetPosition;
	[SerializeField] private MainCharacter character;

	private bool gameStarted;

	public bool canKill { private set; get; }
	public bool didKill { private set; get; }

	private void Start() {
		ActionsController.Instance.onStartGame += StartGame;
		ActionsController.Instance.onEndGame += EndGame;
		ActionsController.Instance.onHitFinish += OnHitFinish;
		ActionsController.Instance.onCanKill += OnCanKill;
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

	private void OnCanKill(bool cK) {
		canKill = cK;
		Debug.Log(canKill);
	}

	private void Update() {
		if (gameStarted) {
			if (Input.GetKeyDown(KeyCode.W)) {
				character.Jump();
			}
			if (Input.GetKey(KeyCode.A)) {
				character.MoveLeft();
			} else if (Input.GetKey(KeyCode.D)) {
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
		if (canKill && !didKill && character.canInteract ) {
			didKill = true;
			ActionsController.Instance.SendOnDidKill();
		}
	}

	private void OnHitFinish() {
		if (didKill) {
			character.StopMovement();
			UIManager.Instance.ChangePage(MenuPages.EndStoryPage);
		} else {
			ResetPlayer();
		}
	}

	private void ResetPlayer() {
		character.transform.position = resetPosition;
	}

}
