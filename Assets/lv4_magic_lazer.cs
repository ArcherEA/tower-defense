using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace TD
{
    
    public class lv4_magic_lazer : lazer_controller
    {   
        // Start is called before the first frame update
        void Start()
        {
            InvokeRepeating("deal_damage",0f,0.5f);
            character=transform.parent.parent.parent.parent.parent.parent.parent.parent.parent.parent.parent;
            switch(Player.skill_3_level)
            {
                case 0:atk=atk*1f;
                break;
                case 1:
                atk=atk*atk_up1;
                break;
                case 2:
                atk=atk*atk_up2;
                break;
                case 3:
                atk=atk*atk_up3;
                break;
            } 
        }

        // Update is called once per frame
        void Update()
        {
            if(target!=null)
            {
                targetPos=target.position;
            }
            else
            {
                character.GetComponent<Animator>().SetBool("shoot",false);
                Destroy(this.gameObject);
            }
            change_target();
            if(launch)
            {
                rotation();
                if(!ps.isPlaying)
                {
                    ps.Play();                
                }
                if(character.GetComponent<Animator>().GetBool("shoot")==false)
                {
                    Destroy(this.gameObject);
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
					float distanceToEnemy = Vector3.Distance(target.position,enemy.transform.position);
					if(distanceToEnemy<10f&&enemy.GetComponent<enemy>().death!=true)
					{
						target=enemy.transform;
						break;
					} 
				}
			}
        }
        
       
    }
}