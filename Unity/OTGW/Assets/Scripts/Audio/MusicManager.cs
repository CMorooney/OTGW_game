using UnityEngine;

public class MusicManager : MonoBehaviour
{
    AudioSource AudioSource;

	void Awake()
	{
        AudioSource = gameObject.AddComponent<AudioSource>();
        PlayPotatoesAndMolasses();	
	}

	void PlayPotatoesAndMolasses()
    {
        var loop = Resources.Load<AudioClip>(GameConstants.ResourcePaths.AudioPath.PotatoesAndMolassesLoop);

        AudioSource.clip = loop;
        AudioSource.loop = true;
        AudioSource.Play();
    }
}