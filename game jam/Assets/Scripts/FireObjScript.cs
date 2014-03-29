using UnityEngine;
using System.Collections;

public class FireObjScript : MonoBehaviour {


	public GameObject smallFire;
	public float fireTime = 5f;

	private bool isLit = false;
	private GameObject insSmallFire;
	// Use this for initialization
	void Start () {
		
	}


	void OnParticleCollision(GameObject other)
	{		
		if(other.tag == "gunfire")
		{
			print ("fire up");
			if(!isLit){
				insSmallFire = Instantiate(smallFire, this.transform.position, Quaternion.identity) as GameObject;
				Destroy(insSmallFire, fireTime);
				isLit = true;
			}
		}
	}


	// Update is called once per frame
	void Update () {
	
	}
}
