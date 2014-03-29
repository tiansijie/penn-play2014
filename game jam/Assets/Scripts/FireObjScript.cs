using UnityEngine;
using System.Collections;

public class FireObjScript : MonoBehaviour {


	public GameObject smallFire;
	public float fireTime = 10f;
	public int fireReduceScalar = 4;
	public float reduceTimer = 3f;

	private bool isLit = false;
	private GameObject insSmallFire;


	// Use this for initialization
	void Start () {
		
	}

	void OnParticleCollision(GameObject other)
	{		
		if(other.tag == "gunfire")
		{
			//print ("fire up");
			if(!isLit){
				insSmallFire = Instantiate(smallFire, this.transform.position, Quaternion.identity) as GameObject;
				Invoke("StopEmitter", fireTime - 2f);
				Destroy(insSmallFire, fireTime);
				isLit = true;
			}
		}
	}


	void StopEmitter()
	{
		if(insSmallFire != null){
			for(int i = 0; i < insSmallFire.transform.childCount; i++){
				ParticleEmitter child = insSmallFire.transform.GetChild(i).particleEmitter;
				if(child != null)
					child.emit = false;
			}
		}			
	}


	// Update is called once per frame
	void Update () {
	
	}
}
