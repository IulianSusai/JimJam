using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActionsController {

	private static ActionsController instance;
	public static ActionsController Instance {
		get {
			if(instance == null) {
				instance = new ActionsController();
			}
			return instance;
		}
	}
	private ActionsController() { }

	public Action onEnterPressed;
	public Action onSpacePressed;
	public Action onEscPressed;
	public Action onStartGame;
	public Action onEndGame;
	public Action onHitFinish;
	public Action onResetGirl;
	public Action onDidKill;
	public Action<bool> onCanKill;

	public void SendOnDidKill() {
		if(onDidKill != null) {
			onDidKill();
		}
	}

	public void SendOnResetGirl() {
		if(onResetGirl != null) {
			onResetGirl();
		}
	}

	public void SendOnCanKill(bool canKill) {
		if(onCanKill != null) {
			onCanKill(canKill);
		}
	}

	public void SendOnEscPressed() {
		if(onEscPressed != null) {
			onEscPressed();
		}
	}

	public void SendOnSpacePressed() {
		if(onSpacePressed != null) {
			onSpacePressed();
		}
	}

	public void SendOnEnterPressed() {
		if(onEnterPressed != null) {
			onEnterPressed();
		}
	}

	public void SendOnStartGame() {
		if(onStartGame != null) {
			onStartGame();
		}
	}

	public void SendOnEndGame() {
		if(onEndGame != null) {
			onEndGame();
		}
	}

	public void SendOnHitFinish() {
		if(onHitFinish != null) {
			onHitFinish();
		}
	}

}
