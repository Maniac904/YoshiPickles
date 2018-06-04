using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour 
{
    public Rigidbody cHrB;

    public float startingX = 0.0f;
    public float startingY = 0.0f;
    public float startingZ = 0.0f;
    
    public float jumpHeight = 0;
    public float speed = 0f;
    public float rSpeed = 0;
    public float sSpeed = 0;

    public bool grounded;
    public bool left;
    public bool right;
    public bool slideLeft;
    public bool slideCenter;
    public bool slideRight;
    public bool turnAroundleft;
    public bool turnAroundright;
    public bool jump;

	// Use this for initialization
	void Start () 
	{
		cHrB = GetComponent<Rigidbody>();

        startingX = transform.rotation.x;
        startingY = transform.rotation.y;
        startingZ = transform.rotation.z;
        
	}
	
	// Update is called once per frame
	void Update () 
	{
        Vector3 dwn = transform.TransformDirection(Vector3.down);

        if (Physics.Raycast(transform.position, dwn, 5))
        {
            grounded = true;
        }

        left = Input.GetKey("a");
        right = Input.GetKey("d");
        slideLeft = Input.GetKey("q");
        slideCenter = Input.GetKey("w");
        slideRight = Input.GetKey("e");
        turnAroundleft = Input.GetKey("x");
        turnAroundright = Input.GetKey("z");
        jump = Input.GetKey("space");

        cHrB.transform.position += Vector3.forward * speed * Time.deltaTime;
        

        if (slideRight == false || slideCenter == false || slideLeft == false && transform.rotation.x < startingX || transform.rotation.y < startingY || transform.rotation.z < startingZ)
        {
            transform.rotation = Quaternion.Euler(startingX, startingY, startingZ);
        }

        if (left)
        {
            TurnLeft();
        }
        if(right)
        {
            TurnRight();
        }
        if(slideLeft)
        {
            SlideLeft();

        }
        if(slideCenter)
        {
            SlideCenter();
        }
        if(slideRight)
        {
            SlideRight();
        }
        if(turnAroundleft)
        {
            TurnAroundLeft();
        }
        if(turnAroundright)
        {
            TurnAroundRight();
        }
        if(jump && grounded == true)
        {
            Jump();
        }
	}
    void TurnLeft()
    {
        cHrB.transform.position += Vector3.left * speed * Time.deltaTime;
    }
    void TurnRight()
    {
        cHrB.transform.position += Vector3.right * speed * Time.deltaTime;
    }
    void SlideLeft()
    {
        cHrB.transform.position += Vector3.left * sSpeed * Time.deltaTime;
        cHrB.transform.Rotate(0, 25, rSpeed * -18 );

       

    }
    void SlideCenter()
    {
        cHrB.transform.position += Vector3.forward * sSpeed * Time.deltaTime;
        cHrB.transform.Rotate(Vector3.left * rSpeed * -75);

       
    }
    void SlideRight()
    {
        cHrB.transform.position += Vector3.right * sSpeed * Time.deltaTime;
        cHrB.transform.Rotate(0, 0, rSpeed * 15);

       
    }
    void TurnAroundLeft()
    {
        cHrB.transform.Rotate(Vector3.left * 180);
    }
    void TurnAroundRight()
    {
        cHrB.transform.Rotate(Vector3.right * 180);
    }
    void Jump()
    {
        cHrB.transform.position += Vector3.up * jumpHeight * Time.deltaTime;
    }
}
