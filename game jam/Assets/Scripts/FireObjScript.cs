﻿using UnityEngine;
using System.Collections;

public class FireObjScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}

	void OnCollisionEnter(Collision collision)
	{
		Collider collider = collision.collider;
	}


	// Update is called once per frame
	void Update () {
	
	}
}
