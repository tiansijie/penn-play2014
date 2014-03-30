using UnityEngine;
using System.Collections;

public class startSceneScript : MonoBehaviour {

	// Use this for initialization
	public GUIStyle startButton;
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	void OnGUI()
	{
		if(GUI.Button(new Rect(700,600,197,83),"",startButton))
		{
			Application.LoadLevel(1);
		}
	}
}
