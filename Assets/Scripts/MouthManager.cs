using UnityEngine;
using UnityEngine.UI;
using UnityEngine.XR.ARFoundation;

public class MouthManager : MonoBehaviour
{
    [SerializeField] private ARFace arFace;
    [SerializeField] private Text infoText, infoTextFood;
    [SerializeField] private GameObject food = null;
    [SerializeField] private EatGameManager eatGameManager;

    void Start()
    {
        eatGameManager = FindObjectOfType<EatGameManager>();

        arFace.updated += (arFaceUpdatedEventArgs) => {
            infoText.text = arFaceUpdatedEventArgs.face.vertices[14].y < -0.05f ? "boca abierta": "boca cerrada";
            //infoText.text = arFaceUpdatedEventArgs.face.vertices[14].y.ToString();
            infoTextFood.text = food == null ? "no hay comida": "hay comida";

            if (arFaceUpdatedEventArgs.face.vertices[14].y < -0.05f && food != null)//Abrió la boca y tiene comida??
            {
                eatGameManager.Score++;
                food.SetActive(false);
                food = null;
            }
        };
    }

    private void OnTriggerEnter(Collider other)
    {
        food = other.gameObject;
    }

    private void OnTriggerExit(Collider other)
    {
        food = null;
    }
}
