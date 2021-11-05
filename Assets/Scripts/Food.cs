using System.Collections;
using UnityEngine;

public class Food : MonoBehaviour
{
    [SerializeField] private float waitToDisable = 4.0f;
    void OnEnable()
    {
        StartCoroutine(WaitToInactive());
    }

    IEnumerator WaitToInactive()
    {
        yield return new WaitForSeconds(waitToDisable);
        //De pronto toca quitar fuerza o impulso
        gameObject.SetActive(false);
    }

    private void OnDisable()
    {
        StopCoroutine(WaitToInactive());
    }
}
