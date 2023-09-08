using System.Collections.Generic;
using UnityEngine;

namespace RPG
{
    public enum ChestQuality
    {
        Base,
        Common,
        Rare,
        Precious,
        Luxurious
    }

    public class BaseChest : Interactable
    {
        [SerializeField] protected ChestQuality _chestQuality = ChestQuality.Base;
        [SerializeField] protected List<Item> items = new List<Item>();
        [SerializeField] protected int _expAmount;

        public override void Interact()
        {
            foreach (var item in items)
            {
                item.Interact();
            }

            GameManagerContainer.Instance.GetPlayer().GetComponent<PlayerAttributes>().AddExperience(_expAmount);
            DestroySelf();
        }
    }
}

