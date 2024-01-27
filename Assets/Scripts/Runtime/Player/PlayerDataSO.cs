using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "PlayerData", menuName = "PlayerData/PlayerDataSO")]

public class PlayerDataSO : ScriptableObject
{
	[SerializeField] private float _defaultHealth = 100;

	private float? _currentHealth = null;
	public float CurrentHealth { get => _currentHealth ?? _defaultHealth; set => _currentHealth = value; }
}

