using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class LevelChangeTriggerHandler : MonoBehaviour
{
	[Tooltip("Give the index of the level you want to transition to.")]
	[SerializeField] private int _indexOfTheLevel;

	[Tooltip("Seconds to wait in collider for transition.")]
	[SerializeField] private int _secondsToWait = 3;

	[Tooltip("Message to be displayed if player is not in trigger.")]
	[SerializeField] private string _defaultTriggerMessage = "Wait here for teleportation!";

	[Tooltip("Message to be displayed when countdowning")]
	[SerializeField] private string _countdownText = "Teleporting in {0} seconds.";

	private TextMeshPro _textToDisplay;
	private bool _isCoroutineWorking = false;

	void Start()
	{
		_textToDisplay = GetComponentInChildren<TextMeshPro>();
		ResetTheTransitionProcess();
	}

	private void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.CompareTag("Player"))
		{
			HandleSceneTransitions();
		}
	}

	private void OnTriggerExit(Collider other)
	{
		if (other.gameObject.CompareTag("Player"))
		{
			ResetTheTransitionProcess();
		}
	}

	private void ResetTheTransitionProcess()
	{
		_textToDisplay.text = _defaultTriggerMessage;

		if (_isCoroutineWorking)
		{
			StopCoroutine(StartCoutdownToTeleport());
			_isCoroutineWorking = false;
		}
	}

	private void HandleSceneTransitions()
	{
		StartCoroutine(StartCoutdownToTeleport());
	}

	private IEnumerator StartCoutdownToTeleport()
	{
		_isCoroutineWorking = true;

		//Writes the countdown to TMP
		for (int i = _secondsToWait; i >= 0; i--)
		{
			_textToDisplay.text = String.Format(_countdownText, i);
			yield return new WaitForSeconds(1);
		}

		LevelManager.Instance.LoadLevel(_indexOfTheLevel);
	}
}
