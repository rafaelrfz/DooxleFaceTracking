using UnityEngine;
using UnityEngine.UI;
using UnityEngine.XR.ARFoundation;

public class MouthManager : MonoBehaviour
{
    [SerializeField] private ARFace arFace;
    [SerializeField] private Text infoText;
    [SerializeField] private GameObject food = null;
    [SerializeField] private EatGameManager eatGameManager;

    void Start()
    {
        eatGameManager = FindObjectOfType<EatGameManager>();

        arFace.updated += (arFaceUpdatedEventArgs) => {
            infoText.text = arFaceUpdatedEventArgs.face.vertices[13].ToString() + " ... " + arFaceUpdatedEventArgs.face.vertices[14].ToString();

            if (arFaceUpdatedEventArgs.face.vertices[14].y < 0 && food != null)//Abrió la boca y tiene comida??
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
