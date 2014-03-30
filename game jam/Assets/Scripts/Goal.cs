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
<<<<<<< HEAD
			Invoke("LoadScene", 13.0f);
=======
			Invoke("LoadScene", 10.0f);
>>>>>>> 0885a8310881eba123f4ced1a3ef2e47195499dd
		}
	}

	void LoadScene()
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
