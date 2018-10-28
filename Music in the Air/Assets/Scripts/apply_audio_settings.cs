using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class apply_audio_settings : MonoBehaviour {

	public audio_settings audio_Settings;

	private AudioSource AS;


	// Initialize
	private void Awake() {
		AS = GetComponent<AudioSource>();
		audio_Settings.set_defaults();
	}

	// Apply the given audio settings to the attached AudioSource every frame
	private void Update() {
		apply_settings(audio_Settings, AS);
	}

	// Apply the settings stored in an audio_settings object to a particular audioSource
	public static void apply_settings(audio_settings settings, AudioSource audioSource) {
		if (audioSource) {
			audioSource.volume = settings.get_setting(audio_option.volume);
			audioSource.pitch = settings.get_setting(audio_option.playback_speed);
			audioSource.panStereo = settings.get_setting(audio_option.stereo_pan);
		}
	}

}
