using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class apply_audio_settings : MonoBehaviour {

	public audio_settings audio_Settings;

	private AudioSource AS;


	private void Awake() {
		AS = GetComponent<AudioSource>();
	}

	private void Update() {
		if (audio_Settings) {
			AS.volume = audio_Settings.volume;
			AS.pitch = audio_Settings.pitch;
			AS.panStereo = audio_Settings.stereo_pan;
		}
	}

}
