using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
namespace TD
{
    public class soldier_ai : MonoBehaviour
    {
        public Transform destination;
        //public Vector3 offset;
        public Transform target;
        public float speed=10f;
        public float atkspd=2f;
        public float turnspeed=10f;
        public float range=10f;
        public string enemyTag="Enemy";
        public health_bar bar;
        public float health;
        public float maxhealth=10;
        public float armor;
        public float magic_resist;
        public bool death=false;
        public int attack_type=1;
        public float attack_range=1f;
        public float atk=1;
        public Animator anim;
        public NavMeshAgent agent;
        public ParticleSystem blood;
        public float atk_spd_lv1=0.1f;
        public float atk_spd_lv2=0.1f;
        public float atk_spd_lv3=0.1f;
        public float atk_up1=1.5f;
        public float atk_up2=1.5f;
        public float atk_up3=1.5f;
        public AudioSource hit;
        //public soldier_spawner spawn_script;
        // Start is called before the first frame update
        void Awake()
        {
            //destination=transform.parent.transform;
            Debug.Log("awake");
            switch(Player.skill_2_level)
            {
                case 0:GetComponent<Animator>().SetFloat("speed",atkspd);
                
                break;
                case 1:GetComponent<Animator>().SetFloat("speed",atkspd+atk_spd_lv1);
                atk=atk*atk_up1;
                break;
                case 2:GetComponent<Animator>().SetFloat("speed",atkspd+atk_spd_lv2);
                atk=atk*atk_up2;
                break;
                case 3:GetComponent<Animator>().SetFloat("speed",atkspd+atk_spd_lv3);
                atk=atk*atk_up3;
                break;
            }  
            InvokeRepeating("UpdateTarget",0f,0.5f);
            InvokeRepeating("check_death",0f,0.5f);
            
            bar.SetMaxHealth(maxhealth);
            health=maxhealth;
            anim=GetComponent<Animator>();
            agent=GetComponent<NavMeshAgent>();
            //transform.parent.gameObject.GetComponent<soldier_spawner>().soldier_num++;
        }


        // Update is called once per frame
        void Update()
        {
            if(destination==null)
            {
                return;
            }
            if(death)
            {
                agent.isStopped=true;
                return;
            }
            if(target==null)
            {
                agent.stoppingDistance=0f;
                if(Vector3.Distance(transform.position,destination.position)>=1f)
                {
                    anim.SetBool("move",true);
                    anim.SetBool("attack",false);
                    //Vector3 dir =destination.position-transform.position;
                    //transform.Translate(dir.normalized*speed*Time.deltaTime,Space.World);
                    agent.isStopped=false;
                    agent.destination=destination.position;
                    FaceDestination(destination);
                }
                else
                {
                    anim.SetBool("move",false);
                    anim.SetBool("attack",false);
                }
            }
            else
            {
                
                if(Vector3.Distance(transform.position,target.position)>=attack_range)
                {
                    anim.SetBool("move",true);
                    anim.SetBool("attack",false);
                    //Vector3 dir =target.position-transform.position;
                    //transform.Translate(dir.normalized*speed*Time.deltaTime,Space.World);
                    agent.isStopped=false;
                    agent.destination=target.position;
                    FaceDestination(target);
                }
                else
                {
                    agent.isStopped=true;
                    anim.SetBool("move",false);
                    anim.SetBool("attack",true);
                    change_target();
                    FaceDestination(target);
                }
            }
        }
        void change_target()
        {
            if(target!=null&&target.GetComponent<enemy>().death==true)
			{
                GameObject[]enemies= GameObject.FindGameObjectsWithTag(enemyTag);
				foreach(GameObject enemy in enemies)
				{
					float distanceToEnemy = Vector3.Distance(transform.position,enemy.transform.position);
					if(distanceToEnemy<range&&enemy.GetComponent<enemy>().death!=true)
					{
						target=enemy.transform;
                        target.GetComponent<enemy>().battletarget.Add(this.gameObject);
                        target.GetComponent<enemy>().battle=true;
						// GetComponent<release_arc>().target_place=target;
						// GetComponent<Animator>().SetBool("shoot",true);
						break;
					} 
				}	
			}
        }
        public void UpdateTarget()
        {
            GameObject[]enemies= GameObject.FindGameObjectsWithTag(enemyTag);
            float shortestDistance= Mathf.Infinity;
            GameObject nearestEnmy=null;
            foreach(GameObject enemy in enemies)
            {
                float distanceToEnemy = Vector3.Distance(transform.position,enemy.transform.position);
                if(distanceToEnemy<shortestDistance)
                {
                    shortestDistance=distanceToEnemy;
                    nearestEnmy=enemy;
                } 
            }
            if(target==null&&nearestEnmy!=null&& shortestDistance<=range)
            {
                target=nearestEnmy.transform;
                target.GetComponent<enemy>().battletarget.Add(this.gameObject);
                target.GetComponent<enemy>().battle=true;
            }
            if(target!=null&&Vector3.Distance(target.position,transform.position)>=range)
            {
                target=null;
            }
            //else{target=null;}
        }
        public void movement(Transform t)
        {
            if(Vector3.Distance(transform.position,t.position)>=0.5f)
            {
                anim.SetBool("move",true);
                Vector3 dir =t.position-transform.position;
                transform.Translate(dir.normalized*speed*Time.deltaTime,Space.World);
                FaceDestination(t);
            }
            else{anim.SetBool("move",false);}
        }
        public void FaceDestination(Transform t)
        {
            Vector3 dir =t.position-transform.position;
            Quaternion lookRotation = Quaternion.LookRotation(dir);
            Vector3 rotation =Quaternion.Lerp(transform.rotation,lookRotation,Time.deltaTime*turnspeed).eulerAngles;
            transform.rotation=Quaternion.Euler(0f,rotation.y,0f);
        }
        public void takedamage(float amount,int damage_type)
        {
            switch (damage_type)
            {
                case 1:
                    health=health-amount*(1f-0.01f*armor);
                    break;
                case 2:
                    health=health-amount*(1f-0.01f*magic_resist);

                    break;
                case 3:
                    health=health-amount;

                    break;
            }
            bar.SetHealth(health);
            blood.Play();
            anim.SetFloat("damage",0.015f);
        }
        public void check_death()
        {
            if(health<=0)
            {
                if(!death)
                {
                StartCoroutine(dead(2));
                }
            }
            else{return;}
        }
        public IEnumerator dead(float delay)
        {
            //add gold to player
            death=true;
            if(!anim.GetBool("die"))
            {
                anim.SetBool("die",true);
            }
            yield return new WaitForSeconds(delay);
            //Destroy(this.gameObject);
            //transform.parent.gameObject.GetComponent<soldier_spawner>().soldier_num--;
            Destroy(this.gameObject);
        }
        public void deal_damage()
        {
            if(target!=null)
            {
                hit.Play();
                target.GetComponent<enemy>().takedamage(atk,attack_type);
            }
        }
        
        // public void death()
        // {
            
        //     this.gameObject.SetActive(false);
        // }
        
    }
}
