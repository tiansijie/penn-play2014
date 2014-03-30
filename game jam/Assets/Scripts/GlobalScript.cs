using UnityEngine;
using System.Collections;

public class GlobalScript : MonoBehaviour {
	public float gameTime;
	// Use this for initialization
	void Start () {
		gameTime = 0.0f;
	}
	
	// Update is called once per frame
	void Update () {
		gameTime += Time.deltaTime;
	}
}
