using UnityEngine;
using System.Collections;

public class FireObjScript : MonoBehaviour {


	public GameObject smallFire;
	public float fireTime = 10f;

	private bool isLit = false;
	private GameObject insSmallFire;
	private float reduceTimer = 5f;
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
				StartCoroutine(CoroutineFunction(fireTime/reduceTimer));
				Destroy(insSmallFire, fireTime);
				isLit = true;
			}
		}
	}

	IEnumerator CoroutineFunction(float waitingTime)
	{
		while(true && insSmallFire != null)
		{
			ReduceFireIntensity(waitingTime);
			yield return new WaitForSeconds(waitingTime);
		}
	}

	void ReduceFireIntensity(float waitingTime)
	{
		if(insSmallFire != null){
			for(int i = 0; i < insSmallFire.transform.childCount; i++){
				ParticleEmitter child = insSmallFire.transform.GetChild(i).particleEmitter;
				if(child != null){
					print(child.name);
					child.minEmission -= (int)waitingTime*3;
					child.maxEmission -= (int)waitingTime*3;
				}
			}
		}
	}


	// Update is called once per frame
	void Update () {
	
	}
}
