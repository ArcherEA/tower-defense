using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace TD {
    public class damage_anim_controller : StateMachineBehaviour
    {
        override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
        {
            animator.SetFloat("damage",0f);
        } 

    }
}
