using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementScript : MonoBehaviour
{
    // Start is called before the first frame update
    public CharacterController controller;
    
    public float speed = 12f;
    public float gravity = -19.81f;
    public float jumpHeight = 1.5f;
    public Transform groundCheck;
    public float groundDistance = 0.4f;
    public LayerMask groundMask;
    public AudioSource source;

    Vector3 velocity;
    bool isGrounded;


    void Start(){
        source = GetComponent<AudioSource>();
        source.Play(0);
        source.Pause();
    }

    // Update is called once per frame
    void Update()
    {   
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);
        print(isGrounded); //testing groundcheck
        if(isGrounded && velocity.y < 0){
            velocity.y = -2f;
        }
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 move = transform.right * x + transform.forward * z;

        controller.Move(move * speed * Time.deltaTime);

        if(Input.GetButton("Jump") && isGrounded){
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
        }
        velocity.y += gravity * Time.deltaTime;

        controller.Move(velocity * Time.deltaTime);

        if ((Input.GetAxis("Horizontal") > 0 || Input.GetAxis("Horizontal") < 0 ) || 
                (Input.GetAxis("Vertical") > 0 || Input.GetAxis("Vertical") < 0 )){
            source.volume = Random.Range(0.6f, 1);
            source.pitch = Random.Range(0.5f, 1.5f);
            source.UnPause();
            StartCoroutine(ExampleCoroutine());

        }  else {
            source.Pause();
        }

    }

    IEnumerator ExampleCoroutine()
    {


        //yield on a new YieldInstruction that waits for 5 seconds.
        yield return new WaitForSeconds(4);

    }
}
