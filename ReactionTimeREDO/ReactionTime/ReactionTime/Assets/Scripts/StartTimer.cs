using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class StartTimer : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI startTimer;
    
    void Update()
    {
        GameObject player = GameObject.Find("Main Camera");
        Main main = player.GetComponent<Main>();

        startTimer.text = (main.waitTime - Time.time).ToString("#.0");
    }
}
