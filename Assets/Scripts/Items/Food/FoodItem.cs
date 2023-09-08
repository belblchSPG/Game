using UnityEngine;

namespace RPG
{
    public class FoodItem : Item
    {
        [SerializeField] private float _healValue;

        FoodItem()
        {
            _itemType = ItemType.Food;
        }
    }
}
