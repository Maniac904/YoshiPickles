using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour 
{
	public float speed = 0f;
	public Rigidbody cHrB;
	// Use this for initialization
	void Start () 
	{
		cHrB = GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void Update () 
	{
		transform.position = Vector3(transform.forward * speed);
	}
}
