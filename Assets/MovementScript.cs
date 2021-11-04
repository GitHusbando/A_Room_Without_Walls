using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementScript : MonoBehaviour
{
    public float speed = 5.0f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        var characterController = this.GetComponent<CharacterController>();
        characterController.SimpleMove(new Vector3(
            this.speed * Input.GetAxis("Horizontal"),
            0.0f,
            this.speed * Input.GetAxis("Vertical")
            ));
    }
}
