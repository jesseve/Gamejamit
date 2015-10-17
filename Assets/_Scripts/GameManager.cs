using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GameManager : MonoBehaviour {

	public AudioClip[] screams;
	public AudioClip blade;
	public AudioClip victory;
	public AudioClip defeat;

	public List<King> gameOverKings;

	public AudioSource music;
	public AudioSource sound1;
	public AudioSource sound2;

	private static GameManager instance;

	void Start() {
		DontDestroyOnLoad(gameObject);
		instance = this;
	}

	public void StartGame() {
		if(instance.music.isPlaying == false) {
			instance.sound1.Stop ();
			instance.sound2.Stop ();
			instance.music.Play();
		} 
		Application.LoadLevel("_Main 1");
	}
	public void GameOver(List<King> kings) {
		Debug.Log ("Game over");
		gameOverKings = kings;

		Application.LoadLevel("GameOver");
	}

	public static void PlayScream() {
		instance.sound1.PlayOneShot(instance.screams[Random.Range (0,2)]);
		instance.sound2.PlayOneShot(instance.blade);
	}
	public static void PlayDefeat() {
		instance.music.Stop();
		instance.sound1.PlayOneShot(instance.defeat);
	}
	public static void PlayVictory() {
		instance.music.Stop();
		instance.sound1.PlayOneShot(instance.victory);
	}
}
