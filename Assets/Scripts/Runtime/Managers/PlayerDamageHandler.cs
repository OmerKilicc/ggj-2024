using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDamageHandler : MonoBehaviour
{
	[Tooltip("Event to raise when player is dead")]
	public static event Action OnPlayerDeath;

	[Tooltip("Health to reduce from player when hit.")]
	[SerializeField]
	private float _damageAmount;

	[Tooltip("Scriptale Object that stores player data.")]
	private PlayerDataSO playerData;

	private void OnEnable()
	{
		RangedEnemyAttackState.OnPlayerDamage += HandlePlayerDamage;
	}

	private void OnDisable()
	{
		RangedEnemyAttackState.OnPlayerDamage -= HandlePlayerDamage;
	}

	private void HandlePlayerDamage()
	{

		if (playerData.CurrentHealth > 0) 
		{
			playerData.CurrentHealth -= _damageAmount;
		}

		else 
		{
			TimeManager timeManager = FindObjectOfType<TimeManager>();
			HandlePlayerDeath(timeManager);
		}
	}

	private void HandlePlayerDeath(TimeManager timeManager)
	{
		OnPlayerDeath.Invoke();
		timeManager.ChangeDay();
		SpawnPlayerAtHut();
	}

	private void SpawnPlayerAtHut()
	{
		//TODO: Spawn player to hut
	}
}
