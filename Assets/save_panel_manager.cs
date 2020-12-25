using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class save_panel_manager : MonoBehaviour
{
    public GameObject save1;
    public GameObject save2;
    public GameObject save3;
    public GameObject newgame1;
    public GameObject newgame2;
    public GameObject newgame3;
    
    // Start is called before the first frame update
    void Start()
    {
        if( SaveSystem.LoadPlayer(1)!=null)
        {
            newgame1.SetActive(false);
            save1.SetActive(true);
        }
        else
        {
            newgame1.SetActive(true);
            save1.SetActive(false);
        }
        if( SaveSystem.LoadPlayer(2)!=null)
        {
            newgame2.SetActive(false);
            save2.SetActive(true);
        }
        else
        {
            newgame2.SetActive(true);
            save2.SetActive(false);
        }
        if( SaveSystem.LoadPlayer(3)!=null)
        {
            newgame3.SetActive(false);
            save3.SetActive(true);
        }
        else
        {
            newgame3.SetActive(true);
            save3.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
