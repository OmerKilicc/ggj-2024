using TMPro;
using UnityEngine;

public class DialogsPresenter : MonoBehaviour
{
	[SerializeField] CanvasGroup _dialogCanvas;
	[SerializeField] TextMeshProUGUI _nameText;
	[SerializeField] TextMeshProUGUI _messageText;

	private bool _shouldCanvasBeOpen = false;
	public bool ShouldCanvasBeOpen { get => _shouldCanvasBeOpen; set => _shouldCanvasBeOpen = value; }

	void Start()
    {
		ShouldCanvasBeOpen = false;
        ChangeCanvasVisibility();
    }

	public void ChangeCanvasVisibility()
	{
		if (!ShouldCanvasBeOpen) 
		{
			_dialogCanvas.alpha = 0;
			_dialogCanvas.interactable = false;
		}
		else
		{
			_dialogCanvas.alpha = 1;
			_dialogCanvas.interactable = true;
		}
	}

	public void ShowLine(DialogSO.DialogLine line)
	{
		ShouldCanvasBeOpen = true;
		ChangeCanvasVisibility();

		_nameText.text = line.Talker;
		_messageText.text = line.Text;
	}

}
