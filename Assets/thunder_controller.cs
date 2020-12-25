using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class thunder_controller : MonoBehaviour
{
    public float delay;
    public GameObject thunder;
    private ParticleSystem ps;
    public float sp1=1f;
    public float sp2=0.5f;
    public float sp3=0.2f;
    // Start is called before the first frame update
    void Awake()
    {
        //StartCoroutine(createthunder(transform,delay));
        
        ps = GetComponent<ParticleSystem>();
        switch(Player.skill_6_level)
        {
            case 0: InvokeRepeating("createthunder",0f,1.2f);
            break;
            case 1:InvokeRepeating("createthunder",0f,sp1);
            break;
            case 2:InvokeRepeating("createthunder",0f,sp2);
            break;
            case 3:InvokeRepeating("createthunder",0f,sp3);
            break;
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        if (!ps.isPlaying)
        {
            Destroy(this.gameObject);
        }
    }
    // IEnumerator createthunder(Transform t,float sec)
    // {
    //     for(int i =0;i<5;i++)
    //     {
    //         yield return new WaitForSeconds(sec);
    //         thunder.SetActive(true);
    //         thunder.SetActive(false);
    //     }
    // }
    void createthunder()
    {
        float newx=Random.Range(-2.8f, 2.8f);
        float newz=Random.Range(-2.8f, 2.8f);
        GameObject newthunder=Instantiate(thunder,new Vector3(transform.position.x+newx,transform.position.y,transform.position.z+newz),Quaternion.identity);
        // if(thunder.activeSelf)
        // {
        //     thunder.SetActive(false);
        // }
        // else
        // {
        //     float newx=Random.Range(-2.8f, 2.8f);
        //     float newz=Random.Range(-2.8f, 2.8f);
        //     thunder.transform.position=new Vector3(transform.position.x+newx,transform.position.y,transform.position.z+newz);
        //     thunder.SetActive(true);
        // }
    }
}
