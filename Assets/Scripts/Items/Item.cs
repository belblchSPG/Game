using UnityEngine;
namespace RPG
{
    public enum ItemType
    {
        Deafault,
        Food,
        Money,
    }

    
    public class Item : Interactable
    {
        [SerializeField] protected ItemType _itemType;
        [SerializeField] protected string _itemName;
        [SerializeField] protected string _itemDescription;
        [SerializeField] protected int _itemAmount = 1;
        [SerializeField] protected int _itemMaxAmount;
        [SerializeField] protected Sprite _itemSprite;
        private GameObject _playerDetection;
        public Sprite GetSprite()
        {
            switch (_itemType) 
            { 
                default: return null;
                    case ItemType.Food: return ItemAsset.Instance.FoodSprite;
            }
        }
        public bool isStakcable()
        {
            if(_itemMaxAmount > 1)
            {
                return true;
            }
            return false;
        }
        public int GetItemAmount()
        {
            return _itemAmount;
        }
        public void IncreaseItemAmount(int amount)
        {
            _itemAmount += amount;
        }
        public ItemType GetItemType()
        {
            return _itemType;
        }
        public string GetItemName()
        {
            return _itemName;
        }

        public override void Interact()
        {
            GameManagerContainer.Instance.GetPlayer().GetComponent<PlayerInventoryController>().GetPlayerInventory().AddItem(this);
            DestroySelf();
        }

        private void OnTriggerEnter(Collider other)
        {
            if(other.GetComponent<PlayerController>())
            {
                _playerDetection = other.gameObject;
            }
        }
    }
}

