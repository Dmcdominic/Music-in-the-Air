using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum audio_option { volume, playback_speed, stereo_pan }
// More ideas: 

[CreateAssetMenu(menuName="Custom/audio_settings")]
public class audio_settings : ScriptableObject {
	
	protected audio_float_option_dict float_options = new audio_float_option_dict();
	public audio_float_option_dict defaults = new audio_float_option_dict();
	public audio_float_option_dict min_vals = new audio_float_option_dict();
	public audio_float_option_dict max_vals = new audio_float_option_dict();

	
	public void set_defaults() {
		float_options.CopyFrom(defaults);
	}

	public float get_setting(audio_option option) {
		if (!float_options.Contains(option)) {
			float_options[option] = defaults[option];
		}
		return float_options[option];
	}

	public void set_setting(audio_option option, float value) {
		float_options[option] = Mathf.Clamp(value, min_vals[option], max_vals[option]);
	}

}

[System.Serializable]
public class audio_option_dict<T> : SerializableDictionary<audio_option, T> { };

[System.Serializable]
public class audio_float_option_dict : audio_option_dict<float> { };
