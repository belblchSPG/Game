using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class PlayerInteractionController : MonoBehaviour
{
    [SerializeField] private PlayerInventoryController inventoryController;
    [SerializeField] private GameObject _interactWindow;

    [SerializeField] private CapsuleCollider _capsuleCollider;
    [SerializeField] private List<GameObject> _objectsToInteractWith;
    [SerializeField] private bool _canInteractWithSomething;

    [SerializeField] private BoxCollider _boxCollider;
    [SerializeField] private List<GameObject> _enemyList;

    private void Start()
    {
        inventoryController = GetComponent<PlayerInventoryController>();
    }

    private void Update()
    {
        PlayerInteraction();
        UI_PlayerInteraction();
    }
    public void ClearAfterInteraction()
    {
        if (_objectsToInteractWith.Count > 0)
        {
            _objectsToInteractWith.Remove(_objectsToInteractWith.First());
        }
        if (_objectsToInteractWith.Count == 0)
        {
            _canInteractWithSomething = false;
        }
    }
    private void UI_PlayerInteraction()
    {
        _interactWindow.SetActive(_canInteractWithSomething);
    }

    private void PlayerInteraction()
    {
        if(Input.GetKeyDown(KeyCode.E) && _objectsToInteractWith.Count>0) 
        {
            _objectsToInteractWith.First().GetComponent<Interactable>().Interact();
            ClearAfterInteraction();
            return;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.TryGetComponent(out Interactable _) && _capsuleCollider.enabled == true)
        {
            _objectsToInteractWith.Add(other.gameObject);
            if (!_canInteractWithSomething)
            {
                _canInteractWithSomething = true;
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        _objectsToInteractWith.Remove(other.gameObject);
        if (_objectsToInteractWith.Count == 0)
        {
            _canInteractWithSomething = false;
        }

    }
}
