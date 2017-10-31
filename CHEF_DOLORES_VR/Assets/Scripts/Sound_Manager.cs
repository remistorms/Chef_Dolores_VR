using UnityEngine;
using System.Collections;

public class Sound_Manager : MonoBehaviour {

	public static Sound_Manager instance;
	public AudioClip[] sound_fx;
	//public AudioSource main_audio_source;


	void Awake()
	{
		instance = this;
	}

	public void PlaySoundFX(AudioSource source, int sound_id, float delay)
	{
		StartCoroutine (SoundDelay (source, sound_id, delay));
	}

	IEnumerator SoundDelay( AudioSource source, int id, float delay)
	{
		yield return new WaitForSeconds (delay);
		source.clip = sound_fx [id];
		source.Play ();
	}

}
