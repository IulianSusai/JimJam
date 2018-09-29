using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Moon : MonoBehaviour {

	[SerializeField] private float nextEclipseWaitTime;
	[SerializeField] private float eclipseWaitTime;
	[SerializeField] private float eclipseAnimTime;
	[SerializeField] private Color offEcpliseColor;
	[SerializeField] private Color onEclipseColor;
	[SerializeField] private AnimationCurve onEclipseCurve;
	[SerializeField] private AnimationCurve offEclipseCurve;
	[SerializeField] private SpriteRenderer rend;

	private Color startColor;
	private Color endColor;
	private AnimationCurve currentCurve;
	private float currentTime;
	private bool isLerping;
	private bool isOnEclipse;

	private void Start() {
		ActionsController.Instance.onStartGame += OnStartGame;
		ActionsController.Instance.onEndGame -= OnEndGame;
	}

	private void OnStartGame() {
		Invoke("StartOnEclipse", nextEclipseWaitTime);
	}

	private void OnEndGame() {
		CancelInvoke();
		isLerping = false;
	}

	private void StartOnEclipse() {
		startColor = offEcpliseColor;
		endColor = onEclipseColor;
		currentCurve = onEclipseCurve;
		isLerping = true;
		currentTime = Time.time;
		isOnEclipse = true;
		ActionsController.Instance.SendOnCanKill(true);
	}

	private void StartOffEclipse() {
		startColor = onEclipseColor;
		endColor = offEcpliseColor;
		currentCurve = offEclipseCurve;
		isLerping = true;
		currentTime = Time.time;
		isOnEclipse = false;
	}

	private void Update() {
		if (isLerping) {
			UpdateLerp();
		}
	}

	private void UpdateLerp() {
		float timeSinceStarted = Time.time - currentTime;
		float percentage = timeSinceStarted / eclipseAnimTime;
		rend.color = Color.Lerp(startColor, endColor, currentCurve.Evaluate(percentage));
		if(percentage >= 1.0f) {
			isLerping = false;
			if (isOnEclipse) {
				Invoke("StartOffEclipse", eclipseWaitTime);
			} else {
				ActionsController.Instance.SendOnCanKill(false);
				Invoke("StartOnEclipse", nextEclipseWaitTime);
			}
		}
	}

}
