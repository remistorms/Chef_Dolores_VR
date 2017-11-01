using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class Dish_Script : MonoBehaviour {

	//public Transform end_point;
	public Image ingredient_slot_01, ingredient_slot_02, ingredient_slot_03, ingredient_slot_04;
	public Image checkmark_01, checkmark_02, checkmark_03, checkmark_04;
	public Sprite tuna_meat, sliced_tomato, sliced_lettuce, sliced_onion, sliced_chile, empty_sprite;
	public Sprite checkmark;
	public Text dish_name_label;
	public int needs_tuna, needs_tomato, needs_lettuce, needs_onion, needs_chile = 0;
	public int total_ingredients = 100;
	public int total_points;
	public Transform bow_position;
	public GameObject dish_canvas;
	public AudioSource dish_audio_source;
	//int last_random = 0;

	void Update()
	{
		if (Input.GetKeyDown(KeyCode.R)) 
		{
			
			int new_random = Random.Range (0, 10);
			GenerateDish (new_random);
		}

	}

	void Start()
	{
		dish_canvas.transform.localScale = Vector3.zero;
		transform.localScale = Vector3.zero;
		StartCoroutine (StartDishRoutine ());
		dish_audio_source = GetComponent<AudioSource> ();
		Debug.Log ("START HAS BEEN CALLED ON DISH");
	}


	public void DishFinished()
	{
		dish_canvas.transform.DOScale (Vector3.zero, 0.2f);
		//transform.DOMove (new Vector3(0.9f, 2.7f, -4.6f), 0.5f);
		transform.DOScale (Vector3.zero, 0.5f);
		Sound_Manager.instance.PlaySoundFX (dish_audio_source, 3, 0);
		//transform.DOLocalRotate (new Vector3 (0, 1800, 0), 1.0f);
		//Score_Script.instance.AddScore (total_points);
		//Destroy (this.gameObject, 0.7f);
		StartCoroutine(PopRoutine());
		MyGameManager.instance.AddPlatillo (1);
		MyGameManager.instance.AddScore (total_points);
		MyGameManager.instance.SpawnNewDish ();
	}

	IEnumerator StartDishRoutine()
	{
		yield return new WaitForSeconds (1.5f);
		transform.DOScale (Vector3.one, 1.0f);
		yield return new WaitForSeconds (1.5f);
		dish_canvas.transform.DOScale (new Vector3 (0.0015f, 0.0015f, 0.0015f), 0.5f);
		GenerateDish (Random.Range (0, 10));
	}


	public void GenerateDish(int dish_id)
	{
		
		switch (dish_id) 

		{

		case 0: 
			dish_name_label.text = "Atun con Lechuga";
			ingredient_slot_01.sprite = tuna_meat;
			ingredient_slot_02.sprite = sliced_lettuce;
			ingredient_slot_03.sprite = empty_sprite;
			ingredient_slot_04.sprite = empty_sprite;
			needs_tuna = 1;
			needs_chile = 0;
			needs_onion = 0;
			needs_tomato = 0;
			needs_lettuce = 1;
			break;

		case 1: 
			dish_name_label.text = "Jitomate Relleno de Atun";
			ingredient_slot_01.sprite = tuna_meat;
			ingredient_slot_02.sprite = sliced_tomato;
			ingredient_slot_03.sprite = empty_sprite;
			ingredient_slot_04.sprite = empty_sprite;
			needs_tuna = 1;
			needs_chile = 0;
			needs_onion = 0;
			needs_tomato = 1;
			needs_lettuce = 0;
			break;

		case 2: 
			dish_name_label.text = "Atun Picante";
			ingredient_slot_01.sprite = tuna_meat;
			ingredient_slot_02.sprite = sliced_chile;
			ingredient_slot_03.sprite = empty_sprite;
			ingredient_slot_04.sprite = empty_sprite;
			needs_tuna = 1;
			needs_chile = 1;
			needs_onion = 0;
			needs_tomato = 0;
			needs_lettuce = 0;
			break;

		case 3: 
			dish_name_label.text = "Cebollitas con Atun";
			ingredient_slot_01.sprite = tuna_meat;
			ingredient_slot_02.sprite = sliced_onion;
			ingredient_slot_03.sprite = empty_sprite;
			ingredient_slot_04.sprite = empty_sprite;
			needs_tuna = 1;
			needs_chile = 0;
			needs_onion = 1;
			needs_tomato = 0;
			needs_lettuce = 0;
			break;

		case 4:
			dish_name_label.text = "Ensalada Fresca de Atun";
			ingredient_slot_01.sprite = tuna_meat;
			ingredient_slot_02.sprite = sliced_lettuce;
			ingredient_slot_03.sprite = sliced_onion;
			ingredient_slot_04.sprite = empty_sprite;
			needs_tuna = 1;
			needs_chile = 0;
			needs_onion = 1;
			needs_tomato = 0;
			needs_lettuce = 1;
			break;

		case 5:
			dish_name_label.text = "Clasica de Atun";
			ingredient_slot_01.sprite = tuna_meat;
			ingredient_slot_02.sprite = sliced_lettuce;
			ingredient_slot_03.sprite = sliced_tomato;
			ingredient_slot_04.sprite = empty_sprite;
			needs_tuna = 1;
			needs_chile = 0;
			needs_onion = 0;
			needs_tomato = 1;
			needs_lettuce = 1;
			break;

		case 6:
			dish_name_label.text = "Ensalada Verde Picante";
			ingredient_slot_01.sprite = tuna_meat;
			ingredient_slot_02.sprite = sliced_lettuce;
			ingredient_slot_03.sprite = sliced_chile;
			ingredient_slot_04.sprite = empty_sprite;
			needs_tuna = 1;
			needs_chile = 1;
			needs_onion = 0;
			needs_tomato = 0;
			needs_lettuce = 1;
			break;

		case 7:
			dish_name_label.text = "Atun Picante sin Lechuga";
			ingredient_slot_01.sprite = tuna_meat;
			ingredient_slot_02.sprite = sliced_chile;
			ingredient_slot_03.sprite = sliced_onion;
			ingredient_slot_04.sprite = sliced_tomato;
			needs_tuna = 1;
			needs_chile = 1;
			needs_onion = 1;
			needs_tomato = 1;
			needs_lettuce = 0;
			break;

		case 8:
			dish_name_label.text = "Atun Picante sin Tomate";
			ingredient_slot_01.sprite = tuna_meat;
			ingredient_slot_02.sprite = sliced_chile;
			ingredient_slot_03.sprite = sliced_onion;
			ingredient_slot_04.sprite = sliced_lettuce;
			needs_tuna = 1;
			needs_chile = 1;
			needs_onion = 1;
			needs_tomato = 0;
			needs_lettuce = 1;
			break;

		case 9:
			dish_name_label.text = "Atun Picante sin Cebolla";
			ingredient_slot_01.sprite = tuna_meat;
			ingredient_slot_02.sprite = sliced_chile;
			ingredient_slot_03.sprite = sliced_tomato;
			ingredient_slot_04.sprite = sliced_lettuce;
			needs_tuna = 1;
			needs_chile = 1;
			needs_onion = 0;
			needs_tomato = 1;
			needs_lettuce = 1;
			break;

		case 10:
			dish_name_label.text = "Clasica de Atun sin Picante";
			ingredient_slot_01.sprite = tuna_meat;
			ingredient_slot_02.sprite = sliced_chile;
			ingredient_slot_03.sprite = sliced_tomato;
			ingredient_slot_04.sprite = sliced_lettuce;
			needs_tuna = 1;
			needs_chile = 0;
			needs_onion = 1;
			needs_tomato = 1;
			needs_lettuce = 1;
			break;

		default:
			break;
		}

		total_ingredients = needs_tuna + needs_chile + needs_lettuce + needs_onion + needs_tomato;
		total_points = total_ingredients * 100;
	}

	IEnumerator PopRoutine()
	{
		transform.DOScale (Vector3.zero, 0.5f);
		yield return new WaitForSeconds (0.5f);
		Destroy (gameObject);
	}
}
