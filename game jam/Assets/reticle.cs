using UnityEngine;
using System.Collections;

public class reticle : MonoBehaviour {

	private GUITexture playerReticle;
	private float relativeScale;

	// Use this for initialization
	void Start () {
		relativeScale = 0.1f;
		playerReticle = gameObject.GetComponent<GUITexture>() as GUITexture;
		Screen.showCursor = false; 
	}
	
	// Update is called once per frame
	void Update () {
		float reticleSize = relativeScale * Mathf.Min(Screen.height, Screen.width);
		playerReticle.pixelInset = new Rect(-0.5f * reticleSize, -0.5f * reticleSize, reticleSize, reticleSize);
	}
}
