using System;
using UnityEngine;

public class PlayerDamageHandler : MonoBehaviour, ITarget
{
	public static event Action OnPlayerDeath;

	[Tooltip("Scriptale Object that stores player data.")]
	[SerializeField] private PlayerDataSO playerData;

    private void Start()
    {
		playerData.ResetHealth();
    }
    private void HandlePlayerDamage(float damageAmount)
	{
		playerData.CurrentHealth = Mathf.Clamp(playerData.CurrentHealth - damageAmount, 0f, float.MaxValue);

		if (Mathf.Approximately(playerData.CurrentHealth, 0f))
		{
			TimeManager timeManager = FindObjectOfType<TimeManager>();
			HandlePlayerDeath(timeManager);
		}
	}

	private void HandlePlayerDeath(TimeManager timeManager)
	{
		OnPlayerDeath?.Invoke();
		timeManager.ChangeDay();
		SpawnPlayerAtHut();
	}

	private async void SpawnPlayerAtHut()
	{
		Debug.Log("Hit Worked");

		await LevelManager.Instance.ReturnToThroneRoom();
	}

    public void Hit(float damage)
    {
		HandlePlayerDamage(damage);
    }
}
