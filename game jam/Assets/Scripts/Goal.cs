using UnityEngine;
using System.Collections;

public class Goal : MonoBehaviour {


	public GameObject FinalDirLight;
	// Use this for initialization
	void Start () {
	
	}

	void OnTriggerEnter(Collider collider)
	{
		if(collider.tag == "Player"){
			Light finalLight = FinalDirLight.GetComponent<Light>();
			finalLight.enabled = true;
			//print("You Win");
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
