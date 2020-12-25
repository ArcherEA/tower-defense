using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace TD
{
    public class build_point : tower
    {
        public GameObject archer_tower;
        public GameObject soldier_tower;
        public GameObject canon_tower;
        public GameObject mage_tower;
        public GameObject archer_construct;
        public GameObject soldier_construct;
        public GameObject canon_construct;
        public GameObject mage_construct;
        public int mage_cost;
        public int archer_cost;
        public int soldier_cost;
        public int canon_cost;
        // Start is called before the first frame update
        void Start()
        {
            
        }

        // Update is called once per frame
        void Update()
        {
            
        }
        public void choose_next_tower(int type)
        {
            switch (type)
            {
                case 1:
                    next_tower=soldier_tower;
                    construct=soldier_construct;
                    break;
                case 2:
                    next_tower=archer_tower;
                    construct=archer_construct;
                    break;
                case 3:
                    next_tower=mage_tower;
                    construct=mage_construct;
                    break;
                case 4:
                    next_tower=canon_tower;
                    construct=canon_construct;
                    break;
            }
        }
        public void mage_levelup_cost()
        {
            levelup_cost=mage_cost;
        }
        public void archer_levelup_cost()
        {
            levelup_cost=archer_cost;
        }
        public void soldier_levelup_cost()
        {
            levelup_cost=soldier_cost;
        }
        public void canon_levelup_cost()
        {
            levelup_cost=canon_cost;
        }
    }
}
