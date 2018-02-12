﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour 
{
	public float speed = 0f;
	public GameObject character;
	// Use this for initialization
	void Start () 
	{
		
	}
	
	// Update is called once per frame
	void Update () 
	{
		character.transform.position = new Vector3(transform.position.x * speed * Time.deltaTime);
	}
}
