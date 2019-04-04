using UnityEngine.Audio;
using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AudioController : MonoBehaviour
{
	// Sounds.
	public Sound[] sounds; // Array of background music & other sounds.
	public Sound[] walking; // Array of walk sounds.
	public Sound[] playerHurt; // Array of hurt sounds.

	// Components.
	private EnemyController _ec;
	public static AudioController instance;

	private void Awake()
	{
		if (instance == null) instance = this;
		else
		{
			Destroy(gameObject);
			return;
		}
		DontDestroyOnLoad(gameObject); // Don't destroy this audio GAMEOBJECT when switching scenes.

		InitializeSounds(); // Function makes all the sounds ready to use.

		// Components.
		if (_ec != null) _ec = FindObjectOfType<EnemyController>();
	}

	public void Play(string name) // Play a sound by stringname.
	{
		Sound s = Array.Find(sounds, sound => sound.name == name);
		if (s == null)
		{
			Debug.LogWarning("Sound: " + name + " not found!");
			return;
		}

		s.source.Play();
	}

	private void Update()
	{
		
	}

	private void Start()
	{
		WorldMusic(); // Start the game with World background music.

		if(_ec != null) _ec.EnteredCombat += CombatMusic; // Subscribe to EnemyController's Action "EnteredCombat".
		//_ec.EnteredWorld += WorldMusic; // Subscribe to EnemyController's Action "AfterCombat".
	}

	public void Walking() // Player walk sound.
	{
		Sound s = walking[UnityEngine.Random.Range(0, walking.Length)];
		if (s == null)
		{
			Debug.LogWarning("Sound: " + s + " not found!");
			return;
		}
		s.source.clip = s.clip;
		s.source.Play();
	}

	public void PlayerHurt() // When player health drops.
	{
		Sound s = playerHurt[UnityEngine.Random.Range(0, playerHurt.Length)];
		if (s == null)
		{
			Debug.LogWarning("Sound: " + s + " not found!");
			return;
		}
		s.source.clip = s.clip;
		s.source.Play();
	}

	private void InitializeSounds()
	{
		foreach (Sound s in sounds)
		{
			s.source = gameObject.AddComponent<AudioSource>();
			s.source.clip = s.clip;
			s.source.volume = s.volume;
			s.source.pitch = s.pitch;
			s.source.loop = s.loop;
		}

		foreach (Sound s in walking)
		{
			s.source = gameObject.AddComponent<AudioSource>();
			s.source.clip = s.clip;
			s.source.volume = s.volume;
			s.source.pitch = s.pitch;
			s.source.loop = s.loop;
		}

		foreach (Sound s in playerHurt)
		{
			s.source = gameObject.AddComponent<AudioSource>();
			s.source.clip = s.clip;
			s.source.volume = s.volume;
			s.source.pitch = s.pitch;
			s.source.loop = s.loop;
		}
	}

	public void CombatMusic() // Background music while in combat.
	{
		StopMusic();
		Play("bgCombat");
	}

	public void WorldMusic() // Background music while in the world.
	{
		StopMusic();
		Play("bgWorld");
	}

	private void StopMusic() // Stops all sounds and music.
	{
		foreach (Sound s in walking)
		{
			s.source.Stop();
		}

		foreach(Sound s in sounds)
		{
			s.source.Stop();
		}
	}
}
