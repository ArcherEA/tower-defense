using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
namespace TD
{
    public class debuff : MonoBehaviour
    {
        public bool burning=false;
        public bool freezing=false;
        public bool bl=false;
        private NavMeshAgent agent;
        void Start()
        {
            agent=GetComponent<NavMeshAgent>();
        }
        void Update()
        {

        }
        void checkfreeze()
        {

        }
        void checkburning()
        {
            
        }

    }
}