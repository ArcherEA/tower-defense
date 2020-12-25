using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class read_crystal : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI crystal;
    [SerializeField] TextMeshProUGUI star;
    // Start is called before the first frame update


    // Update is called once per frame
    void Update()
    {
        crystal.text=Player.crystals.ToString();
        star.text=Player.stars.ToString();
    }
}
