using UnityEngine;
using System.Collections;

public class FireControl : MonoBehaviour {

	public GameObject firePrefab;

	private bool isFiring;
	private bool wasFiring;
	private GameObject fireInstance;
	private Component[] particleEmitters;
	private Component[] lightSources;

	public AudioSource soundPlayer;

	// Use this for initialization
	void Start () {
		fireInstance = gameObject.transform.GetChild(1).GetChild(0).GetChild(0).gameObject;
		wasFiring = false;
		isFiring = false;
		toggleActiveFire(false);
	}
	
	// Update is called once per frame
	void Update () {
		isFiring = Input.GetButton("Fire1");

		if (isFiring && !wasFiring)
		{
			toggleActiveFire(true);
		}
		if(!isFiring && wasFiring)
		{
			toggleActiveFire(false);
		}
		wasFiring = isFiring;
	
	}

	void toggleActiveFire(bool value)
	{
		particleEmitters = fireInstance.transform.gameObject.GetComponentsInChildren<ParticleEmitter>();
		lightSources = fireInstance.transform.gameObject.GetComponentsInChildren<Light>();
		foreach(ParticleEmitter emitter in particleEmitters)
			emitter.emit = value;
		foreach(Light lightSource in lightSources)
			lightSource.enabled = value;
		if(value){
			soundPlayer.Play();
			soundPlayer.loop = true;
		}
		else{
			soundPlayer.Stop();
		}
	}
}
