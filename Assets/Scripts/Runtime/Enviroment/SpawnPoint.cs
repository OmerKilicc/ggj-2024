using UnityEngine;

public class SpawnPoint : MonoBehaviour
{
    public static SpawnPoint Instance;

    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(this);
            return;
        }

        Instance = this;
    }
}
