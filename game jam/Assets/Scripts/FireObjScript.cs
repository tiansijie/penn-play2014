﻿using UnityEngine;
using System.Collections;

public class FireObjScript : MonoBehaviour {


	public GameObject smallFire;
	public float fireTime = 10f;

	private bool isLit = false;
	private GameObject insSmallFire;

	GhostShadowScript ghostshaowscript;
	// Use this for initialization
	void Start () {
		ghostshaowscript = this.transform.GetChild(0).GetComponent<GhostShadowScript>();
	}

	void OnParticleCollision(GameObject other)
	{		
		if(other.tag == "gunfire")
		{
			//print ("fire up");
			if(!isLit){
				ghostshaowscript.setActivate(true);
				insSmallFire = Instantiate(smallFire, this.transform.position, Quaternion.identity) as GameObject;
				Invoke("StopEmitter", fireTime - 2f);
				Invoke("StopShadow", fireTime);
				StartCoroutine(CoroutineFunction(fireTime / 10f));
				Destroy(insSmallFire, fireTime);
				isLit = true;
			}
		}
	}


	void StopShadow()
	{
		ghostshaowscript.setActivate(false);
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

	IEnumerator CoroutineFunction(float waitingTime)
	{
		while(true && insSmallFire != null)
		{
			ReduceLightIntesity(1f/10f);
			yield return new WaitForSeconds(waitingTime);
		}
	}

	void ReduceLightIntesity(float value)
	{
		if(insSmallFire != null)
		{
			Light light = insSmallFire.transform.GetComponentInChildren<Light>();
			light.intensity -= value;
		}
	}



	// Update is called once per frame
	void Update () {
	
	}
}
