using UnityEngine;
using UnityEngine.UI;

public class AudioManager : MonoBehaviour
{
	public Slider bgSlider, soundEffSlider;
	private float bgFloat, soundEffFloat;
	public AudioSource bgAudio;
	public AudioSource[] soundEffAudio;

	void Start ()
	{
		bgSlider.value = PlayerPrefs.GetFloat ("BackgroundPref", 0.25f);
		soundEffSlider.value = PlayerPrefs.GetFloat ("SoundEffectsPref", 0.5f);
	}

	//Saves the player's audio settings
	void Update()
	{
		PlayerPrefs.SetFloat("BackgroundPref", bgSlider.value);
		PlayerPrefs.SetFloat("SoundEffectsPref", soundEffSlider.value);
	}

	//Changes volume as the sliders move
	public void UpdateSound()
	{
		bgAudio.volume = bgSlider.value;

		for (int i = 0; i < soundEffAudio.Length; i++) 
		{
			soundEffAudio [i].volume = soundEffSlider.value;
		}
	}
}