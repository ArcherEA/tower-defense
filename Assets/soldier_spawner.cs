using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace TD
{
    
    public class soldier_spawner : MonoBehaviour
    {
        public Transform spawn_place;
        public int soldier_storage=0;
        public int soldier_num;
        public GameObject soldier;
        private float cooldown;
        public float cooldownsec=30f;
        private GameObject soldier_spawned;
        // Start is called before the first frame update
        void Start()
        {
            soldier_storage=1;
            soldier_num=0;
            cooldown=cooldownsec;
            //InvokeRepeating("Startcooldown",0f,1f);
        }

        // Update is called once per frame
        void Update()
        {
            if(soldier_spawned)
            {
                soldier_num=1;
            }
            else
            {
            soldier_num=0; 
            }
            if(soldier_storage<1)
            {
                Startcooldown();
            }
            if(soldier_num<1&&soldier_storage>0)
            {
                spawnsoldier();
            }
        }
        void Startcooldown()
        {
            if(cooldown<=0)
            {
                soldier_storage++;
                cooldown=cooldownsec;
            }
            else
            {
                cooldown=cooldown-Time.deltaTime;
            }
        }
        void spawnsoldier()
        {
            GameObject newsoldier=Instantiate(soldier,spawn_place.position,spawn_place.rotation,this.transform.parent.parent);
            newsoldier.GetComponent<soldier_ai>().destination=this.transform;
            soldier_spawned=newsoldier;
            //soldier_num++;
            soldier_storage--;
            // for(int i=0;i<3;i++)
            // {
            //     if(!soldiers[i].activeSelf&&soldier_storage>0)
            //     {
            //         soldiers[i].SetActive(true);
            //         soldiers[i].transform.position=spawn_place.position;
            //         soldiers[i].transform.rotation=spawn_place.rotation;
            //         soldiers[i].GetComponent<soldier_ai>().bar.SetMaxHealth(soldiers[i].GetComponent<soldier_ai>().maxhealth);
            //         soldiers[i].GetComponent<soldier_ai>().health=soldiers[i].GetComponent<soldier_ai>().maxhealth;
            //         soldier_storage--;
            //     }
            // }
        }
    }
}
