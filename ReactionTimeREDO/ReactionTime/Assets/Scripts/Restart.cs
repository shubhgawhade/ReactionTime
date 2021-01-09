using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Restart : MonoBehaviour
{
    public void StartAgain()
    {
        

        GameObject player = GameObject.Find("Main Camera");
        Main main = player.GetComponent<Main>();

        SceneManager.LoadScene(0);
    }
}
