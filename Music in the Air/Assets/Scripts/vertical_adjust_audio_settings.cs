using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class vertical_adjust_audio_settings : MonoBehaviour {

	public audio_option option_to_adjust;
	public audio_settings audio_Settings;
	public meta_settings meta_Settings;


	private void Update() {
		if (audio_Settings) {
			float value = get_val_from_height();
			audio_Settings.set_setting(option_to_adjust, value);
		}
	}

	private float get_val_from_height() {
		float max_val = audio_Settings.max_vals[option_to_adjust];
		float min_val = audio_Settings.min_vals[option_to_adjust];
		float val_range = max_val - min_val;

		float multiplier = (transform.position.y - meta_Settings.min_setting_height) / meta_Settings.height_range;
		float new_val = min_val + (multiplier * val_range);

		return new_val;
	}

}
