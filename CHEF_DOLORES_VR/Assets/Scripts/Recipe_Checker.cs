using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Recipe_Checker : MonoBehaviour {

	public Raycaster raycaster_reference;
	GameObject obj_in_sight_ref;
	GameObject held_item_ref;
	Dish_Script dish_script_ref;


	void Update()
	{
		if (Input.GetButtonDown("Jump") || Input.GetButtonDown("Fire1") || Input.GetButtonDown("Fire2") || Input.GetButtonDown("Fire3") || Input.GetMouseButtonDown(0)) 
		{
			CheckRecipe ();	
		}
	}

	public void CheckRecipe()
	{
		//Checking for recipe
		if (raycaster_reference.obj_in_sight != null && raycaster_reference.obj_in_sight.tag == "dish") 
		{
			obj_in_sight_ref = raycaster_reference.obj_in_sight;
			dish_script_ref = obj_in_sight_ref.GetComponent<Dish_Script> ();

			if (raycaster_reference.held_item != null) 
			{
				held_item_ref = raycaster_reference.held_item;

				if (held_item_ref.name == dish_script_ref.ingredient_slot_01.sprite.name) 
				{
					
					held_item_ref.transform.parent = dish_script_ref.bow_position.transform;
					held_item_ref.transform.DOMove (dish_script_ref.bow_position.transform.position, 0.2f);
					held_item_ref.transform.DORotate (Vector3.zero, 0.2f);
					raycaster_reference.held_item = null;
					//change sprite to checkmark
					dish_script_ref.ingredient_slot_01.sprite = dish_script_ref.checkmark;
					//WILL THIS WORK?
					dish_script_ref.total_ingredients = dish_script_ref.total_ingredients - 1;
				}

				if (held_item_ref.name == dish_script_ref.ingredient_slot_02.sprite.name) 
				{
					held_item_ref.transform.parent = dish_script_ref.bow_position.transform;
					held_item_ref.transform.DOMove (dish_script_ref.bow_position.transform.position, 0.2f);
					held_item_ref.transform.DORotate (Vector3.zero, 0.2f);
					raycaster_reference.held_item = null;
					//change sprite to checkmark
					dish_script_ref.ingredient_slot_02.sprite = dish_script_ref.checkmark;
					//WILL THIS WORK?
					dish_script_ref.total_ingredients = dish_script_ref.total_ingredients - 1;
				}

				if (held_item_ref.name == dish_script_ref.ingredient_slot_03.sprite.name) 
				{
					held_item_ref.transform.parent = dish_script_ref.bow_position.transform;
					held_item_ref.transform.DOMove (dish_script_ref.bow_position.transform.position, 0.2f);
					held_item_ref.transform.DORotate (Vector3.zero, 0.2f);
					raycaster_reference.held_item = null;
					//change sprite to checkmark
					dish_script_ref.ingredient_slot_03.sprite = dish_script_ref.checkmark;
					//WILL THIS WORK?
					dish_script_ref.total_ingredients = dish_script_ref.total_ingredients - 1;
				}

				if (held_item_ref.name == dish_script_ref.ingredient_slot_04.sprite.name) 
				{
					held_item_ref.transform.parent = dish_script_ref.bow_position.transform;
					held_item_ref.transform.DOMove (dish_script_ref.bow_position.transform.position, 0.2f);
					held_item_ref.transform.DORotate (Vector3.zero, 0.2f);
					raycaster_reference.held_item = null;
					//change sprite to checkmark
					dish_script_ref.ingredient_slot_04.sprite = dish_script_ref.checkmark;
					//WILL THIS WORK?
					dish_script_ref.total_ingredients = dish_script_ref.total_ingredients - 1;
				}

				if (dish_script_ref.total_ingredients == 0) 
				{
					StartCoroutine (FinishDishRoutine ());
				}

			}
		}
	}

	//THIS HAPPENS WHEN THE DISH IS COMPLETE; HERE YOU CAN EVEN PUT THE SCORE SCRIPTING
	IEnumerator FinishDishRoutine()
	{
		yield return new WaitForSeconds (0.5f);
		dish_script_ref.DishFinished ();

	}
}


