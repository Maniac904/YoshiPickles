using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMotor : MonoBehaviour
{
    private CharacterController controller;
    private GameObject mainCam;
    private CameraMotor camMotor;
    private Vector3 moveVector;
    [SerializeField]
    private float speed = 7.0f;
    [SerializeField]
    private float sideSpeed = 7.0f;
    private float verticalVelocity = 0.0f;
    private float gravity = 12.0f;

    private float animationDuration = 3.0f;

    public float Speed { get { return speed; } set { Speed = speed; } }

	// Use this for initialization
	void Start ()
    {
        controller = GetComponent<CharacterController>();
        mainCam = GameObject.FindGameObjectWithTag("MainCamera");
        camMotor = mainCam.GetComponent<CameraMotor>();
        animationDuration = camMotor.AnimationDuration;
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (Time.time < animationDuration)
        {
            controller.Move(Vector3.forward * speed * Time.deltaTime);
            return;
        }

        //Debug.Log(controller.isGrounded);
        moveVector = Vector3.zero;

        if (controller.isGrounded)
        {
            verticalVelocity = -0.5f;
            if (Input.GetButtonDown("Jump"))
            {
                Debug.Log("JUMP");
                Jump();
            }

            FreeSideMovement();
        }
        else
        {
            verticalVelocity -= gravity * Time.deltaTime;
            FreeSideMovement();
        }

        
        
        controller.Move(moveVector * Time.deltaTime);
    }

    void Jump()
    {
        verticalVelocity += 5.0f * Time.deltaTime;

    }

    void FreeSideMovement()
    {
        moveVector.x = Input.GetAxisRaw("Horizontal") * sideSpeed;
        moveVector.y = verticalVelocity;
        moveVector.z = speed;
    }
}
