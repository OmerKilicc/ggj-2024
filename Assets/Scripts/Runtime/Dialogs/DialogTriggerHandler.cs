using System;
using UnityEngine;

public class DialogTriggerHandler : MonoBehaviour
{
    public static event Action<DialogSO> DialogStarted;
    public static event Action<DialogSO> DialogEnded;

	[Tooltip("Dialogs to play.")]
    [SerializeField] private DialogSO _dialogsFromTrigger;

	private void OnTriggerEnter(Collider other)
	{
        if (other.CompareTag("Player"))
        {
			DialogStarted.Invoke(_dialogsFromTrigger);
        }
	}

	private void OnTriggerExit(Collider other)
	{
		if (other.CompareTag("Player"))
		{
			DialogEnded.Invoke(_dialogsFromTrigger);
		}
	}

}
