using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TD
{
    public class canon : tower
    {
        
        public bool bullets_ready=true;
        public GameObject bullet;
        public GameObject particle;
        public GameObject spawn_place;
        public float cooldown;
        public float cooldownsec=6f;
        
        // Start is called before the first frame update
        void Awake()
        {
            // bullets_ready=true;
            // cooldown=cooldownsec;
            // InvokeRepeating("UpdateTarget",0f,0.5f);
            // InvokeRepeating("launching",0f,0.5f);
        }

        // Update is called once per frame
        void Update()
        {
            // if(!bullets_ready)
            // {
            //     loadingbullets();
            // }
            // if(target!=null&&bullets_ready)
            // {
            //     firebullet();
            // }

            // if(target==null)
            // {return;}
            // FaceMonster();
        }
        // void launching()
        // {
        //     if(!bullets_ready)
        //     {
        //         loadingbullets();
        //     }
        //     if(target!=null&&bullets_ready)
        //     {
        //         firebullet();
        //     }
        // }
        // void firebullet()
        // {
        //     GameObject newbullet=Instantiate(bullet,spawn_place.transform.position,spawn_place.transform.rotation);
        //     newbullet.GetComponent<ball>().targetPos=target.transform.position;
        //     newbullet.GetComponent<ball>().launch=true;
        //     particle.SetActive(true);
        //     particle.GetComponent<ParticleSystem>().Play();
        //     bullets_ready=false;
            
        // }
        // void loadingbullets()
        // {
        //     if(cooldown<=0)
        //     {
        //         bullets_ready=true;
        //         cooldown=cooldownsec;
        //     }
        //     else
        //     {
        //         cooldown=cooldown-0.5f;
        //     }
        // }

        // public  void UpdateTarget()
        // {
        //     GameObject[]enemies= GameObject.FindGameObjectsWithTag(enemyTag);
        //     float shortestDistance= Mathf.Infinity;
        //     GameObject nearestEnmy=null;
        //     foreach(GameObject enemy in enemies)
        //     {
        //         float distanceToEnemy = Vector3.Distance(transform.position,enemy.transform.position);
        //         if(distanceToEnemy<shortestDistance)
        //         {
        //             shortestDistance=distanceToEnemy;
        //             nearestEnmy=enemy;
        //         } 
        //     }
        //     if(nearestEnmy!=null&&shortestDistance<=range)
        //     {
        //         target=nearestEnmy.transform;
            
        //     }
        //     else{target=null;}
        // }
    }
}
