using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "PlayerData", menuName = "PlayerData/PlayerDataSO")]

public class PlayerDataSO : ScriptableObject
{
	[SerializeField] private float _defaultHappines = 100;

	private float? _currentHappines = null;
	public float CurrentHappines { get => _currentHappines ?? _defaultHappines; set => _currentHappines = value; }
}
