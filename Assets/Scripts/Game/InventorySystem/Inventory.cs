using System;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

namespace RPG
{
    public class Inventory
    {
        private List<Item> _inventory;
        public event EventHandler OnItemListChanged;

        public Inventory()
        {
            _inventory = new List<Item>();

            Debug.Log(_inventory.Count);
        }

        public void AddItem(Item item)
        { 
            if(item != null)
            {
                if (item.isStakcable())
                {
                    bool itemAlreadyInInventory = false;
                    foreach (Item inventoryItem in _inventory)
                    {
                        if (inventoryItem.GetItemName() == item.GetItemName())
                        {
                            itemAlreadyInInventory = true;
                            inventoryItem.IncreaseItemAmount(item.GetItemAmount());
                        }
                    }
                    if (!itemAlreadyInInventory)
                    {
                        _inventory.Add(item);
                    }
                }
                else
                {
                    _inventory.Add(item);
                }
                OnItemListChanged?.Invoke(this, EventArgs.Empty);
            }
        }

        public List<Item> GetItemList()
        {
            return _inventory;
        }
    }
}


