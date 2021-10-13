using System.Collections;
using UnityEngine;

public class Food : MonoBehaviour
{
    void OnEnable()
    {
        StartCoroutine(WaitToInactive());
    }

    IEnumerator WaitToInactive()
    {
        yield return new WaitForSeconds(4.0f);
        //De pronto toca quitar fuerza o impulso
        gameObject.SetActive(false);
    }

    private void OnDisable()
    {
        StopCoroutine(WaitToInactive());
    }
}
