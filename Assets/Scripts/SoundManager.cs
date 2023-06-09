using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public enum eSFX
{
	eHit_Strong,
	eHit_Weak,
	eBall_Rolling,
	eUI_Button
}
public enum eUIButtonClick
{
	eOption
}
public enum eBGM
{
	eMemoryOfBeach,
	eSunnyDay
}
public class SoundManager : MonoBehaviour
{

	// Audio players components.
	public AudioSource Effect;
	public AudioSource BGM,Effectbgm;
	public AudioClip[] EffectList, Effectbgmlist, GameOverList, BGMList;


	// Random pitch adjustment range.
	public float LowPitchRange = .95f;
	public float HighPitchRange = 1.05f;

	// Singleton instance.
	public static SoundManager Instance = null;

	// Initialize the singleton instance.
	private void Awake()
	{
		// If there is not already an instance of SoundManager, set it to this.
		if (Instance == null)
		{
			Instance = this;
		}
		//If an instance already exists, destroy whatever this object is to enforce the singleton.
		else if (Instance != this)
		{
			Destroy(gameObject);
		}

		//Set SoundManager to DontDestroyOnLoad so that it won't be destroyed when reloading our scene.
		DontDestroyOnLoad(gameObject);
	}
	// Play a single clip through the music source.
	public void PlayBGM(eBGM ebgm)
	{
		BGM.clip = BGMList[(int)ebgm];
		BGM.Play();
	}
	//
	public void PlayEffectSound(eSFX esfx)
	{
		Effect.clip = EffectList[(int)esfx];
		Effect.Play();
	}
	public void PlayEffectbgmSound(int index)
	{
		Effectbgm.clip = Effectbgmlist[index];
		Effectbgm.Play();
	}
}
