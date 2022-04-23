using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DeathBox : MonoBehaviour
{
	public ParticleSystem DeathParticle;
	
	private AudioSource MyAudioSource;
	private GameObject mainCamera;
	

	private void Start()
	{
		MyAudioSource = GetComponent<AudioSource>();
		mainCamera = GameObject.Find("Main Camera");
	}

	private void OnTriggerEnter(Collider other)
	{
		if (other.CompareTag("Player"))
		{
			// if audio clip is designated, play it
			if (MyAudioSource != null)
			{
				MyAudioSource.Play();
			}

			if (DeathParticle != null)
			{
				DeathParticle.Play();
			}

			//shake camera
		
			Invoke("Reload", 2);  // wait 2 seconds, then reload level
		}
	}

	void Reload()
	{
		SceneManager.LoadScene(SceneManager.GetActiveScene().name);
	}
}