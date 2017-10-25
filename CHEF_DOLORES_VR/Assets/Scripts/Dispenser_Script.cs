using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Dispenser_Script : MonoBehaviour {

	 Animator dispenser_animator;
	public GameObject ingredient;
	public Transform start_point, end_point;
	GameObject dispensed_ingredient;
	public bool item_spawned = false;

	void Awake()
	{
		dispenser_animator = GetComponentInChildren<Animator> ();
	}

	void Update()
	{
		if (Input.GetKeyDown(KeyCode.S)) {
			ActivateDispenser ();
		}
	}

	public void ActivateDispenser()
	{
		if (item_spawned == false) {
			item_spawned = true;
			//fires up button press animation
			dispenser_animator.SetTrigger ("Press_Button");
			//Play Item Dropped Sound

			dispensed_ingredient = Instantiate(ingredient, start_point.transform.position, Quaternion.identity) as GameObject;
			dispensed_ingredient.name = ingredient.name.ToString();
			dispensed_ingredient.transform.localScale = new Vector3 (0.1f, 0.1f, 0.1f);
			dispensed_ingredient.transform.DOMove (end_point.transform.position, 0.2f);
			dispensed_ingredient.transform.DOScale (new Vector3 (1, 1, 1), 0.2f);

		} 
		else 
		{
			Debug.Log ("Ingredient already out... take it out before getting a new one");
			//Play error sound
		}

	}

	void OnTriggerExit(Collider other)
	{
			item_spawned = false;

	}
}
