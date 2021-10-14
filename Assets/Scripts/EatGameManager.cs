using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EatGameManager : MonoBehaviour
{
    [SerializeField] private List<Transform> creationPoints;
    [SerializeField] private List<GameObject> foodPool;
    [SerializeField] private Text textScore, textTime, textDebug;
    [SerializeField] private Button buttonRestartGame;
    [SerializeField] private int score, time, startTime = 60;

    public int Score { get => score; 
        set { 
            score = value;
            textScore.text = "PUNTAJE: " + score.ToString();
        }
    }
    public int Time { get => time; 
        set { 
            time = value;
            textTime.text = "TIEMPO: " + time.ToString();
        } 
    }

    private void Start()
    {
        buttonRestartGame.onClick.AddListener(RestartGame);
    }

    void RestartGame()
    {
        buttonRestartGame.interactable = false;
        Score = 0;
        Time = startTime;
        StartCoroutine(WaitToPositionFood());
    }

    IEnumerator WaitToPositionFood()
    {
        yield return new WaitForSeconds(1.0f);
        GameObject food = foodPool[Random.Range(0, foodPool.Count)];
        food.transform.position = creationPoints[Random.Range(0, creationPoints.Count)].position;
        //textDebug.text = "posicion"+food.transform.position;
        //De pronto toca tambien la rotacion
        food.SetActive(true);
        Time--;

        if (Time.Equals(0))
        {
            //Acaba juego
            buttonRestartGame.interactable = true;
            StopCoroutine(WaitToPositionFood());
        }
        else
        {
            StartCoroutine(WaitToPositionFood());
        }
    }
}
