using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveAndLoadManager : MonoBehaviour
{
	private GameData gameData;

	void Start()
	{
		gameData = LoadGame();
		// Initialize your game with loaded data
	}

	public void SaveGameAtCheckpoint()
	{
		// Update gameData with the current state
		// Example: gameData.level = currentLevel;
		// More game state updates...

		SaveGame(gameData);
	}

	public void SaveGame(GameData data)
	{
		string jsonData = JsonUtility.ToJson(data);
		PlayerPrefs.SetString("GameData", jsonData);
		PlayerPrefs.Save();
	}

	public GameData LoadGame()
	{
		if (PlayerPrefs.HasKey("GameData"))
		{
			string jsonData = PlayerPrefs.GetString("GameData");
			GameData loadedData = JsonUtility.FromJson<GameData>(jsonData);
			return loadedData;
		}

		return new GameData(); // Returns a new object if no save data exists
	}

	// Example of a manual save feature (could be called from a UI button)
	public void OnSaveButtonPressed()
	{
		SaveGame(gameData);
	}

	// Example method to update the game data (you would call this as needed in your game)
	public void UpdateGameData(int level, int health, float[] position)
	{
		gameData.level = level;
		gameData.health = health;
		gameData.position = position;
	}
}
