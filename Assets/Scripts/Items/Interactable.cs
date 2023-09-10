using UnityEngine;

public abstract class Interactable : MonoBehaviour
{
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
