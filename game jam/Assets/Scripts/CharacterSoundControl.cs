using UnityEngine;
using System.Collections;

public class CharacterSoundControl : MonoBehaviour {
	
	public AudioSource soundPlayer;
	private bool isStepSoundPlay;
	// Use this for initialization
	void Start () {
		soundPlayer = this.GetComponent<AudioSource>() as AudioSource;
		isStepSoundPlay = false;
	}
	
	// Update is called once per frame
	void Update () {
		Vector3 directionVector = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));

		if(directionVector != Vector3.zero)
		{
			if(!isStepSoundPlay){
				soundPlayer.Play();
				soundPlayer.loop = true;
				isStepSoundPlay = true;
			}
		}
		else{
			soundPlayer.Stop();
			isStepSoundPlay = false;
		}
	}
}
