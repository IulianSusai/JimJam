using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpTrigger : MonoBehaviour {

	[SerializeField] private MainCharacter character;
	[HideInInspector] public bool canJump;

	private void Start() {
		canJump = false;
	}

	private void OnTriggerEnter2D(Collider2D collision) {
		if (!canJump && collision.CompareTag("Platform")) {
			canJump = true;
			character.StopJump();
		}
	}

}
