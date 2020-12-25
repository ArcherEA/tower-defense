using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
namespace TD
{
    

    public class enemy : MonoBehaviour
    {
        public float speed=10f;
        public float turnspeed=10f;
        private Transform wptarget;
        
        private int waypointIndex = 0;
        public bool battle=false;
        public List<GameObject> battletarget;
        public float health;
        public float maxhealth=10;
        public int gold_value=10;
        public health_bar bar;
        public Animator anim;
        public float armor;
        public float magic_resist;
        public bool death=false;
        public int attack_type=1;
        public float attack_range=1f;
        public float atk=1;
        private NavMeshAgent agent;
        private int choose_road;
        public bool multiroad=false;
        private int attacking_object_num=0;
        public ParticleSystem blood;
        public ParticleSystem money;
        public GameObject spell;
        public GameObject healspell;
        public float healamount=10f;
        public bool mageenemy=false;
        public int hurt=1;
        public AudioSource hit;
        //private bool lastwaypoint=false;
        // Start is called before the first frame update
        void Awake()
        {
            if(multiroad)
            {
                if(Random.value<0.5f)
                {
                    choose_road=0;
                    wptarget=waypoints.points[0];
                }
                else
                {
                    choose_road=1;
                    wptarget=waypoint2.points[0];
                }
            }
            else
            {
                wptarget=waypoints.points[0];
            }
            
            //wptarget=waypoints.points[0];
            bar.SetMaxHealth(maxhealth);
            health=maxhealth;
            anim=GetComponent<Animator>();
            agent=GetComponent<NavMeshAgent>();
            InvokeRepeating("check_death",0f,0.2f);
            if(mageenemy)
            {
                InvokeRepeating("heal_spell",0f,5f);
            }
            agent.speed=speed;
        }

        // Update is called once per frame
        void Update()
        {
            if(death)
            {
                agent.isStopped=true;
                return;
            }
            if(!battle){
                anim.SetBool("move",true);
                anim.SetBool("attack",false);
                //Vector3 dir =wptarget.position-transform.position;
                agent.stoppingDistance=0f;
                agent.isStopped=false;
                agent.SetDestination(wptarget.position);
                //transform.Translate(dir.normalized*speed*Time.deltaTime,Space.World);
                if(Vector3.Distance(transform.position,wptarget.position)<=1f)
                {
                    GetNextWaypoint();
                }
                FaceWaypoint();
            }
            else
            {
                //int index=0;
               
                for(int i =0;i<battletarget.Count;i++)
                {
                    if(battletarget[i]!=null)
                    {
                        if(Vector3.Distance(battletarget[i].transform.position,transform.position)<attack_range)
                        {
                            agent.isStopped=true;
                            anim.SetBool("move",false);
                            anim.SetBool("attack",true);
                            Facetarget(battletarget[i].transform);
                            attacking_object_num=i;
                        }
                        else
                        {
                            anim.SetBool("move",true);
                            anim.SetBool("attack",false);
                            
                            //Vector3 dir =wptarget.position-transform.position;
                            //transform.Translate(dir.normalized*speed*Time.deltaTime,Space.World);
                            agent.isStopped=false;
                            agent.SetDestination(battletarget[i].transform.position);
                            Facetarget(battletarget[i].transform);
                        }
                        return;
                    }
                }
                battle=false;
                // if(battletarget!=null&&battletarget.GetComponent<soldier_ai>().target==this.transform){
                //     if(Vector3.Distance(battletarget.transform.position,transform.position)<attack_range)
                //     {
                //         agent.isStopped=true;
                //         anim.SetBool("move",false);
                //         anim.SetBool("attack",true);
                //         Facetarget();
                //     }
                //     else
                //     {
                //         anim.SetBool("move",true);
                //         anim.SetBool("attack",false);
                        
                //         //Vector3 dir =wptarget.position-transform.position;
                //         //transform.Translate(dir.normalized*speed*Time.deltaTime,Space.World);
                //         agent.isStopped=false;
                //         agent.SetDestination(wptarget.position);
                //         Facetarget();
                //     }
                // }
                // else{battle=false;}
            }
        }
        void GetNextWaypoint()
        {
            if(multiroad&&choose_road==1)
            {
                if(waypointIndex>=waypoint2.points.Length-1)
                {
                    //deal damage to player
                    if(!death)
                    {
                        Player_status.player_health-=hurt;
                        wave_spawner.active_enemy_amount--;
                        Destroy(gameObject);
                        return;
                    }
                    // Player_status.player_health-=hurt;
                    // wave_spawner.active_enemy_amount--;
                    // Destroy(gameObject);
                    return;
                }
                waypointIndex++;
                wptarget=waypoint2.points[waypointIndex];
            }
            else
            {
                if(waypointIndex>=waypoints.points.Length-1)
                {
                    //deal damage to player
                    if(!death)
                    {
                        Player_status.player_health-=hurt;
                        wave_spawner.active_enemy_amount--;
                        Destroy(gameObject);
                        return;
                    }
                    // Player_status.player_health-=hurt;

                    // wave_spawner.active_enemy_amount--;
                    // Destroy(gameObject);
                    return;
                }
                waypointIndex++;
                wptarget=waypoints.points[waypointIndex];
            }
        }
        void FaceWaypoint()
        {
            Vector3 dir =wptarget.position-transform.position;
            Quaternion lookRotation = Quaternion.LookRotation(dir);
            Vector3 rotation =Quaternion.Lerp(transform.rotation,lookRotation,Time.deltaTime*turnspeed).eulerAngles;
            transform.rotation=Quaternion.Euler(0f,rotation.y,0f);
        }
        void Facetarget(Transform t)
        {
            Vector3 dir =t.transform.position-transform.position;
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
        void check_death()
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
            money.Play();
            Player_status.money+=gold_value;
            death=true;
            agent.speed=0;
            if(!anim.GetBool("die"))
            {
                anim.SetBool("die",true);
            }
            yield return new WaitForSeconds(delay);
            wave_spawner.active_enemy_amount--;
            Destroy(this.gameObject);
        }
        public void heal_spell()
        {
            if(death==false)
            {
                anim.SetBool("heal",true);
            }
        }
        public void disable_heal_spell()
        {
            anim.SetBool("heal",false);
        }
        public void heal()
        {
            GameObject[]enemies= GameObject.FindGameObjectsWithTag("Enemy");
            foreach(GameObject enemy in enemies)
            {
                float distanceToEnemy = Vector3.Distance(transform.position,enemy.transform.position);
                if(distanceToEnemy<10f&&enemy.GetComponent<enemy>().death!=true)
                {
                    enemy.GetComponent<enemy>().getheal(healamount);
                } 
            }

        }
        public void getheal(float amount)
        {
            healspell.GetComponent<ParticleSystem>().Play();
            if(health+amount>maxhealth)
            {
                health=maxhealth;
                bar.SetHealth(health);
            }
            else
            {
                health+=amount;
                bar.SetHealth(health);
            }
        }
        public void castspell()
        {
            if(battletarget[attacking_object_num]!=null)
            {
                GameObject newspell=Instantiate(spell,battletarget[attacking_object_num].transform.position,Quaternion.identity);
                battletarget[attacking_object_num].GetComponent<soldier_ai>().takedamage(atk,attack_type);
            }
        }
        public void deal_damage()
        {
            if(battletarget[attacking_object_num]!=null)
            {
                hit.Play();
                battletarget[attacking_object_num].GetComponent<soldier_ai>().takedamage(atk,attack_type);
            }
        }
    }
}