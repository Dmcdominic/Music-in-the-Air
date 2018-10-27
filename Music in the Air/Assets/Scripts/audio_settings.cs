using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName="Custom/audio_settings")]
public class audio_settings : ScriptableObject {

	[Range(0.0f, 1.0f)]
	public float volume;

	[Range(-3.0f, 3.0f)]
	public float pitch;

	[Range(-1.0f, 1.0f)]
	public float stereo_pan;
	
}
