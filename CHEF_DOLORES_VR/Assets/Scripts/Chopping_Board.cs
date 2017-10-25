using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chopping_Board : MonoBehaviour {

	public bool has_ingredient = false;
	public bool is_chopping = false;
	public GameObject chopped_chile, chopped_onion, chopped_letuce, chopped_tomato;
	public Animator chopping_board_animator;
	GameObject object_to_chop;
	GameObject chopped_veggie_to_spawn;


	void FixedUpdate()
	{
		if (has_ingredient == true && is_chopping == false) 
		{
			StartCoroutine (ChopIngredientCoRoutine ());	
		}
	}

	IEnumerator ChopIngredientCoRoutine()
	{
		is_chopping = true;
		chopping_board_animator.SetTrigger ("chop");
		yield return new WaitForSeconds (1.5f);
		SelectVeggie (object_to_chop);
		GameObject chopped = Instantiate (chopped_veggie_to_spawn, transform.position, Quaternion.identity) as GameObject;
		chopped.name = chopped_veggie_to_spawn.name.ToString ();
		Destroy (object_to_chop);
		//is_chopping = false;
		yield return new WaitForSeconds(1.0f);
		ResetChoppingBoard ();

	}

	void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.GetComponent<Ingredient_Script>() != null && other.gameObject.tag == "raw_ingredient" ) 
		{
			has_ingredient = true;
			object_to_chop = other.gameObject;
		}
	}

	void OnTriggerExit(Collider other)
	{
		if (other.gameObject.tag == "ingredient") 
		{
			has_ingredient = false;	
			is_chopping = false;
		}
	}

	public void ResetChoppingBoard()
	{
		has_ingredient = false;	
		is_chopping = false;
	}
		

	void SelectVeggie(GameObject veggie)
	{
		switch (veggie.name) 
		{
			case "tomato":
			chopped_veggie_to_spawn = chopped_tomato;
			break;

			case "chiles":
			chopped_veggie_to_spawn = chopped_chile;
			break;

			case "onion":
			chopped_veggie_to_spawn = chopped_onion;
			break;

			case "lettuce":
			chopped_veggie_to_spawn = chopped_letuce;
			break;


		
		default:
			break;
		}
	}

}
