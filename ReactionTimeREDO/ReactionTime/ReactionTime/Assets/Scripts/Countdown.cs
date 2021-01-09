using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Countdown : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI countdown;

    void Update()
    {

        GameObject player = GameObject.Find("Main Camera");
        Main main = player.GetComponent<Main>();

        countdown.text = ((main.gameTime+main.waitTime)-Time.time).ToString("#.0");
    }
}
