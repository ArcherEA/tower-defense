using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace TD
{
    

    public class tower : MonoBehaviour
    {
        [Header("TOWER BASIC PROPERTIES")]
        public Transform target;
        public Transform partToRotate;
        public float range=15f;
        public float turnspeed=10f;
        public string enemyTag="Enemy";
        public GameObject next_tower;
        //public GameObject preview_tower;
        public GameObject construct;
        public GameObject show_range;
        public int type; //0:build_point 1:soldier_tower 2:others
        //public Material fadeMat;
        private GameObject preview_tower;
        
        public int value;
        public int levelup_cost;
        // Start is called before the first frame update
        void Awake()
        {
            Setrangescale();
        }

        // Update is called once per frame
        void Update()
        {
        
        }
        
        void OnDrawGizmosSelected()
        {
            Gizmos.color=Color.red;
            Gizmos.DrawWireSphere(transform.position,range);
        }
        public void FaceMonster()
        {
            if(target!=null)
            {
                Vector3 dir =target.position-partToRotate.position;
                Quaternion lookRotation = Quaternion.LookRotation(dir);
                Vector3 rotation =Quaternion.Lerp(partToRotate.rotation,lookRotation,Time.deltaTime*turnspeed).eulerAngles;
                partToRotate.rotation=Quaternion.Euler(0f,rotation.y,0f);
            }
        }
        public virtual void levelup()
        {
            if(next_tower!=null)
            {
                GameObject newconstruct=Instantiate(construct,transform.position,transform.rotation,transform.parent);
                Destroy(this.gameObject);
            }
        }
        public virtual void preview_next_tower()
        {
            if(next_tower!=null)
            {
                GameObject newnext_tower=Instantiate(next_tower,transform.position,transform.rotation,transform.parent);
                preview_tower=newnext_tower;
                // newnext_tower.GetComponent<MeshRenderer>().material=fadeMat;
                // newnext_tower.GetComponent<tower>().show_range.SetActive(true);
                //newnext_tower.GetComponent<tower>().enabled = false;
            }
        }
        public virtual void cancel_preview_next_tower()
        {
            Destroy(preview_tower);
        }
        public void showrange()
        {
            Setrangescale();
            show_range.SetActive(true);
        }
        public void closerange()
        {
            show_range.SetActive(false);
        }
        public void Setrangescale()
        {
            show_range.transform.localScale=new Vector3(2f*range,0.01f,2f*range);
        }
    }
}