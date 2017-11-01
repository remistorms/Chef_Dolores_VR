using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Raycaster : MonoBehaviour {

	public static Raycaster instance;
	public GameObject held_item;
	public GameObject obj_in_sight;
	public Transform hold_position;
	Ray myRay;
	RaycastHit myHit;
	public AudioSource player_audio_source;

	void Start()
	{
		instance = this;
		player_audio_source = GetComponent<AudioSource> ();
	}

	void FixedUpdate()
	{
		myRay = new Ray (transform.position, transform.forward);
		Debug.DrawRay (transform.position, transform.forward, Color.red);

		if (Physics.Raycast (myRay, out myHit)) {
			if (myHit.collider == true) 
			{
				obj_in_sight = myHit.collider.gameObject;
			}
		} 
		else 
		{
			obj_in_sight = null;
			Trash_Script.instance.CloseLid ();
		}

		if (obj_in_sight != null && obj_in_sight.name == "help_trigger_abrelatas") 
		{
			//Help_UI_Script.instance.ShowAbrelatasHelp ();		
		}

		if (obj_in_sight != null && obj_in_sight.name == "help_trigger_tabla") 
		{
			//Help_UI_Script.instance.ShowTablaHelp ();		
		}

		if (obj_in_sight != null && obj_in_sight.name == "help_trigger_ingredientes") 
		{
			//Help_UI_Script.instance.ShowIngredientesHelp ();		
		}

		if (obj_in_sight != null && obj_in_sight.tag == "trash") 
		{
			Trash_Script.instance.OpenLid ();	
		}
	}

	void Update()
	{
		//Checks to see if player holds tuna fish can and checks if is looking at can opener
		if (held_item != null && held_item.name == "atun" && obj_in_sight!= null && obj_in_sight.name == "can_opener" ) 
		{
			if (obj_in_sight.GetComponent<Can_opener_script>().has_can == false) 
			{
				held_item.transform.parent = obj_in_sight.transform;
				held_item.transform.DOLocalMove (Vector3.zero, 0.2f);
				held_item.transform.DOLocalRotate (Vector3.zero, 0.2f);
				obj_in_sight.GetComponent<Can_opener_script> ().has_can = true;
				Sound_Manager.instance.PlaySoundFX (player_audio_source, 2, 0);
				held_item = null;
			}

		}

		//Checks to see if player holds veggetable ingredient
		if (held_item != null && held_item.tag == "raw_ingredient" && obj_in_sight!= null && obj_in_sight.name == "chopping_board" && held_item.GetComponent<Ingredient_Script>().ingredient != Ingredient_Script.ingredient_type.tuna_fish_can) 
		{
			if (obj_in_sight.GetComponent<Chopping_Board>().has_ingredient == false) 
			{
				held_item.transform.parent = obj_in_sight.transform;
				held_item.transform.DOLocalMove (Vector3.zero, 0.2f);
				held_item.transform.DOLocalRotate (Vector3.zero, 0.2f);
				obj_in_sight.GetComponent<Chopping_Board> ().has_ingredient = true;
				Sound_Manager.instance.PlaySoundFX (player_audio_source, 2, 0);
				held_item = null;
			}

		}
			

		if (Input.GetButtonDown("Jump") || Input.GetButtonDown("Fire1") || Input.GetButtonDown("Fire2") || Input.GetButtonDown("Fire3") || Input.GetMouseButtonDown(0)) 
		{
			if (obj_in_sight!= null && (obj_in_sight.tag == "raw_ingredient" || obj_in_sight.tag == "ingredient")  && hold_position.childCount == 0) {
				obj_in_sight.transform.parent = hold_position;
				obj_in_sight.transform.DOLocalMove (Vector3.zero, 0.2f);
				obj_in_sight.transform.DOLocalRotate (Vector3.zero, 0.2f);
				held_item = obj_in_sight;
				Sound_Manager.instance.PlaySoundFX (player_audio_source, 2, 0);
				Debug.Log ("Clicked on ingredient" + obj_in_sight.name);

			} 

			else if (obj_in_sight!= null && obj_in_sight.tag == "button") {
				obj_in_sight.GetComponent<Collider_Button> ().ActivateButton ();
			} 

			else if (obj_in_sight!= null && obj_in_sight.tag == "trash" && held_item != null) {
				Trash_Script.instance.TrowGarbage (held_item);
			} 
		}

	}
}
