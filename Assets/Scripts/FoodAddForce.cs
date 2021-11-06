using System.Collections;
using UnityEngine;

public class FoodAddForce : MonoBehaviour
{
    [SerializeField] private float force = 10;//, delayToInactive = 4.0f;
    Rigidbody rb;
    [SerializeField] private AsteroidGameManager asteroidGameManager;
    void OnEnable()
    {
        //StartCoroutine(WaitToInactive());
        rb = GetComponent<Rigidbody>();
        rb.isKinematic = false;
        //rb.velocity = transform.right * Time.fixedDeltaTime * force;
        rb.AddForce(Vector3.right * force, ForceMode.Impulse);
    }

	/*private void FixedUpdate()
	{
        //rb.MovePosition(rb.position + (rb.transform.right * (force * Time.fixedDeltaTime)));
        
    }*/

	/*IEnumerator WaitToInactive()
    {
        
        yield return new WaitForSeconds(delayToInactive);
        //De pronto toca quitar fuerza o impulso
        gameObject.SetActive(false);
    }*/

    private void OnDisable()
    {
        //StopCoroutine(WaitToInactive());
        //rb.Sleep();
        rb.isKinematic = true;
    }

	private void OnTriggerEnter(Collider other)
	{
        if (other.CompareTag("WallSumScore"))
        {
            other.GetComponent<AudioSource>().Play();
            asteroidGameManager.Score++;
            gameObject.SetActive(false);
        }
	}
}
