using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "DialogSO", menuName = "Dialogs/DialogSO")]
public class DialogSO : ScriptableObject
{
	[SerializeField]
	List<DialogLine> _dialogLines = new List<DialogLine>();

	public int LineCount => _dialogLines.Count;

	public DialogLine GetLine(int index) { return _dialogLines[index]; }


	[System.Serializable]
	public struct DialogLine
	{
		public string Talker;
		public string Text;
	}
}
