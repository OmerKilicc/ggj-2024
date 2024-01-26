using System;
using UnityEngine;

public class DialogTriggerHandler : MonoBehaviour
{
    public static event Action<DialogSO> DialogStarted;
    [SerializeField] private DialogSO _dialogsFromTrigger;

	private void OnTriggerEnter(Collider other)
	{
        Debug.Log("Trigger tetik");
        if (other.CompareTag("Player"))
        {
			Debug.Log("Trigger player tetik");
			DialogStarted.Invoke(_dialogsFromTrigger);
        }

	}

}
