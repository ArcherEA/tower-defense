using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class change_HEALTH : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI m_Object;
    // Start is called before the first frame update
    void Start()
    {
       m_Object.text=Player_status.player_health.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        m_Object.text=Player_status.player_health.ToString();
    }
    
}
