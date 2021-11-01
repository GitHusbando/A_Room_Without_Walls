using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RenderPlaneCameraMovement : MonoBehaviour
{
    public Camera cameraToCopy;

    private Vector3 cameraOffset;

    // Start is called before the first frame update
    void Start()
    {
        cameraOffset = transform.position - cameraToCopy.transform.position;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        transform.position = cameraToCopy.transform.position + cameraOffset;
        transform.rotation = cameraToCopy.transform.rotation;
    }
}
