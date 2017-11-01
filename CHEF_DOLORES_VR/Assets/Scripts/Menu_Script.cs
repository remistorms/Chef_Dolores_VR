using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using UnityEngine.SceneManagement;

public class Menu_Script : MonoBehaviour {

	public float fade_time = 0.5f;
	public GameObject[] menu_window;
	public List<RectTransform> menu_rects;
	public List<CanvasGroup> menu_canvases;
	public Button[] premio_buttons;
	public Text number_counter;
	int current_screen;

	void Awake()
	{
		for (int i = 0; i < menu_window.Length; i++) 
		{
			//Gets all rect transform and canvas group inside the windwo_menu array
			menu_rects.Add (menu_window [i].GetComponent<RectTransform> ());
			menu_canvases.Add (menu_window [i].GetComponent<CanvasGroup> ());
			//Centers all objects here
			menu_rects [i].offsetMax = menu_rects [i].offsetMin = Vector3.zero;
			//Makes all canvases invisible on awake
			menu_canvases [i].alpha = 0.0f;
			//menu_canvases [i].interactable = false;
			menu_window[i].SetActive(false);
		}

		menu_window [0].SetActive (true);
		menu_canvases [0].alpha = 1.0f;
		menu_canvases [0].interactable = true;
		current_screen = 0;

	}

	public void SwapMenuScreen(int menu_id)
	{
		StartCoroutine (SwapRoutine (menu_id));
	}

	IEnumerator SwapRoutine(int id)
	{
		menu_canvases [current_screen].interactable = false;
		menu_canvases [current_screen].DOFade (0, fade_time);
		menu_window [id].SetActive (true);
		menu_canvases [id].DOFade (1.0f, fade_time);
		yield return new WaitForSeconds (fade_time);
		menu_window [current_screen].SetActive (false);
		menu_canvases [id].interactable = true;
		current_screen = id;
	}

	public void LoadScene(int scene_to_load)
	{
		StartCoroutine (LoadSceneWithDelay (scene_to_load));
	}

	IEnumerator LoadSceneWithDelay(int scene)
	{
		int myint = 10;
		for (int i = 0; i < 10; i++) 
		{
			//number_counter.text = myint.ToString();
			myint--;
			yield return new WaitForSeconds (1);
		}

		SceneManager.LoadScene (scene);
	}

}
