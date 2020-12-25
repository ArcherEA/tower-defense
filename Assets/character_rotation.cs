using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace TD
{
    public class character_rotation : MonoBehaviour
    {
        public string enemyTag="Enemy";
        public float range=15f;
        public float turnspeed=10f;
        public Transform target;
        public float atk_spd_lv1=0.1f;
        public float atk_spd_lv2=0.1f;
        public float atk_spd_lv3=0.1f;
        public float atkspd=1f;
        // Start is called before the first frame update
        void Awake()
        {
            InvokeRepeating("UpdateTarget",0f,0.5f);
            switch(Player.skill_1_level)
            {
                case 0:GetComponent<Animator>().SetFloat("speed",atkspd);
                break;
                case 1:GetComponent<Animator>().SetFloat("speed",atkspd+atk_spd_lv1);
                break;
                case 2:GetComponent<Animator>().SetFloat("speed",atkspd+atk_spd_lv2);
                break;
                case 3:GetComponent<Animator>().SetFloat("speed",atkspd+atk_spd_lv3);
                break;
            }  
        }
        // Update is called once per frame
        void Update()
        {
           if(target==null)
            {return;}
            change_target();
            FaceMonster(); 
        }
        public void UpdateTarget()
        {
            GameObject[]enemies= GameObject.FindGameObjectsWithTag(enemyTag);
            float shortestDistance= Mathf.Infinity;
            GameObject nearestEnmy=null;
            if(target==null||Vector3.Distance(transform.position,target.position)>range)
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
                    target=nearestEnmy.transform;
                    GetComponent<release_arc>().target_place=target;
                    GetComponent<Animator>().SetBool("shoot",true);
                }
                else{
                    target=null;
                    GetComponent<Animator>().SetBool("shoot",false);
                    GetComponent<release_arc>().target_place=null;
                    }
            }
        }
        public void FaceMonster()
        {
            Vector3 dir =target.position-transform.position;
            Quaternion lookRotation = Quaternion.LookRotation(dir);
            Vector3 rotation =Quaternion.Lerp(transform.rotation,lookRotation,Time.deltaTime*turnspeed).eulerAngles;
            transform.rotation=Quaternion.Euler(0f,rotation.y,0f);
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
						GetComponent<release_arc>().target_place=target;
						GetComponent<Animator>().SetBool("shoot",true);
						break;
					} 
				}	
			}
        }
    }
}
