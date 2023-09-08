using UnityEngine;

public abstract class Interactable : MonoBehaviour
{
    private static GameObject _player;

    abstract public void Interact();

    public void DestroySelf()
    {
        Destroy(gameObject);
    }
    public bool IsInteractable()
    {
        return true;
    }
}
