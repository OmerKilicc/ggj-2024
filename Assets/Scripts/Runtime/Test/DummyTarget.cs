using UnityEngine;

public class DummyTarget : MonoBehaviour, ITarget
{
    public void Hit(float damage)
    {
        Debug.Log($"{gameObject.name} GOT HIT, DAMAGE: {damage}");
    }
}
