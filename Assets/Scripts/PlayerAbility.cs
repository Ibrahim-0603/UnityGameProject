using UnityEngine;

public abstract class PlayerAbility : MonoBehaviour
{
    protected float duration;
    public abstract void Activate(GameObject player);
}
