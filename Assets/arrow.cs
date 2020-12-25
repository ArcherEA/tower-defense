using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace TD
{
    public class arrow : MonoBehaviour
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
        public Transform targetPos;
        Vector3 targetposition;
        public GameObject particle;
        public float anim_1;
        public float max=5f;
        public int attack_type=1;
        public float atk=1;
        public float atk_up1=1.5f;
        public float atk_up2=1.5f;
        public float atk_up3=1.5f;
        public AudioSource hit;
        //public AudioSource arrow_lanuch;
        void Awake() {
            // Cache our start position, which is really the only thing we need
            // (in addition to our current position, and the target).
            switch(Player.skill_1_level)
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
            if(targetPos!=null)
            {
                targetposition=targetPos.position;
            }
            if(launch){
                //Debug.Log("true ball");
                anim_1+=4*Time.deltaTime;
                float i=anim_1/max;
                anim_1 = anim_1 % max;
                if(i<=1)
                {   
                    Vector3 POS;
                    if(targetPos!=null)
                    {
                        POS=MathParabola.Parabola(startPos,targetPos.position,arcHeight,anim_1/max);
                    }
                    else{Destroy(this.gameObject);POS=MathParabola.Parabola(startPos,targetposition,arcHeight,anim_1/max);}
                    transform.rotation = Quaternion.LookRotation(POS - transform.position);
                    transform.position =POS;
                }
                else
                {
                    if(targetPos!=null)
                    {
                        hit.Play();
                        //take damage
                        deal_damage();
                        Destroy(this.gameObject);
                    }
                    //GameObject newparticle=Instantiate(particle,transform.position,Quaternion.identity);
                    Destroy(this.gameObject);
                }
            }
            void deal_damage()
            {
                targetPos.GetComponent<enemy>().takedamage(atk,attack_type);
            }
            // Quaternion LookAt2D(Vector3 forward) 
            // {
            //     return Quaternion.Euler( Mathf.Atan2(forward.y, forward.z) * Mathf.Rad2Deg,transform.rotation.y,Mathf.Atan2(forward.y, forward.x) * Mathf.Rad2Deg);
            // //Mathf.Atan2(forward.y, forward.z) * Mathf.Rad2Deg, Mathf.Atan2(forward.x, forward.z) * Mathf.Rad2Deg
            // }
            

        }
    
        
    }
}