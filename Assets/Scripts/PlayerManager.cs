using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.XR.ARFoundation;

public class PlayerManager : MonoBehaviour
{
    [SerializeField] private ARFace arFace;
    [SerializeField] private PlayerControl playerControl;
    
    void Start()
    {
        arFace.updated += (arFaceUpdatedEventArgs) => {
            if (arFaceUpdatedEventArgs.face.vertices[14].y < -0.05f)//Abrió la boca
            {
                playerControl.Jump();
            }
            else {
                playerControl.NoJump();
            }
        };
    }
	
}