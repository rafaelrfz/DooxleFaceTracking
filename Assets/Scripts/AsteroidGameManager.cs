using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class AsteroidGameManager : MonoBehaviour
{
    [SerializeField] private List<Transform> creationPoints;
    [SerializeField] private List<GameObject> asteroidPool;
    [SerializeField] private Text textScore, textTime;
    [SerializeField] private Button buttonRestartGame;
    [SerializeField] private int score, time, startTime = 60;
    [SerializeField] private float asteroidWaitMin =3, asteroidWaitMax = 3;

    public int Score
    {
        get => score;
        set
        {
            value = Mathf.Clamp(value, 0, 100);
            score = value;
            textScore.text = "PUNTAJE: " + score.ToString();
        }
    }
    public int Time
    {
        get => time;
        set
        {
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
        StartCoroutine(WaitToAsteroid());
        StartCoroutine(WaitToTime());
    }
    IEnumerator WaitToTime() {
        yield return new WaitForSeconds(1.0f);
        Time--;

        if (Time.Equals(0))
        {
            //Acaba juego
            buttonRestartGame.interactable = true;
            StopAllCoroutines();
        }
        else
        {
            StartCoroutine(WaitToTime());
        }
    }


    IEnumerator WaitToAsteroid()
    {
        if (!Time.Equals(0))
        {
            GameObject asteroid = asteroidPool[Random.Range(0, asteroidPool.Count)];
            while (!asteroid.activeSelf)
            {
                asteroid.transform.position = creationPoints[Random.Range(0, creationPoints.Count)].position;
                //De pronto toca tambien la rotacion
                asteroid.SetActive(true);
                //Debug.Log("no esta activo pero ahora sí");
            }
            yield return new WaitForSeconds(Random.Range(asteroidWaitMin, asteroidWaitMax));
            StartCoroutine(WaitToAsteroid());
        }
    }
}