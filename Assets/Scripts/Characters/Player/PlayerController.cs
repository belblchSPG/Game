using UnityEngine;
using RPG;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private PlayerAttributes _playerAttributes;
    [SerializeField] private PlayerInventoryController _playerInventoryController;
    [SerializeField] private PlayerInteractionController _playerInteractionController;
    [SerializeField] private PlayerMovement _playerMovementController;
    [SerializeField] private PlayerAnimationsController _playerAnimatonsController;

    private void Start()
    {
        _playerAttributes = GetComponent<PlayerAttributes>();
        _playerInventoryController = GetComponent<PlayerInventoryController>();
        _playerInteractionController = GetComponent<PlayerInteractionController>();
        _playerMovementController = GetComponent<PlayerMovement>();
        _playerAnimatonsController = GetComponent<PlayerAnimationsController>();
    }
}
