using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TD{
     public enum CastHand {RightHand, LeftHand}
    public class release_arc : MonoBehaviour
    {
        public Transform rightHand;
        public Transform leftHand;
        public Transform fire_place;
        public Transform target_place;
        public float speed=10f;
        public float turnspeed=10f;
        public bool spellready=true;

        public Vector3 handOffset;

        public float spellOffset;
        
        public GameObject spellPrefab;
        public GameObject castEffectPrefab;

        //[HideInInspector]
        public GameObject castEffectR;
        //[HideInInspector]
        public GameObject castEffectL;
        // public AudioSource spellsound;

        
        public void fire_arrow()
        {
            Vector3 place=fire_place.position+new Vector3(0f,0f,-0.35f);
            GameObject newarrow = Instantiate(spellPrefab, place, fire_place.rotation);
            newarrow.GetComponent<arrow>().launch=true;
            newarrow.GetComponent<arrow>().targetPos=target_place;
        }
         public void right_throw_fireball()
        {
            // spellsound.Play();
            Vector3 place=leftHand.position+new Vector3(0f,0f,0f);
            GameObject newfireball = Instantiate(spellPrefab, place, leftHand.rotation);
            newfireball.GetComponent<fire_ball_magic>().launch=true;
            newfireball.GetComponent<fire_ball_magic>().targetPos=target_place;
        }
        public void left_throw_fireball()
        {
            // spellsound.Play();
            Vector3 place=rightHand.position+new Vector3(0f,0f,0f);
            GameObject newfireball = Instantiate(spellPrefab, place, rightHand.rotation);
            newfireball.GetComponent<fire_ball_magic>().launch=true;
            newfireball.GetComponent<fire_ball_magic>().targetPos=target_place;

        }
        
        public void Active_lazer()
        {
            // spellsound.Play();
            GameObject newLazer = Instantiate(spellPrefab, fire_place.position, fire_place.rotation,fire_place.transform);
            spellready=true;
            newLazer.GetComponent<lazer_controller>().launch=true;
            newLazer.GetComponent<lazer_controller>().target=target_place;
            newLazer.transform.localPosition = new Vector3(newLazer.transform.localPosition.x, newLazer.transform.localPosition.y, newLazer.transform.localPosition.z+spellOffset);
        }
        public void delete_lazer()
        {
            spellready=false;
            GetComponent<Animator>().SetBool("shoot",false);
        }
        

        
    }
}
