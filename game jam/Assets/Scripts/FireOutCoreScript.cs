using UnityEngine;
using System.Collections;

public class FireOutCoreScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}

	void OnParticleCollision(GameObject other)
	{
		if(other.tag == "fireobject")
		{
			print("Hahahahaaha");
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
