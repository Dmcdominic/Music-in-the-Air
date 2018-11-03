using Leap;
using Leap.Unity;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum adjustment_axis { vertical, horizontal, depth }

[RequireComponent(typeof(BoxCollider))]
public class adjust_audio_settings : MonoBehaviour {

	private const bool fist_control = false;
	private const bool open_hand_control = true;
	private const float grab_strength_threshhold = 0.8f;

	public audio_option option_to_adjust;
	public adjustment_axis adjustment_Axis;

	//public Collider collider_condition;
	public audioSettings_collider_dict audio_collider_pairs;
	private Dictionary<Collider, bool> collider_checks;

	//public audio_settings audio_Settings;
	public meta_settings meta_Settings;

	private BoxCollider boxCollider;
	private Controller controller;


	private void Awake() {
		boxCollider = GetComponent<BoxCollider>();
		controller = new Controller();
		collider_checks = new Dictionary<Collider, bool>();
		foreach (Collider collider in audio_collider_pairs.Values) {
			collider_checks.Add(collider, false);
		}
	}

	private void Update() {
		Frame frame = controller.Frame();
		if (frame.Hands.Count > 0) {
			Debug.Log("Found at least one hand");
			Hand first_hand = frame.Hands[0];
			bool hand_check = can_hand_control(first_hand);
			foreach (KeyValuePair<audio_settings, BoxCollider> KVP in audio_collider_pairs) {
				audio_settings audio_Settings = KVP.Key;
				//bool collider_check = collider_checks[KVP.Value];
				//Debug.Log("Collider check: " + collider_checks[KVP.Value]);
				bool collider_check = boxCollider.bounds.Intersects(KVP.Value.bounds);
				if (audio_Settings && hand_check && collider_check) {
					float value = get_val_from_pos(audio_Settings);
					audio_Settings.set_setting(option_to_adjust, value);
				}
			}
		}
	}

	private void OnCollisionEnter(Collision collision) {
		if (collider_checks.ContainsKey(collision.collider)) {
			collider_checks[collision.collider] = true;
		}
	}

	private void OnCollisionExit(Collision collision) {
		if (collider_checks.ContainsKey(collision.collider)) {
			collider_checks[collision.collider] = false;
		}
	}

	private float get_val_from_pos(audio_settings audio_Settings) {
		float max_val = audio_Settings.max_vals[option_to_adjust];
		float min_val = audio_Settings.min_vals[option_to_adjust];
		float val_range = max_val - min_val;

		float multiplier = 0.5f;
		if (adjustment_Axis == adjustment_axis.vertical) {
			multiplier = (transform.position.y - meta_Settings.min_setting_height) / meta_Settings.height_range;
		} else if (adjustment_Axis == adjustment_axis.horizontal) {
			multiplier = (transform.position.x - meta_Settings.min_setting_width) / meta_Settings.width_range;
		} else if (adjustment_Axis == adjustment_axis.depth) {
			Debug.LogWarning("Depth adjustment axis range not set up in meta settings. Defaulting to width range.");
			multiplier = (transform.position.z - meta_Settings.min_setting_width) / meta_Settings.width_range;
		}

		float new_val = min_val + (multiplier * val_range);

		return new_val;
	}

	private bool can_hand_control(Hand hand) {
		return (fist_control && hand.GrabStrength >= grab_strength_threshhold) || (open_hand_control && hand.GrabStrength < grab_strength_threshhold);
	}

	private bool collider_control_check() {
		return false;
	}

}

[System.Serializable]
public class audioSettings_collider_dict : SerializableDictionary<audio_settings, BoxCollider> { };
