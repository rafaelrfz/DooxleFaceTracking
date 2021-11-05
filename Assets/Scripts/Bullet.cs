using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private Rigidbody rb;
    private AsteroidGameManager asteroidGameManager;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        asteroidGameManager = FindObjectOfType<AsteroidGameManager>();
    }
    void Update()
    {
        rb.velocity = transform.TransformDirection(Vector3.up * 0.85f);
    }

    void OnEnable()
    {
        StartCoroutine(WaitToInactive());
    }

    IEnumerator WaitToInactive()
    {
        yield return new WaitForSeconds(1.5f);
        //De pronto toca quitar fuerza o impulso
        gameObject.SetActive(false);
    }

    private void OnDisable()
    {
        StopCoroutine(WaitToInactive());
    }

	private void OnTriggerEnter(Collider other)
	{
        if (other.CompareTag("Sphere")) {
            gameObject.SetActive(false);
            GetComponent<AudioSource>().Play();
            asteroidGameManager.Score++;
            other.gameObject.SetActive(false);
        }
	}
}
