using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
using Unity.VisualScripting;

public class CameraController : MonoBehaviour {
    public CinemachineVirtualCamera[] cameras;
    public CinemachineVirtualCamera startCamera;
    public CinemachineVirtualCamera currentCamera;

    private void Start() {
        currentCamera = startCamera;
    }

    public void ChangeCam(int index) {
        currentCamera.gameObject.SetActive(false);
        currentCamera = cameras[index];
        currentCamera.gameObject.SetActive(true);
    }
    public void NextCam() {
        for (int i = 0; i < cameras.Length; i++)
        {
            if (cameras[i] == currentCamera)
            {
                currentCamera.gameObject.SetActive(false);
                currentCamera = cameras[i+1];
                currentCamera.gameObject.SetActive(true);
                return;
            }
        }
    }
    public void PreviousCam() {
        for (int i = 0; i < cameras.Length; i++) {
            if (cameras[i] == currentCamera) {
                currentCamera.gameObject.SetActive(false);
                currentCamera = cameras[i - 1];
                currentCamera.gameObject.SetActive(true);
                return;
            }
        }
    }
}
