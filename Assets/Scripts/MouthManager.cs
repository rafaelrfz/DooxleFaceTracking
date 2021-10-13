using UnityEngine;
using UnityEngine.UI;
using UnityEngine.XR.ARFoundation;

public class MouthManager : MonoBehaviour
{
    [SerializeField] private ARFace arFace;
    [SerializeField] private Text infoText;

    void Start()
    {
        arFace.updated += (arFaceUpdatedEventArgs) => {
            infoText.text = arFaceUpdatedEventArgs.face.vertices[13].ToString() + " ... " +arFaceUpdatedEventArgs.face.vertices[14].ToString();
        };
    }
}
