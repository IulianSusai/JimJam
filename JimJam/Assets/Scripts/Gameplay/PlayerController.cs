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

	[SerializeField] private MainCharacter character; 

	private void Update() {
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

		if(Input.GetKeyUp(KeyCode.A) && Input.GetKey(KeyCode.D)) {
			character.MoveRight();
		} else if(Input.GetKeyUp(KeyCode.D) && Input.GetKey(KeyCode.A)) {
			character.MoveLeft();
		}

	}

}
