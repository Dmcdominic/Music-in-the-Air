using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName="Custom/meta_settings")]
public class meta_settings : ScriptableObject {

	public float min_setting_height;
	public float max_setting_height;
	public float height_range {
		get {
			return max_setting_height - min_setting_height;
		}
	}

	public float min_setting_width;
	public float max_setting_width;
	public float width_range {
		get {
			return max_setting_width - min_setting_width;
		}
	}

}
