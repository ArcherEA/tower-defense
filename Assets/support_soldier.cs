using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
namespace TD
{
    public class support_soldier : soldier_ai
    {
        public bool sup_soldier=true;
        public float health_improvelv1=2f;
        public float health_improvelv2=3f;
        public float health_improvelv3=4f;
        public float armor_improvelv1=10f;
        public float armor_improvelv2=20f;
        public float armor_improvelv3=30f;
        public float mr_improvelv1=10f;
        public float mr_improvelv2=20f;
        public float mr_improvelv3=30f;
        
        //public soldier_spawner spawn_script;
        // Start is called before the first frame update
        void Awake()
        {
            anim=GetComponent<Animator>();
            //destination=transform.parent.transform;
            Debug.Log("awake");
            InvokeRepeating("UpdateTarget",0f,0.5f);
            InvokeRepeating("check_death",0f,0.5f);
            switch(Player.skill_5_level)
            {
                case 0:GetComponent<Animator>().SetFloat("speed",1f);
                break;
                case 1:GetComponent<Animator>().SetFloat("speed",1f+atk_spd_lv1);
                atk=atk*atk_up1;
                maxhealth=maxhealth*health_improvelv1;
                armor=armor+armor_improvelv1;
                magic_resist=magic_resist+mr_improvelv1;
                break;
                case 2:GetComponent<Animator>().SetFloat("speed",1f+atk_spd_lv2);
                atk=atk*atk_up2;
                maxhealth=maxhealth*health_improvelv2;
                armor=armor+armor_improvelv2;
                magic_resist=magic_resist+mr_improvelv2;
                break;
                case 3:GetComponent<Animator>().SetFloat("speed",1f+atk_spd_lv3);
                atk=atk*atk_up3;
                maxhealth=maxhealth*health_improvelv3;
                armor=armor+armor_improvelv3;
                magic_resist=magic_resist+mr_improvelv3;
                break;
            }
            bar.SetMaxHealth(maxhealth);
            health=maxhealth;
            
            agent=GetComponent<NavMeshAgent>();
            //transform.parent.gameObject.GetComponent<soldier_spawner>().soldier_num++;
        }

        // Update is called once per frame
        void Update()
        {   if(!sup_soldier&&destination==null)
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
                if(sup_soldier)
                {
                    anim.SetBool("move",false);
                    anim.SetBool("attack",false);
                }
                else
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
                    FaceDestination(target);
                }
            }
        }
    }
}