using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    private Transform playerTransform;
    private Vector3 cameraTarget;
    // Start is called before the first frame update
    void Start()
    {
        //playerTransform = GameObject.Find("Player").transform;
        playerTransform = gameObject.GetComponentInParent<Transform>();

    }

    // Update is called once per frame
    void Update()
    {
        cameraTarget = new Vector3(playerTransform.position.x, 14, playerTransform.position.z);
        transform.position = Vector3.Lerp(transform.position, cameraTarget, Time.deltaTime * 8);
        transform.rotation = Quaternion.Euler(90, 0, 0);
    }
}
