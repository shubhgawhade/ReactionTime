using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class Main : MonoBehaviour
{
    [SerializeField] private GameObject cube;
    [SerializeField] private TextMeshProUGUI startTimer;
    [SerializeField] private TextMeshProUGUI countdown;
    [SerializeField] private TextMeshProUGUI counter;
    [SerializeField] private TextMeshProUGUI results;
    [SerializeField] private GameObject restart;
    [SerializeField] private GameObject quit;

    public float currentTime;
    
    private float obj = 0;
    public float clicks = 0;
    public float hits = 0;
    public bool gameOver = false;

    public int waitTime = 5;
    public int gameTime = 30;
    
    public float reactionTime;
    public float accuracy;
    public float score;

    // Start is called before the first frame update
    void Start()
    {
        startTimer.enabled = true;
        countdown.enabled = false;
        counter.enabled = false;
        results.enabled = false;

        restart.SetActive(false);
        quit.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        currentTime = Time.time;
        StartAndEnd();
    }

    private void Score()
    {
        score = (hits * accuracy) / reactionTime;
    }

    private void Accuracy()
    {
        accuracy = hits / clicks;
    }

    private void ReactionTime()
    {
        reactionTime = gameTime / hits;
    }

    private void Hit()
    {
        if (Input.GetMouseButtonDown(0) && gameOver == false)
        {
            clicks++;

            Ray rayOrigin = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hitInfo;

            if (Physics.Raycast(rayOrigin, out hitInfo))
            {
                if (hitInfo.collider.tag == "Player")
                {
                    Destroy(hitInfo.collider.gameObject);
                    obj--;
                    hits++;
                    Spawn();
                }
            }
        }
    }

    private void StartAndEnd()
    {
        if (currentTime > waitTime && gameOver == false) 
        {
            startTimer.enabled = false;
            countdown.enabled = true;
            counter.enabled = true;
            Spawn();
            Hit();
        }
        if (currentTime > gameTime + waitTime && gameOver == false)
        {
            gameOver = true;
            Destroy(GameObject.FindGameObjectWithTag("Player"));

            Accuracy();
            ReactionTime();
            Score();

            countdown.enabled = false;
            counter.enabled = false;

            restart.SetActive(true);
            quit.SetActive(true);

            results.enabled = true;
        }
    }

    private void Spawn()
    {
        Vector2 pos = new Vector2(Random.Range(-16.6f, 16.6f), Random.Range(-8.7f, 7.5f));
        if (obj == 0)
        {
            
            Instantiate(cube, pos, Quaternion.identity);
            obj++;
        }
    }
}
