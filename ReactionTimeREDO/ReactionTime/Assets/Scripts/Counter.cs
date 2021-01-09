using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Counter : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI counter; 

    void Update()
    {
        GameObject player = GameObject.Find("Main Camera");
        Main main = player.GetComponent<Main>();

        counter.text = "Hits: " + main.hits.ToString();
    }
}
