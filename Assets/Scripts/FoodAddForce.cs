using System.Collections;
using UnityEngine;

public class FoodAddForce : MonoBehaviour
{
    [SerializeField] private float force = 10;
    Rigidbody rb;
    void OnEnable()
    {
        StartCoroutine(WaitToInactive());
        rb = GetComponent<Rigidbody>();
        //rb.velocity = transform.right * Time.fixedDeltaTime * force;
    }

	private void FixedUpdate()
	{
        rb.MovePosition(rb.position + (rb.transform.right * (force * Time.fixedDeltaTime)));
    }

	IEnumerator WaitToInactive()
    {
        
        yield return new WaitForSeconds(2.0f);
        //De pronto toca quitar fuerza o impulso
        gameObject.SetActive(false);
    }

    private void OnDisable()
    {
        StopCoroutine(WaitToInactive());
    }
}
