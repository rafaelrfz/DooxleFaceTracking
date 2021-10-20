using UnityEngine;
using UnityEngine.UI;
using UnityEngine.XR.ARFoundation;

public class MouthManager : MonoBehaviour
{
    [SerializeField] private ARFace arFace;
    [SerializeField] private Text infoText, infoTextFood;
    [SerializeField] private GameObject food = null, particles;
    [SerializeField] private EatGameManager eatGameManager;
    [SerializeField] private AudioSource sfx;

    void Start()
    {
        eatGameManager = FindObjectOfType<EatGameManager>();

        arFace.updated += (arFaceUpdatedEventArgs) => {
            //infoText.text = arFaceUpdatedEventArgs.face.vertices[14].y < -0.05f ? "boca abierta": "boca cerrada";
            //infoTextFood.text = food == null ? "no hay comida": "hay comida";
            if (arFaceUpdatedEventArgs.face.vertices[14].y < -0.05f && food != null)//Abrió la boca y tiene comida??
            {
            //    particles.transform.position = food.transform.position;
            //    particles.GetComponent<ParticleSystem>().Play();
                eatGameManager.Score++;
                sfx.Play();
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
