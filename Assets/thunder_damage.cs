using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace TD
{
    

    public class thunder_damage : MonoBehaviour
    {
        public string enemyTag="Enemy";
        public float range=4f;
        public int attack_type=2;
        public float atk=10;

        public float atk_up1=1.5f;
        public float atk_up2=1.5f;
        public float atk_up3=1.5f;
        // Start is called before the first frame update
        void Start()
        {
            switch(Player.skill_6_level)
            {
                case 0:atk=atk;
                break;
                case 1:atk=atk*atk_up1;
                break;
                case 2:atk=atk*atk_up2;
                break;
                case 3:atk=atk*atk_up3;
                break;
            }
            dealdamage();
            // InvokeRepeating("UpdateTarget",0f,0.5f);
        }

        // Update is called once per frame
        void Update()
        {
            
        }
        void dealdamage()
        {
            GameObject[] enemies= GameObject.FindGameObjectsWithTag(enemyTag);
            foreach(GameObject ene in enemies)
            {
                float distanceToEnemy = Vector3.Distance(transform.position,ene.transform.position);
                if(distanceToEnemy<range)
                {
                    ene.GetComponent<enemy>().takedamage(atk,attack_type);
                } 
            }
        }
    }
}
