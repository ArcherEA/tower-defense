using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace TD
{

    public class ball : MonoBehaviour
    {
        //[Tooltip("Position we want to hit")]
        //public GameObject target;
        
        //[Tooltip("Horizontal speed, in units/sec")]
        //public float speed = 10;
        
        [Tooltip("How high the arc should be, in units")]
        public float arcHeight = 11f;
        public float turnspeed = 11f;
        public bool launch=false;
        Vector3 startPos;
        public Vector3 targetPos;
        public GameObject particle;
        public float animation;
        public float max=5f;
        public int attack_type=3;
        public float atk=10;
        public string enemyTag="Enemy";
        public float damage_range=5f;
        public float atk_up1=1.5f;
        public float atk_up2=1.5f;
        public float atk_up3=1.5f;
        // public AudioSource boom;
        void Awake() {
            // Cache our start position, which is really the only thing we need
            // (in addition to our current position, and the target).
            switch(Player.skill_4_level)
            {
                case 0:atk=atk;
                break;
                case 1:atk=atk_up1*atk;
                break;
                case 2:atk=atk_up2*atk;
                break;
                case 3:atk=atk_up3*atk;
                break;
            }
            startPos = transform.position;
            //Debug.Log("create ball");
            //targetPos = target.transform.position;
        }
        
        void Update() {
            // Compute the next position, with arc added in
            if(launch){
                //Debug.Log("true ball");
                animation+=2*Time.deltaTime;
                float i=animation/max;
            
                
                animation = animation % max;
                if(i<=1)
                {   
                    Vector3 POS=MathParabola.Parabola(startPos,targetPos,arcHeight,animation/max);
                    transform.rotation = Quaternion.LookRotation(POS - transform.position);
                    transform.position =POS;
                }
                else
                {
                    GameObject newparticle=Instantiate(particle,transform.position,Quaternion.identity);
                    deal_damage();
                    // boom.Play();
                    Destroy(this.gameObject);
                }
            }
            void deal_damage()
            {
                GameObject[] enemies= GameObject.FindGameObjectsWithTag(enemyTag);
                foreach(GameObject enemy in enemies)
                {
                    float distanceToEnemy = Vector3.Distance(transform.position,enemy.transform.position);
                    if(distanceToEnemy<damage_range)
                    {
                        enemy.GetComponent<enemy>().takedamage(atk,attack_type);
                    } 
                }
            }
            // Quaternion LookAt2D(Vector3 forward) 
            // {
            //     return Quaternion.Euler( Mathf.Atan2(forward.y, forward.z) * Mathf.Rad2Deg,transform.rotation.y,Mathf.Atan2(forward.y, forward.x) * Mathf.Rad2Deg);
            // //Mathf.Atan2(forward.y, forward.z) * Mathf.Rad2Deg, Mathf.Atan2(forward.x, forward.z) * Mathf.Rad2Deg
            // }
            

        }
    
        
    }
}
