//Controls the player movement

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementScript : MonoBehaviour
{
    public float speed = 5.0f;
    Vector3 facing_direction = new Vector3(0.0f, 0.0f, 1.0f);

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        var characterController = this.GetComponent<CharacterController>();
        var direction = new Vector3(
            Input.GetAxis("Horizontal"),
            0.0f,
            Input.GetAxis("Vertical")
        ).normalized; ;

        var delta = direction * this.speed;
        characterController.SimpleMove(delta);

        //make player face the direction they are moving
        // add a delay so switching direction isn't instantaneous
        /*
        var mix = 0.99f;
        facing_direction = mix * this.facing_direction + (1.0f - mix) * direction;
        var transform = this.GetComponent<Transform>();
        var target = transform.position + direction;
        transform.LookAt(target);
        */
    }
}
