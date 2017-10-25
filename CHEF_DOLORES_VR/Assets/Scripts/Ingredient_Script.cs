using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ingredient_Script : MonoBehaviour {

	public enum ingredient_type {tomato, chopped_tomato, onion, chopped_onion, lettuce, chopped_lettuche, chile, chopped_chile, tuna_fish_can, tuna_fish_meat }

	public ingredient_type ingredient;

	void Awake()
	{
		switch (ingredient) 
		{

			//RAW INGREDIENTS
			case ingredient_type.chile:
			this.tag = "raw_ingredient";
			break;

			case ingredient_type.lettuce:
			this.tag = "raw_ingredient";
			break;

			case ingredient_type.tomato:
			this.tag = "raw_ingredient";
			break;

			case ingredient_type.onion:
			this.tag = "raw_ingredient";
			break;

			case ingredient_type.tuna_fish_can:
			this.tag = "raw_ingredient";
			break;

			//INGREDIENTS

			case ingredient_type.chopped_chile:
			this.tag = "ingredient";
			break;

			case ingredient_type.chopped_lettuche:
			this.tag = "ingredient";
			break;

			case ingredient_type.chopped_onion:
			this.tag = "ingredient";
			break;

			case ingredient_type.chopped_tomato:
			this.tag = "ingredient";
			break;

			case ingredient_type.tuna_fish_meat:
			this.tag = "ingredient";
			break;



		default:
			break;
		}
	}

}
