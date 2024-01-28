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

        Scene scene = SceneManager.GetSceneByBuildIndex(_throneRoomIndex);
        SceneManager.SetActiveScene(scene);

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

        Scene scene = SceneManager.GetSceneByBuildIndex(buildIndex);
        SceneManager.SetActiveScene(scene);

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

        Transform playerTransform = Player.Instance?.transform ?? null;
        CharacterController playerController = Player.Instance?.GetComponent<CharacterController>();

        Transform spawnPoint = SpawnPoint.Instance?.transform ?? null;

        if (playerController != null && spawnPoint != null)
        {
            playerController.enabled = false;

            playerTransform.position = spawnPoint.position;
            playerTransform.forward = spawnPoint.forward;

            playerController.enabled = true;
        }
    }

    public async UniTask DespawnPlayerIfExists()
    {
        if (_playerLoaded)
        {
            await SceneManager.UnloadSceneAsync(_playerSceneIndex);
        }
    }
}
