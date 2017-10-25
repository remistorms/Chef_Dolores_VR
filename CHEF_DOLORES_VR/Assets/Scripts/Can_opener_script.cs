using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Can_opener_script : MonoBehaviour {

	public bool has_can = false;
	public Animator can_animator;
	public GameObject meat;
	public Transform meat_spawner;
	bool has_finished = true;

	void FixedUpdate()
	{
		if (has_can == true && has_finished == true) 
		{
			has_finished = false;
			StartCoroutine (CanCoRoutine ());	
		}
	}

	IEnumerator CanCoRoutine()
	{
		can_animator.SetTrigger ("activate");
		yield return new WaitForSeconds (2.5f);
		//Destroys the can mesh game object
		Destroy (transform.GetChild (0).gameObject);
		GameObject tuna_meat = Instantiate (meat, transform.position, Quaternion.Euler(0,0,0)) as GameObject;
		tuna_meat.name = "tuna_meat";
		tuna_meat.tag = "ingredient";
		tuna_meat.transform.DOMove (meat_spawner.transform.position, 0.2f);
		//tuna_meat.GetComponentInChildren<Animator> ().SetTrigger ("tuna_ready");
		has_finished = true;
		has_can = false;
	}

}
