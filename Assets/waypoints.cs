using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class waypoints : MonoBehaviour
{
    [SerializeField]
    public static Transform[] points;

    // Start is called before the first frame update
    void Awake()
    {
        points = new Transform[transform.childCount];
        for(int i=0;i<points.Length;i++)
        {
            points[i]= transform.GetChild(i);
            
        }
        Debug.Log(points[0]);
        Debug.Log(transform.childCount);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
