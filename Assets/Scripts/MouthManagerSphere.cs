using UnityEngine;
using UnityEngine.UI;
using UnityEngine.XR.ARFoundation;

public class MouthManagerSphere : MonoBehaviour
{
    [SerializeField] private ARFace arFace;
    //[SerializeField] private Text infoText, infoTextFood;
    [SerializeField] private GameObject particles, sphere;
    [SerializeField] private AudioSource audioFall;
    [SerializeField] private int indexVerticePosition = 8;
    Vector3 sphereVerticePosition;
    [SerializeField] private Button buttonRestartGame;

    void Start()
    {
        buttonRestartGame.onClick.AddListener(RestartGame);
        arFace.updated += (arFaceUpdatedEventArgs) => {
            sphereVerticePosition = arFaceUpdatedEventArgs.face.vertices[indexVerticePosition];
            //Vector3 wPos = transform.worldToLocalMatrix * new Vector3(lPos.x, lPos.y, transform.localPosition.z);
            //infoText.text = "esfera: " + sphere.transform.localPosition;
            sphere.GetComponent<Rigidbody>().useGravity = arFaceUpdatedEventArgs.face.vertices[14].y < -0.05f ? false :true;
        };
    }

    void RestartGame()
    {
        sphere.transform.localPosition = sphereVerticePosition;
        //buttonRestartGame.interactable = false;
    }
    private void OnTriggerEnter(Collider other)
	{
        if (other.CompareTag("Sphere")) {
            sphere.transform.localPosition = sphereVerticePosition;
            audioFall.Play();
        }
	}
}
