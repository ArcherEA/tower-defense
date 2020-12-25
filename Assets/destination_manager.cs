using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace TD
{
    public class destination_manager : MonoBehaviour
    {
        // Start is called before the first frame update
        void Start()
        {
            GameObject[] roads= GameObject.FindGameObjectsWithTag("road");
            foreach(GameObject road in roads)
            {
                float distanceToroad = Vector3.Distance(transform.parent.position,road.transform.position);
                
                if(distanceToroad<transform.parent.GetComponent<tower>().range)
                {
                    transform.position=road.transform.position;
                    break;
                } 
            }
        }

        // Update is called once per frame
        void Update()
        {
            
        }
    }
}