using UnityEngine;
using System.Collections;

public class FireControl : MonoBehaviour {

	public GameObject firePrefab;
	
	private GameObject fireInstance;
	private Component[] particleEmitters;
	//private Component[] lightSources;
	private GameObject[] lightSources;

	private float lightInterval;
	private int lightCount = 10;
	private float lightSpacing = 1.0f;

	private float emitTimer = 0;
	private float stopTimer = 0;

	private int nextLightToActivate = 0;
	private int nextLightToDeactivate = 0;
	
	public AudioSource soundGunKeepShotting;


	// Use this for initialization
	void Start () {

		fireInstance = gameObject.transform.GetChild(1).GetChild(0).GetChild(0).gameObject;
		particleEmitters = fireInstance.transform.gameObject.GetComponentsInChildren<ParticleEmitter>();
		lightSources = new GameObject[lightCount];

		for(int i = 0; i < lightCount; ++i)
		{
			GameObject lightGameObject = new GameObject("Flame Light");
			lightGameObject.transform.parent = gameObject.transform.GetChild(1).GetChild(0).GetChild(0).transform;
			lightGameObject.transform.localPosition = new Vector3(0, 0, i*lightSpacing);
			lightGameObject.AddComponent<Light>();
			lightGameObject.light.color = new Color(255, 156, 48);
			lightGameObject.light.color /= 255.0f;
			lightGameObject.light.range = 5.0f * (i+1.0f);
			lightGameObject.light.intensity = 0.5f / (i+1.0f);
			lightGameObject.SetActive(false);
			lightSources[i] = lightGameObject;
		}	

		toggleActiveFire(false);

		lightInterval = lightSpacing / particleEmitters[0].particleEmitter.localVelocity.y;
	}
	
	// Update is called once per frame
	void Update () {

//		timer += Time.deltaTime;
//		if(timer > 1.0)
//		{
//
//			timer = 0;
//			lightSources[ind].light.enabled = true;
//			ind++;
//		}

		if(nextLightToActivate != 0)
		{
			emitTimer += Time.deltaTime;
			if(Mathf.Abs(emitTimer - lightInterval) < 0.01)
			{
				lightSources[nextLightToActivate].SetActive(true);
				nextLightToActivate = (nextLightToActivate + 1) % lightSources.Length;
				emitTimer = 0;
			}
		}
		if(nextLightToDeactivate != 0)
		{
			stopTimer += Time.deltaTime;
			if(Mathf.Abs(stopTimer - lightInterval) < 0.01)
			{
				lightSources[nextLightToDeactivate].SetActive(false);
				nextLightToDeactivate = (nextLightToDeactivate + 1) % lightSources.Length;
				stopTimer = 0;
			}
		}
		if(Input.GetButtonDown("Fire1"))
		{
			toggleActiveFire(true);
			emitTimer = 0;
			lightSources[nextLightToActivate].SetActive(true);
			nextLightToActivate = (nextLightToActivate + 1) % lightSources.Length;
		}
		if(Input.GetButtonUp("Fire1"))
		{
			toggleActiveFire(false);
			stopTimer = 0;
			lightSources[nextLightToDeactivate].SetActive(false);
			nextLightToDeactivate = (nextLightToDeactivate + 1) % lightSources.Length;
		}

		//print(lightSources[0].light.enabled + " " + lightSources[1].light.enabled + " " + lightSources[2].light.enabled + " " + lightSources[3].light.enabled + " " + lightSources[4].light.enabled
		  //    +" " + lightSources[5].light.enabled + " " + lightSources[6].light.enabled + " " + lightSources[7].light.enabled + " " + lightSources[8].light.enabled + " " + lightSources[9].light.enabled);

	}


	void toggleActiveFire(bool value)
	{
		foreach(ParticleEmitter emitter in particleEmitters)
			emitter.emit = value;
		
		if(value){
			soundGunKeepShotting.Play();
			soundGunKeepShotting.loop = true;
		}
		else{
			soundGunKeepShotting.Stop();
		}
	}
}
