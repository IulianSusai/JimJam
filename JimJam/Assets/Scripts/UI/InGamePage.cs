using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InGamePage : MenuPage {


	public override void OnShow() {
		ActionsController.Instance.onEscPressed += OnAction;
	}

	public override void OnHide() {
		ActionsController.Instance.onEscPressed -= OnAction;
	}

	private void OnAction() {
		UIManager.Instance.ChangePage(MenuPages.MainPage);
	}

}
