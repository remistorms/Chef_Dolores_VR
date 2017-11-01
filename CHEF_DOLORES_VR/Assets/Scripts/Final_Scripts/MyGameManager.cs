﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;
using UnityEngine.VR;
using UnityEngine.SceneManagement;

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
	bool isGameOver = false;



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

		if (game_time <= 0 && isGameOver == false) 
		{
			isGameOver = true;
			Debug.Log ("GAME OVER");
			time_label.text = "RESULTADO";
			spawneddish.transform.DOScale (Vector3.zero, 0.2f);
			SaveResults ();
			StartCoroutine (LoadSceneWithDelay ());
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
		
	public void SaveResults()
	{
		PlayerPrefs.SetString ("Last_Nombre", Datos_Script.instance.nombre);
		PlayerPrefs.SetString ("Last_Ticket", Datos_Script.instance.ticket);
		PlayerPrefs.SetString ("Last_Plaza", Datos_Script.instance.plaza);
		PlayerPrefs.SetString ("Last_Cadena", Datos_Script.instance.cadena);
		PlayerPrefs.SetString ("Last_Premio", Datos_Script.instance.premio);
		PlayerPrefs.SetInt ("Last_Platillos", finished_dishes);
		PlayerPrefs.SetInt ("Last_Puntos", score);
		string fecha = System.DateTime.Now.ToString();
		PlayerPrefs.SetString("Last_Fecha", fecha);
	}

	IEnumerator LoadSceneWithDelay()
	{
		yield return new WaitForSeconds (5);
		SceneManager.LoadScene (0);
	}

}
