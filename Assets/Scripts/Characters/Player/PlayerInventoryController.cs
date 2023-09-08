using RPG;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Windows;

public class PlayerInventoryController : MonoBehaviour
{
    [Header("Inventory System")]
    [SerializeField] private Inventory _playerInventory;
    [SerializeField] private float _inventoryInput;
    [SerializeField] private bool _isInventoryOpen = false;

    [Header("UI")]
    [SerializeField] private UI_Inventory _playerUIInventory;

    private void Start()
    {
        _playerInventory = new Inventory();
        _playerUIInventory.SetInventory(_playerInventory);
    }

    private void Update()
    {
        OpenInventory();
    }

    public void OnOpenInventory(InputValue input)
    {
        _inventoryInput = input.Get<float>();

        if (_inventoryInput != 0)
        {
            if (_isInventoryOpen)
            {
                _isInventoryOpen = false; 
                return;
            }
            _isInventoryOpen = true;
        }
    }

    public Inventory GetPlayerInventory()
    {
        return _playerInventory;
    }

    private void OpenInventory()
    {
        _playerUIInventory.SetActive(_isInventoryOpen);
    }
}
