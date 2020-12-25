using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class helpscript : MonoBehaviour
{
    public int cur_index=1;
    public GameObject hint1;
    public GameObject hint2;
    public GameObject hint3;
    public GameObject hint4;
    public GameObject hint5;
    public GameObject hint6;
    public wave_spawner ws;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void next_hint()
    {
        cur_index++;
        switch(cur_index)
        {
            case 2:hint2.SetActive(true);hint1.SetActive(false);
            break;
            case 3:hint3.SetActive(true);hint2.SetActive(false);
            break;
            case 4:hint4.SetActive(true);hint3.SetActive(false);
            break;
            case 5:hint5.SetActive(true);hint4.SetActive(false);
            break;
            case 6:hint6.SetActive(true);hint5.SetActive(false);
            break;
        }

    }
    public void previous_hint()
    {
        cur_index--;
        switch(cur_index)
        {
            case 1:hint1.SetActive(true);hint2.SetActive(false);
            break;
            case 2:hint2.SetActive(true);hint3.SetActive(false);
            break;
            case 3:hint3.SetActive(true);hint4.SetActive(false);
            break;
            case 4:hint4.SetActive(true);hint5.SetActive(false);
            break;
            case 5:hint5.SetActive(true);hint6.SetActive(false);
            break;
        }
    }
    public void close_panel()
    {
        hint1.SetActive(true);hint2.SetActive(false);
        hint3.SetActive(false);hint4.SetActive(false);
        hint5.SetActive(false);hint6.SetActive(false);
        //ws.start=true;
        ws.countdown=5f;
        this.gameObject.SetActive(false);
    }
}
