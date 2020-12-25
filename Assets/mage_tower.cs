using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace TD
{
    public class mage_tower : tower
    {
		public float atk_spd_lv1=0.1f;
        public float atk_spd_lv2=0.1f;
        public float atk_spd_lv3=0.1f;
		public float atkspd=1f;
		
         // Start is called before the first frame update
        void Awake()
        {
            InvokeRepeating("UpdateTarget",0f,0.5f);
			switch(Player.skill_3_level)
            {
                case 0:partToRotate.GetComponent<Animator>().SetFloat("speed",atkspd);
                
				break;
                case 1:partToRotate.GetComponent<Animator>().SetFloat("speed",atkspd+atk_spd_lv1);
                
				break;
                case 2:partToRotate.GetComponent<Animator>().SetFloat("speed",atkspd+atk_spd_lv2);
                
				break;
                case 3:partToRotate.GetComponent<Animator>().SetFloat("speed",atkspd+atk_spd_lv3);
                
				break;
            }  
        }

        // Update is called once per frame
        void Update()
        {
            if(target==null)
            {
				partToRotate.GetComponent<Animator>().SetBool("shoot",false);
				return;
			}
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
				//partToRotate.GetComponent<Animator>().SetBool("shoot",true);
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
				partToRotate.GetComponent<release_arc>().target_place=target;
				partToRotate.GetComponent<Animator>().SetBool("shoot",true);
			}
			else{
				target=null;
				partToRotate.GetComponent<Animator>().SetBool("shoot",false);
				partToRotate.GetComponent<release_arc>().target_place=null;
				}
			}
			else
			{
				partToRotate.GetComponent<Animator>().SetBool("shoot",true);
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
						partToRotate.GetComponent<release_arc>().target_place=target;
						partToRotate.GetComponent<Animator>().SetBool("shoot",true);
						break;
					} 
				}	
			}
        }
    }
}