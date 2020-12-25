using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace TD
{
    public class soldier_tower_manager : tower
    {
        //public GameObject soldierprefab;
        [Header("SOLDIER TOWER PROPERTIES")]
        public Transform spawn_place;
        public int soldier_storage=3;
        public Transform destination;
        public int soldier_num;
        public List<GameObject> soldiers;
        private float cooldown;
        //private float cooldownsec=30f;
        // Start is called before the first frame update
        void Awake()
        {
            // soldier_storage=3;
            // soldier_num=0;
            // cooldown=cooldownsec;
            // //InvokeRepeating("checksoldiernum",0f,1f);
        }

        // Update is called once per frame
        void Update()
        {
            // if(soldier_storage<3)
            // {
            //     Startcooldown();
            // }
            // if(soldier_num<3)
            // {
            //     spawnsoldier();
            // }
            
        }
        // void checksoldiernum()
        // {
        //     int num=0;
        //     for(int i=0;i<3;i++)
        //     {
        //         if(soldiers[i].activeSelf)
        //         {num++;}
        //     }
        //     soldier_num=num;
        // }
        // void Startcooldown()
        // {
        //     if(cooldown<=0)
        //     {
        //         soldier_storage++;
        //         cooldown=cooldownsec;
        //     }
        //     else
        //     {
        //         cooldown=cooldown-Time.deltaTime;
        //     }
        // }
        // void spawnsoldier()
        // {
        //     for(int i=0;i<3;i++)
        //     {
        //         if(!soldiers[i].activeSelf&&soldier_storage>0)
        //         {
        //             soldiers[i].SetActive(true);
        //             soldiers[i].transform.position=spawn_place.position;
        //             soldiers[i].transform.rotation=spawn_place.rotation;
        //             soldiers[i].GetComponent<soldier_ai>().bar.SetMaxHealth(soldiers[i].GetComponent<soldier_ai>().maxhealth);
        //             soldiers[i].GetComponent<soldier_ai>().health=soldiers[i].GetComponent<soldier_ai>().maxhealth;
        //             soldier_storage--;
        //         }
        //     }
        // }
    }
}
