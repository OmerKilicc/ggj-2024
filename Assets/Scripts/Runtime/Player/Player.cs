using UnityEngine;

public class Player : MonoBehaviour
{
    public static Player Instance;

    private void Awake()
    {
        print("AWAKE");
        if (Instance != null)
        {
            Destroy(this);
            return;
        }

        Instance = this;
    }
}
