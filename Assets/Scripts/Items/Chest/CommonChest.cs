using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RPG
{
    public class CommonChest : BaseChest
    {
        private void Start()
        {
            _chestQuality = ChestQuality.Common;
            _expAmount = SetExperienceAmount();
        }


        private int SetExperienceAmount()
        {
            return Random.Range(5,10);
        }

    }
}

