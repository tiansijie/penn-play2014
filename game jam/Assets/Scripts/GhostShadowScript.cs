using UnityEngine;
using System.Collections;

public class GhostShadowScript : MonoBehaviour {

	private Vector3 parentLocation;
	private Vector3 ranDirection;
	private bool isActivate = false;

	public float shadowSpeed = 1f;
	// Use this for initialization
	void Start () {
//		parentLocation = this.transform.parent.transform.position;
//		Vector3 objPos = new Vector3(parentLocation.x, 0.1f, parentLocation.z);
//		this.transform.position = objPos;
//		getRandomDirection();
	}

	public void setActivate(bool active)
	{
		this.isActivate = active;
	}

	void getRandomDirection()
	{
		ranDirection = new Vector3(Random.Range(-1f,1f), 0.0f, Random.Range(-1f,1f));
		ranDirection.Normalize();
	}

	// Update is called once per frame
	void Update () {

//		if(isActivate){
//			this.renderer.enabled = true;
//			Vector3 currPos = transform.position;
//			currPos += ranDirection * Time.deltaTime * shadowSpeed;
//			Vector3 scaleGhost = new Vector3(1f, 
//			                                 Mathf.Abs(currPos.y - parentLocation.y) + 1f,	
//			                                 1f);
//			this.transform.localScale = scaleGhost;
//			this.transform.position = currPos;
//			Vector3 distoParent = new Vector3(currPos.x - parentLocation.x, 0f, currPos.z - parentLocation.z);
//			if(distoParent.magnitude > 3)
//				ranDirection = -ranDirection;
//			else if(distoParent.magnitude < 0.2){
//				getRandomDirection();
//			}
//		}
//		else{
//			//this.enabled = false;
//			this.renderer.enabled = false;
//		}

	}
//	void OnGUI()
//	{
//		if(GUI.Button(new Rect(500,500,384,166),"",startButton))
//		{
//			print ("aaa");
//		}
//	}
}
