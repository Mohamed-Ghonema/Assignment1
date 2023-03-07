using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControls : MonoBehaviour
{
   [SerializeField] Transform playerCamera = null;
    [SerializeField] float sensitivity = 3.0f;
    [SerializeField] float walkSpeed = 10.0f;
    [SerializeField] float gravity = -10.0f;
    [SerializeField] float jumpHeight = 0.5f;
    [SerializeField] bool lockCursor = true;

    float cameraPitch = 0.0f;
    CharacterController controller = null;

    Vector3 velocity;



    void Start()
    {

        controller = GetComponent<CharacterController>();
        if(lockCursor){

            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;

        }

        

    }


    // Update is called once per frame
    void Update()
    {

        MouseMovement();
        PlayerMovement();
        
    }


    void MouseMovement(){


        Vector2 mouseDelta = new Vector2(Input.GetAxis("Mouse X") ,Input.GetAxis("Mouse Y"));

        cameraPitch -= mouseDelta.y * sensitivity;

        cameraPitch = Mathf.Clamp(cameraPitch, -90f, 90f);

        playerCamera.localEulerAngles = Vector3.right * cameraPitch;

        transform.Rotate(Vector3.up * mouseDelta.x * sensitivity);


    }


    void PlayerMovement(){

        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");


        if(controller.isGrounded){
            velocity.y = 0.0f;
        }


        velocity.y += gravity * Time.deltaTime;


        if(controller.isGrounded && Input.GetButtonDown("Jump")){

            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);

        }

        
        Vector3 move = (transform.right * x) + (transform.forward * z) + (Vector3.up * velocity.y);

        controller.Move(move * Time.deltaTime * walkSpeed);



    }
}
