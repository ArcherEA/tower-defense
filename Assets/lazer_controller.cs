using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace TD
{
    
    public class lazer_controller : MonoBehaviour
    {
        public Transform target;
        public bool launch;
        public ParticleSystem ps;
        public float time_cost;
        public Vector3 targetPos;
        public int attack_type=3;
        public float atk=10;
        public string enemyTag="Enemy";
        public float damage_range=10f;
        public bool stop_particle=false;
        public float turnspeed=10f;
        public Transform character;
        public float atk_up1=1.5f;
        public float atk_up2=1.5f;
        public float atk_up3=1.5f;
        // Start is called before the first frame update
        void Start()
        {
            InvokeRepeating("deal_damage_fire",0.3f,0.5f);
            character=transform.parent.parent.parent.parent.parent.parent.parent.parent.parent.parent.parent;
            switch(Player.skill_3_level)
            {
                case 0:
                break;
                case 1:;
                atk=atk*atk_up1;
                break;
                case 2:
                atk=atk*atk_up2;
                break;
                case 3:
                atk=atk*atk_up3;
                break;
            }  
        }

        // Update is called once per frame
        void Update()
        {
            
            if(target!=null)
            {
                targetPos=target.position;
            }
            else
            {
                character.GetComponent<Animator>().SetBool("shoot",false);
                Destroy(this.gameObject);
            }
            if(launch)
            {
                rotation();
                if(!ps.isPlaying&&target!=null)
                {
                    ps.Play();                
                }
                if(character.GetComponent<release_arc>().spellready==false)//character.GetComponent<Animator>().GetBool("shoot")==false)
                {
                    Destroy(this.gameObject);
                }
            }
            
        }
        void deal_damage_fire()
        {   
            GameObject[] enemies= GameObject.FindGameObjectsWithTag(enemyTag);
            if(target!=null)
            {
                target.GetComponent<enemy>().takedamage(atk,attack_type);
                foreach(GameObject enemy in enemies)
                {
                    float distanceToEnemy = Vector3.Distance(target.position,enemy.transform.position);
                    if(distanceToEnemy<damage_range)
                    {
                        enemy.GetComponent<enemy>().takedamage(0.8f*atk,attack_type);
                    } 
                }

            }
            else
            {
                foreach(GameObject enemy in enemies)
                {
                    float distanceToEnemy = Vector3.Distance(targetPos,enemy.transform.position);
                    if(distanceToEnemy<damage_range)
                    {
                        enemy.GetComponent<enemy>().takedamage(0.8f*atk,attack_type);
                    } 
                }
            }

        }
        public void deal_damage()
        {   
            GameObject[] enemies= GameObject.FindGameObjectsWithTag(enemyTag);
            if(target!=null)
            {
                target.GetComponent<enemy>().takedamage(atk,attack_type);
            }
            else
            {
                
            }

        }
        public void rotation()
        {
            if(target!=null)
            {
                Vector3 dir =target.position-transform.position;
                Quaternion lookRotation = Quaternion.LookRotation(dir);
                Vector3 rotation =Quaternion.Lerp(transform.rotation,lookRotation,Time.deltaTime*turnspeed).eulerAngles;
                transform.rotation=Quaternion.Euler(rotation);
                //transform.rotation = Quaternion.LookRotation(target.transform.position - transform.position);
                
            }
            else
            {
                Vector3 dir =targetPos-transform.position;
                Quaternion lookRotation = Quaternion.LookRotation(dir);
                Vector3 rotation =Quaternion.Lerp(transform.rotation,lookRotation,Time.deltaTime*turnspeed).eulerAngles;
                transform.rotation=Quaternion.Euler(rotation);
                //transform.rotation = Quaternion.LookRotation(targetPos - transform.position);
            }
        }
    }
}