﻿using UnityEngine;
using System.Collections;

public class Goal : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}

	void OnTriggerEnter(Collider collider)
	{
		if(collider.tag == "Player")
			print("You Win");
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
