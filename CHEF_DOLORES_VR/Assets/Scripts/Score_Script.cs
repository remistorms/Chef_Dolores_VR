using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class Score_Script : MonoBehaviour {

	public static Score_Script instance;
	public int game_score = 0;
	public Slider time_slider;
	public int total_time;
	public int time_left;
	public Text score_text, time_text;
	public GameObject[] infos_canvas;

	void Awake()
	{
		instance = this;
		time_slider.maxValue = total_time;
		time_slider.value = total_time;
		time_left = total_time;
	}

	void Start()
	{

		transform.localScale = Vector3.zero;
		//time_slider.maxValue = time_left;
		time_text.text = "tiempo: " + total_time.ToString ();
		StartTimer ();
	}

	void Update()
	{
		if (Input.GetKeyDown(KeyCode.S)) 
		{
			AddScore (Random.Range (100, 250));
		}
	}

	public void ShowScoreScreen()
	{
		transform.DOScale (new Vector3 (0.003f, 0.003f, 0.003f), 1.0f);
	}

	public void HideScoreScreen()
	{
		transform.DOScale (Vector3.zero, 1.0f);
	}

	public void InitializeScore()
	{
		
	}
		

	public void StartTimer()
	{
		StartCoroutine (myTimer ());
	}

	IEnumerator myTimer()
	{
		yield return new WaitForSeconds (5);
		ShowScoreScreen ();
		yield return new WaitForSeconds (2);
		
		for (int i = 0; i < total_time; i++) 
		{
			yield return new WaitForSeconds (1);
			time_left--;
			time_text.text = "tiempo: " + time_left.ToString ();
			time_slider.value = time_left;
		}

		if (time_left == 0) 
		{
			Debug.Log ("TIMES UP");
			Tools_Script.instance.DissapearTools ();
			Help_UI_Script.instance.HideAllHelp ();
		}

	}

	public void AddScore(int number)
	{
		StartCoroutine (ScoreRoutine (number));
	}

	IEnumerator ScoreRoutine(int points)
	{
		for (int i = 0; i < points; i++) 
		{
			game_score++;
			score_text.text = "puntos : <size=30>" + game_score.ToString() + "</size>";
			yield return new WaitForSeconds (0.00001f);
		}
	}

}
