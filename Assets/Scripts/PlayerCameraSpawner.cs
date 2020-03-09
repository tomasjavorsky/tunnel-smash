using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCameraSpawner : MonoBehaviour
{
    private GameObject cameraGameObject;
    // Start is called before the first frame update
    void Start()
    {
        cameraGameObject = new GameObject("PlayerCamera");
        cameraGameObject.transform.Rotate(90, 0, 0);
        cameraGameObject.AddComponent(typeof(Camera));
        cameraGameObject.AddComponent(typeof(CameraController));
        Instantiate(cameraGameObject, gameObject.transform);
    }
}
