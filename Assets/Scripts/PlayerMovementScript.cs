using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementScript : MonoBehaviour
{
    //code yoinked (stolen) with modifications from https://docs.unity3d.com/ScriptReference/CharacterController.Move.html

    public Camera mainCamera;

    CharacterController controller;

    private float PLAYER_SPEED = 5.0f;
    private float LOOK_SPEED = 3.0f;
    private float JUMP_STRENGTH = 3.0f; //we probably don't want the player to be able to jump too high (to avoid seeing things they shouldn't)
    private float GRAVITY_VALUE = -9.81f;

    private float verticalVelocity;
    private Vector2 mouseRotation;

    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        controller = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        mouseRotation.x = -1 * Input.GetAxis("Mouse Y");
        mouseRotation.y = Input.GetAxis("Mouse X");

        transform.Rotate(0, mouseRotation.y * LOOK_SPEED, 0);
        mainCamera.transform.Rotate(mouseRotation.x * LOOK_SPEED, 0, 0);

        verticalVelocity += GRAVITY_VALUE * Time.deltaTime;

        if (controller.isGrounded)
        {
            if (verticalVelocity < 0)
            {
                verticalVelocity = 0f;
            }
            if (Input.GetButtonDown("Jump"))
            {
                //jumping only seems to work sometimes?
                verticalVelocity = JUMP_STRENGTH;
            }
        }

        Vector3 move = new Vector3(Input.GetAxis("Horizontal"), verticalVelocity, Input.GetAxis("Vertical"));
        move = this.transform.TransformDirection(move); //take into account player rotation
        controller.Move(move * Time.deltaTime * PLAYER_SPEED);
    }
}
