using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace TD
{
    public class construction : MonoBehaviour
    {
        public float construction_time=3f;
        public float time_cost;
        public loading_bar bar;
        public GameObject next_tower;
        
        // Start is called before the first frame update
        void Awake()
        {
            time_cost=0f;
            bar.SetMaxNum(100);
        }

        // Update is called once per frame
        void Update()
        {
            updatebar();
            if(time_cost>=construction_time)
            {
                complete();
            }
            time_cost=time_cost+Time.deltaTime;
        }
        void updatebar()
        {
            bar.SetNum(100*time_cost/construction_time);
        }
        void complete()
        {
            GameObject newtower=Instantiate(next_tower,transform.position,transform.rotation,transform.parent);
            newtower.GetComponent<tower>().enabled = true;
            Destroy(this.gameObject);
        }
    }
}
