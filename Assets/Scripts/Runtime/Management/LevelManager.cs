using Cysharp.Threading.Tasks;
using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    public static event Action<int> OnLevelLoaded;

    [SerializeField] private int _throneRoomIndex;
    [SerializeField] private int _playerSceneIndex;
    [SerializeField] private int[] _levelIndexes;

    private int? _loadedScene;
    private bool _playerLoaded = false;

    public static LevelManager Instance;

    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(this);
            return;
        }

        Instance = this;
    }

    private void Start()
    {
        ReturnToThroneRoom();
    }

    public async UniTask ReturnToThroneRoom()
    {
        await UnloadLoadedLevelIfExists();
        await SceneManager.LoadSceneAsync(_throneRoomIndex, LoadSceneMode.Additive);
        await SpawnPlayer();

        _loadedScene = null;

        OnLevelLoaded?.Invoke(-1);
    }

    public async UniTask LoadLevel(int index)
    {
        index = Mathf.Clamp(index, 0, _levelIndexes.Length);
        int buildIndex = _levelIndexes[index];

        await UnloadLoadedLevelIfExists();

        await SceneManager.LoadSceneAsync(buildIndex, LoadSceneMode.Additive);

        await SpawnPlayer();

        _loadedScene = index;

        OnLevelLoaded?.Invoke(index);
    }

    private async UniTask UnloadLoadedLevelIfExists()
    {
        if (_loadedScene.HasValue)
            await SceneManager.UnloadSceneAsync(_loadedScene.Value);
    }

    public async UniTask SpawnPlayer()
    {
        await DespawnPlayerIfExists();

        await SceneManager.LoadSceneAsync(_playerSceneIndex, LoadSceneMode.Additive);

        Transform player = GameObject.FindGameObjectWithTag("Player")?.transform ?? null;
        Transform spawnPoint = GameObject.FindGameObjectWithTag("SpawnPoint")?.transform ?? null;

        player.position = spawnPoint.position;

        _playerLoaded = true;
    }

    public async UniTask DespawnPlayerIfExists()
    {
        if (_playerLoaded)
        {
            await SceneManager.UnloadSceneAsync(_playerSceneIndex);
        }
    }
}
