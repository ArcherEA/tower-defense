using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace TD
{

    public class fire_ball_magic : MonoBehaviour
    {
        [Tooltip("How high the arc should be, in units")]
        public float arcHeight = 11f;
        public float turnspeed = 11f;
        public bool launch=false;
        Vector3 startPos;
        public Transform targetPos;
        Vector3 targetposition;
        public GameObject particle;
        public float animation;
        public float max=5f;
        public int attack_type=2;
        public float atk=10f;
        public string enemyTag="Enemy";
        public float damage_range=5f;
        public float atk_up1=1.5f;
        public float atk_up2=1.5f;
        public float atk_up3=1.5f;
        public float range_up1=1.5f;
        public float range_up2=1.5f;
        public float range_up3=1.5f;
        
        void Awake() {
            // Cache our start position, which is really the only thing we need
            // (in addition to our current position, and the target).
            switch(Player.skill_3_level)
            {
                case 0:atk=atk*1f;
                break;
                case 1:atk=atk_up1*atk;
                //damage_range=range_up1*damage_range;
                break;
                case 2:
                atk=atk_up2*atk;
                //damage_range=range_up2*damage_range;
                break;
                case 3:
                atk=atk_up3*atk;
                //damage_range=range_up3*damage_range;
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
                animation+=4*Time.deltaTime;
                float i=animation/max;
                animation = animation % max;
                if(i<=1&&targetPos!=null)
                {   
                    Vector3 POS;
                    if(targetPos!=null)
                    {
                        POS=MathParabola.Parabola(startPos,targetPos.position,arcHeight,animation/max);
                    }
                    else{POS=MathParabola.Parabola(startPos,targetposition,arcHeight,animation/max);}
                    transform.rotation = Quaternion.LookRotation(POS - transform.position);
                    transform.position =POS;
                }
                else
                {
                    if(targetPos!=null)
                    {
                        //take damage
                        GameObject newparticle=Instantiate(particle,transform.position,Quaternion.identity);
                        deal_damage();
                        Destroy(this.gameObject);
                    }
                    else
                    {
                        GameObject newparticle1=Instantiate(particle,transform.position,Quaternion.identity);
                        Destroy(this.gameObject);
                    }
                }
            }
        }
        void deal_damage()
        {
            targetPos.GetComponent<enemy>().takedamage(atk,attack_type);
        }
    }
}