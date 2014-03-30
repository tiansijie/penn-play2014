using UnityEngine;
using System.Collections;

public class Goal : MonoBehaviour {


	public GameObject FinalDirLight;
	private Light finalLight;
	// Use this for initialization
	void Start () {
		finalLight = FinalDirLight.GetComponent<Light>();
	}

	void OnTriggerEnter(Collider collider)
	{
		if(collider.tag == "Player"){

			finalLight.enabled = true;
			Invoke("LoadScene", 20.0f);
		}
	}

	void LocadScene()
	{
		Application.LoadLevel(2);
	}
	
	// Update is called once per frame
	void Update () {
		if(finalLight.enabled)
		{
			finalLight.spotAngle += Time.deltaTime * 9.0f;
		}
	}
}
