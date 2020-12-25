using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace TD
{
    public class canon_launcher : MonoBehaviour
    {
        public bool bullets_ready=true;
        public GameObject target;
        public GameObject bullet;
        public GameObject particle;
        
        public float cooldown;
        public float cooldownsec=6f;
        public float range=15f;
        public float turnspeed=10f;
        public string enemyTag="Enemy";
        public float reduce_cooldown_lv1=0.8f;
        public float reduce_cooldown_lv2=0.6f;
        public float reduce_cooldown_lv3=0.3f;
        // Start is called before the first frame update
        void Start()
        {
            bullets_ready=true;
            
            InvokeRepeating("UpdateTarget",0f,0.5f);
            InvokeRepeating("launching",0f,0.5f);  
            switch(Player.skill_4_level)
            {
                case 0:cooldownsec=cooldownsec;
                break;
                case 1:cooldownsec=cooldownsec*reduce_cooldown_lv1;
                break;
                case 2:cooldownsec=cooldownsec*reduce_cooldown_lv2;
                break;
                case 3:cooldownsec=cooldownsec*reduce_cooldown_lv3;
                break;
            } 
            cooldown=cooldownsec;
        }

        // Update is called once per frame
        void Update()
        {
            if(target==null)
            {return;}
            FaceMonster();
        }
        void launching()
        {
            if(!bullets_ready)
            {
                loadingbullets();
            }
            if(target!=null&&bullets_ready)
            {
                firebullet();
            }
        }
        void firebullet()
        {
            GameObject newbullet=Instantiate(bullet,transform.position,transform.rotation);
            newbullet.GetComponent<ball>().targetPos=target.transform.position;
            newbullet.GetComponent<ball>().launch=true;
            particle.SetActive(true);
            particle.GetComponent<ParticleSystem>().Play();
            bullets_ready=false;
            
        }
        void loadingbullets()
        {
            if(cooldown<=0)
            {
                bullets_ready=true;
                cooldown=cooldownsec;
            }
            else
            {
                cooldown=cooldown-0.5f;
            }
        }
        public  void UpdateTarget()
        {
            GameObject[]enemies= GameObject.FindGameObjectsWithTag(enemyTag);
            float shortestDistance= Mathf.Infinity;
            GameObject nearestEnmy=null;
            if(target==null||Vector3.Distance(transform.position,target.transform.position)>range||target.GetComponent<enemy>().death==true)
            {
                foreach(GameObject enemy in enemies)
                {
                    float distanceToEnemy = Vector3.Distance(transform.position,enemy.transform.position);
                    if(distanceToEnemy<shortestDistance)
                    {
                        shortestDistance=distanceToEnemy;
                        nearestEnmy=enemy;
                    } 
                }
                if(nearestEnmy!=null&&shortestDistance<=range)
                {
                    target=nearestEnmy;
                
                }
                else{target=null;}
            }
        }
        public void FaceMonster()
        {
            Vector3 dir =target.transform.position-transform.position;
            Quaternion lookRotation = Quaternion.LookRotation(dir);
            Vector3 rotation =Quaternion.Lerp(transform.rotation,lookRotation,Time.deltaTime*turnspeed).eulerAngles;
            transform.rotation=Quaternion.Euler(0f,rotation.y,0f);
        }
    }
}
