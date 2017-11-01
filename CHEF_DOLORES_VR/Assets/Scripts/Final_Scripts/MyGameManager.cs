using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;
using UnityEngine.VR;

public class MyGameManager : MonoBehaviour {

	public static MyGameManager instance;
	public GameObject dish_prefab;
	public Transform dish_position;
	public float game_time = 300;
	public int finished_dishes = 0;
	public int score = 0;
	public Text dishes_label, score_label, time_label;
	public Slider time_slider;
	GameObject spawneddish;



	void Awake()
	{
		instance = this;
		time_slider.maxValue = game_time;
	}

	void Start()
	{
		SpawnNewDish ();
	}

	void Update()
	{
		CountdownTimer ();

		if (game_time <= 0) 
		{
			Debug.Log ("GAME OVER");
			time_label.text = "RESULTADO";
			spawneddish.transform.DOScale (Vector3.zero, 0.2f);
		}
	}

	public void SpawnNewDish()
	{
		spawneddish = Instantiate (dish_prefab, dish_position.position, Quaternion.identity) as GameObject;
	}

	void CountdownTimer()
	{
		game_time -= Time.deltaTime;
		time_label.text = "Tiempo: " + Mathf.Floor (game_time).ToString ();
		time_slider.value = Mathf.Floor (game_time);
	}

	public void AddPlatillo(int cantidad)
	{
		finished_dishes += cantidad;
		dishes_label.text = finished_dishes.ToString ();
	}

	public void AddScore(int puntos)
	{
		score += puntos;
		score_label.text = score.ToString ();
	}

	public void GameOver()
	{
		PlayerPrefs.SetInt ("score", score);
		VRSettings.enabled = false;
	}
		
}
