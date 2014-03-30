using UnityEngine;
using System.Collections;

public class GUI_TimeScript : MonoBehaviour {
	public GlobalScript gScript;
	// Use this for initialization
	void Start () {
		gScript = GameObject.Find ("Global").GetComponent<GlobalScript> ();
	}
	
	// Update is called once per frame
	void Update () {
		gameObject.guiText.text = "Time: " +((int)gScript.gameTime).ToString ();
	}
}
