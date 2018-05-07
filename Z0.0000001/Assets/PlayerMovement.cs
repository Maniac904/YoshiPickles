using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour 
{
    public Rigidbody cHrB;
    public float speed = 0f;
	
    public bool left = false;
    public bool right;
    public bool slideLeft;
    public bool slideRight;
    public bool turnAroundleft;
    public bool turnAroundright;
    public bool jump;

	// Use this for initialization
	void Start () 
	{
		cHrB = GetComponent<Rigidbody>();

        //left = Input.GetButtonDown("a");
        right = Input.GetButtonDown("d");
        slideLeft = Input.GetButtonDown("q");
        slideRight = Input.GetButtonDown("e");
        turnAroundleft = Input.GetButtonDown("x");
        turnAroundright = Input.GetButtonDown("z");
        jump = Input.GetButtonDown("space");
	}
	
	// Update is called once per frame
	void Update () 
	{
		cHrB.transform.position += Vector3.forward * speed * Time.deltaTime;

        if(Input.GetButtonDown("A"))
        {
            TurnLeft();
        }
	}
    void TurnLeft()
    {
        cHrB.transform.position += Vector3.left * speed * Time.deltaTime;
    }
    void TurnRight()
    {

    }
    void SlideLeft()
    {

    }
    void SlideRight()
    {

    }
    void TurnAroundLeft()
    {

    }
    void TurnAroundRight()
    {

    }
    void Jump()
    {

    }
}
