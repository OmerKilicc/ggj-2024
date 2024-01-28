using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "PlayerData", menuName = "PlayerData/PlayerDataSO")]

public class PlayerDataSO : ScriptableObject
{
	[SerializeField] private float _defaultHealth = 100;

	[SerializeReference]
	public float CurrentHealth;

    public void ResetHealth()
    {
        CurrentHealth = _defaultHealth;
    }

}

