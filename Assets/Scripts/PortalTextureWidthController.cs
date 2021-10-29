using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalTextureWidthController : MonoBehaviour
{
    public Camera renderPlaneCamera;
    public Material renderPlaneMaterial;
    public int DEPTH;

    private RenderTexture myRenderTexture;

    // Start is called before the first frame update
    void Start()
    {
        if (renderPlaneCamera.targetTexture != null) //checks if camera already has a target texture
        {
            renderPlaneCamera.targetTexture.Release(); //removes the target texture if it already exists so we can make a new one
        }

        myRenderTexture = new RenderTexture(Screen.width, Screen.height, DEPTH);

        renderPlaneCamera.targetTexture = myRenderTexture;
        renderPlaneMaterial.mainTexture = renderPlaneCamera.targetTexture;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
