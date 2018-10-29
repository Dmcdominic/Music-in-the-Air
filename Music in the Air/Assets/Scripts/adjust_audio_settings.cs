using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum adjustment_axis { vertical, horizontal, depth }

public class adjust_audio_settings : MonoBehaviour {

	public audio_option option_to_adjust;
	public adjustment_axis adjustment_Axis;
	public audio_settings audio_Settings;
	public meta_settings meta_Settings;


	private void Update() {
		if (audio_Settings) {
			float value = get_val_from_pos();
			audio_Settings.set_setting(option_to_adjust, value);
		}
	}

	private float get_val_from_pos() {
		float max_val = audio_Settings.max_vals[option_to_adjust];
		float min_val = audio_Settings.min_vals[option_to_adjust];
		float val_range = max_val - min_val;

		float multiplier = 0.5f;
		if (adjustment_Axis == adjustment_axis.vertical) {
			multiplier = (transform.position.y - meta_Settings.min_setting_height) / meta_Settings.height_range;
		} else if (adjustment_Axis == adjustment_axis.horizontal) {
			multiplier = (transform.position.x - meta_Settings.min_setting_width) / meta_Settings.width_range;
		} else {
			Debug.LogError("This axis not implemented");
		}

		float new_val = min_val + (multiplier * val_range);

		return new_val;
	}

}
