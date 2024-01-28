using System;
using TMPro;
using UnityEngine;

public class DialogsManager : MonoBehaviour
{
	int _currentLine = 0;
	[SerializeField] DialogsPresenter _presenter;

	DialogSO _currentDialog;
	InputsSystem _playerInput;


	private void OnEnable()
	{
		_playerInput = new InputsSystem();
		_playerInput.Character.NextDialogLine.performed += ShowNextLineCallback;

		DialogTriggerHandler.DialogStarted += OnDialogStart;
		DialogTriggerHandler.DialogEnded += OnDialogEnd;
	}

	private void OnDisable()
	{
		DialogTriggerHandler.DialogStarted -= OnDialogStart;
		DialogTriggerHandler.DialogEnded -= OnDialogEnd;

		_playerInput.Character.NextDialogLine.performed -= ShowNextLineCallback;
		_playerInput.Dispose();
	}


	private void ShowNextLineCallback(UnityEngine.InputSystem.InputAction.CallbackContext obj)
	{
		if (_currentLine < _currentDialog.LineCount - 1)
		{
			ShowNextLine();
		}
		else
		{
			OnDialogEnd(_currentDialog);
		}
	}

	private void ShowNextLine()
	{
		_presenter.ShowLine(_currentDialog.GetLine(++_currentLine));
	}


	//starts the sequence by taking the first line
	void OnDialogStart(DialogSO dialogList)
	{
		_currentLine = 0;
		_currentDialog = dialogList;

		_presenter.ShowLine(_currentDialog.GetLine(_currentLine));

		_playerInput.Enable();
	}


	private void OnDialogEnd(DialogSO sO)
	{
		_playerInput.Disable();
		_presenter.ShouldCanvasBeOpen = false;
		_presenter.ChangeCanvasVisibility();
	}

}
