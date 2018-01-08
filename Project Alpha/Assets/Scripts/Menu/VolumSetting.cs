using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VolumSetting : MonoBehaviour {

	public Slider volumSlider;
	public AudioSource backgroundMusic;
	private string key = "BGM_Volum";

	// Use this for initialization
	void Start () {
		volumSlider.value = PlayerPrefs.GetFloat(key);
		backgroundMusic.volume = PlayerPrefs.GetFloat(key);
	}
	// Update is called once per frame
	void Update () {
		backgroundMusic.volume = volumSlider.value;
		PlayerPrefs.SetFloat (key,volumSlider.value);
		//Debug.Log(PlayerPrefs.GetFloat (key).ToString());
	}

}
