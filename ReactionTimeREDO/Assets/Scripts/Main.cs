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

    private float obj = 0;
    public float clicks = 0;
    public float hits = 0;
    public bool gameOver = false;

    public float waitTime = 5;
    public float gameTime = 30;

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
        StartGame();
        Hit();
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
                    counter.text = "Hits: " + hits.ToString();
                    Spawn();
                }
            }
        }
    }

    void StartGame()
    {
        waitTime -= Time.deltaTime;
        startTimer.text = waitTime.ToString("#0.0");
        
        StartCoroutine(ExecuteAfterTime(waitTime));
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

    IEnumerator ExecuteAfterTime(float time)
    {
        yield return new WaitForSeconds(time);

        if (gameOver == false)
        {
            startTimer.enabled = false;
            countdown.enabled = true;
            counter.enabled = true;
            Spawn();
        }

        float a = gameTime + waitTime;
        a -= Time.deltaTime;
        countdown.text = a.ToString("#0.0");

        StartCoroutine(ExecuteAfterTime2(gameTime));
    }

    IEnumerator ExecuteAfterTime2(float time)
    {
        yield return new WaitForSeconds(time);

        gameOver = true;
        Destroy(GameObject.FindGameObjectWithTag("Player"));

        if (hits > 0)
        {
            Accuracy();
            ReactionTime();
            Score();
        }
        

        countdown.enabled = false;
        counter.enabled = false;

        restart.SetActive(true);
        quit.SetActive(true);

        results.enabled = true;
    }


    private void Score()
    {
        score = (hits * accuracy / 100) / reactionTime;
    }

    private void Accuracy()
    {
        accuracy = (hits / clicks) * 100;
    }

    private void ReactionTime()
    {
        reactionTime = gameTime / hits;
    }
}
// made by Shubh Ravishankar Gawhade




