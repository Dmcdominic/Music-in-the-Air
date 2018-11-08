using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class channel_adjusted_audio : MonoBehaviour {

	public AudioClip audioClip;
	public int channel_index;


	private void Awake() {
		AudioClip adjustedAudioClip = audioClip.CreateSpeakerSpecificClip(1, channel_index);
		AudioSource audioSource = GetComponent<AudioSource>();
		audioSource.clip = adjustedAudioClip;
	}

}
