using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "PlayerData", menuName = "PlayerData/PlayerDataSO")]

public class PlayerDataSO : ScriptableObject
{
	[SerializeField] private float _happines;
}
