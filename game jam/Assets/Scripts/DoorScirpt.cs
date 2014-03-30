using UnityEngine;
using System.Collections;

public class DoorScirpt : MonoBehaviour {


	private bool isDoorClosed = true;
	public float smooth = 1.0F;

	private Vector3 originalAngle;
	// Use this for initialization
	void Start () {
		originalAngle = transform.rotation.eulerAngles;
		originalAngle.y -= 82f;
	}

	void OnTriggerEnter(Collider collider)
	{
		if(collider.tag == "Player")
		{
			if(isDoorClosed)
				isDoorClosed = false;
		}
	}


	void DoorIsOpen()
	{
		if(isDoorClosed)
			isDoorClosed = false;
	}

	
	// Update is called once per frame
	void Update () {
		if(!isDoorClosed)
		{
			Quaternion target = Quaternion.Euler(originalAngle);
			transform.rotation = Quaternion.Slerp(transform.rotation, target, Time.deltaTime * smooth);
		}
	}
}
