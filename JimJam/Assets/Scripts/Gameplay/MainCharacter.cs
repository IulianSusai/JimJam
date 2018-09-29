using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainCharacter : MonoBehaviour {

	[SerializeField] private Rigidbody2D rb;
	[SerializeField] private float moveSpeed;
	[SerializeField] private JumpTrigger jumpTrigger;
	[SerializeField] private float jumpSpeed;
	[SerializeField] private float jumpTime;
	[SerializeField] private AnimationCurve jumpCurve;

	private float startJumpTime;
	private bool isJumping;
	
	public void MoveRight() {
		rb.velocity = new Vector2(moveSpeed, rb.velocity.y);
	} 

	public void MoveLeft() {
		rb.velocity = new Vector2(-moveSpeed, rb.velocity.y);
	}

	public void StopMovement() {
		rb.velocity = new Vector2(0f, rb.velocity.y);
	}

	public void Jump() {
		if (jumpTrigger.canJump) {
			StartJump();
		}
	}

	public void StopJump() {
		rb.velocity = new Vector2(rb.velocity.x, 0f);
		isJumping = false;
	}

	private void StartJump() {
		jumpTrigger.canJump = false;
		isJumping = true;
		startJumpTime = Time.time;
	}

	private void Update() {
		if (isJumping) {
			JumpUpdate();
		}
	}

	private void JumpUpdate() {
		float timeSinceStarted = Time.time - startJumpTime;
		float percentage = timeSinceStarted / jumpTime;

		if(percentage <= 0.5f) {
			float yVel = jumpSpeed * jumpCurve.Evaluate(percentage);
			rb.velocity = new Vector2(rb.velocity.x, yVel);
		} else if(percentage > 0.5f && percentage < 1.0f) {
			float yVel = -jumpSpeed * jumpCurve.Evaluate(percentage);
			rb.velocity = new Vector2(rb.velocity.x, yVel);
		} else {
		//	StopJump();
		}

	}
}
