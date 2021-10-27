using UnityEngine;
using UnityEngine.UI;
using UnityEngine.XR.ARFoundation;

public class MouthManagerSphere : MonoBehaviour
{
    [SerializeField] private ARFace arFace;
    //[SerializeField] private Text infoText, infoTextFood;
    [SerializeField] private GameObject particles, sphere;
    [SerializeField] private AudioSource audioFall;
    [SerializeField] private int indexVerticePosition = 151;
    [SerializeField] private EatGameManager eatGameManager;
    Vector3 sphereVerticePosition;
    [SerializeField] private Button buttonRestartGame;

    void Start()
    {
        eatGameManager = FindObjectOfType<EatGameManager>();

        buttonRestartGame.onClick.AddListener(RestartGame);
        arFace.updated += (arFaceUpdatedEventArgs) => {
            sphereVerticePosition = arFaceUpdatedEventArgs.face.vertices[indexVerticePosition];
            //Vector3 wPos = transform.worldToLocalMatrix * new Vector3(lPos.x, lPos.y, transform.localPosition.z);
            //infoText.text = "esfera: " + sphere.transform.localPosition;
            if (!eatGameManager.Time.Equals(0))
            {
                sphere.GetComponent<Rigidbody>().useGravity = arFaceUpdatedEventArgs.face.vertices[14].y < -0.05f ? false : true;
            }
            else {
                sphere.GetComponent<Rigidbody>().useGravity = false;
            }
        };
    }

    void RestartGame()
    {
        sphere.transform.localPosition = sphereVerticePosition;
    }
    private void OnTriggerEnter(Collider other)
	{
        if (other.CompareTag("Sphere")) {
            eatGameManager.Fall++;
            sphere.transform.localPosition = sphereVerticePosition;
            audioFall.Play();
        }
	}
}
