﻿using System;
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

}
