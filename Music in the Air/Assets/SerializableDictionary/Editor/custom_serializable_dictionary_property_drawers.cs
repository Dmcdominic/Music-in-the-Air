using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

// Custom SerializableDictionary types go here
[CustomPropertyDrawer(typeof(audio_float_option_dict))]
[CustomPropertyDrawer(typeof(audioSettings_collider_dict))]
public class Custom_AnySerializableDictionaryPropertyDrawer : SerializableDictionaryPropertyDrawer { }

//[CustomPropertyDrawer(typeof(ColorArrayStorage))]
public class Custom_AnySerializableDictionaryStoragePropertyDrawer : SerializableDictionaryStoragePropertyDrawer { }