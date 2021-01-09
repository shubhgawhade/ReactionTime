using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Results : MonoBehaviour
{
    public TextMeshProUGUI results;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        GameObject player = GameObject.Find("Main Camera");
        Main main = player.GetComponent<Main>();

        results.text = "Results \n \n \n Hits: " + Mathf.Abs(main.hits).ToString("#0") + "\n \n" + "Accuracy: " + Mathf.Abs(main.accuracy).ToString("#.00") + "\n \n" + "Reaction Time: " + Mathf.Abs(main.reactionTime).ToString("#.00") + "\n \n" + "Score: " + Mathf.Abs(main.score).ToString("#.00");
    }
}
