using UnityEngine;
using System.Collections;

public class FireControl : MonoBehaviour {

	public GameObject firePrefab;
	
	private GameObject fireInstance;
	private Component[] particleEmitters;
	private Component[] lightSources;

	private float lightInterval;

	private float emitTimer;
	private float stopTimer;

	private int nextLightToActivate;
	private int nextLightToDeactivate;
	public AudioSource soundPlayer;

	// Use this for initialization
	void Start () {
		fireInstance = gameObject.transform.GetChild(1).GetChild(0).GetChild(0).gameObject;
		particleEmitters = fireInstance.transform.gameObject.GetComponentsInChildren<ParticleEmitter>();
		lightSources = fireInstance.transform.gameObject.GetComponentsInChildren<Light>(); // light sources are already sorted from the nearest one to the furthest

		toggleActiveFire(false);
		foreach(Light lightSource in lightSources) lightSource.enabled = false;

		//lightSources[3].light.enabled = true;

		lightInterval = 3.0f / particleEmitters[0].particleEmitter.localVelocity.y;
		emitTimer = 0;
		stopTimer = 0;
		nextLightToActivate = 0;
		nextLightToDeactivate = 0;
	}
	
	// Update is called once per frame
	void Update () {
		if(nextLightToActivate != 0)
		{
			emitTimer += Time.deltaTime;
			if(Mathf.Abs(emitTimer - lightInterval) < 0.01)
			{
				lightSources[nextLightToActivate].light.enabled = true;
				nextLightToActivate = (nextLightToActivate + 1) % lightSources.Length;
				emitTimer = 0;
			}
		}
		if(nextLightToDeactivate != 0)
		{
			stopTimer += Time.deltaTime;
			if(Mathf.Abs(stopTimer - lightInterval) < 0.01)
			{
				lightSources[nextLightToDeactivate].light.enabled = false;
				nextLightToDeactivate = (nextLightToDeactivate + 1) % lightSources.Length;
				stopTimer = 0;
			}
		}
		if(Input.GetButtonDown("Fire1"))
		{
			toggleActiveFire(true);
			emitTimer = 0;
			lightSources[nextLightToActivate].light.enabled = true;
			nextLightToActivate = (nextLightToActivate + 1) % lightSources.Length;
		}
		if(Input.GetButtonUp("Fire1"))
		{
			toggleActiveFire(false);
			stopTimer = 0;
			lightSources[nextLightToDeactivate].light.enabled = false;
			nextLightToDeactivate = (nextLightToDeactivate + 1) % lightSources.Length;
		}

	}

	void toggleActiveFire(bool value)
	{
		foreach(ParticleEmitter emitter in particleEmitters)
			emitter.emit = value;
		
		if(value){
			soundPlayer.Play();
			soundPlayer.loop = true;
		}
		else{
			soundPlayer.Stop();
		}
	}
}
