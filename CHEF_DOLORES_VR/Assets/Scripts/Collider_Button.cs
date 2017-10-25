using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collider_Button : MonoBehaviour {

	public Dispenser_Script dispenser_script_ref;

	void Awake()
	{
		this.gameObject.tag = "button";
		dispenser_script_ref = GetComponentInParent<Dispenser_Script> ();
	}

	public void ActivateButton()
	{
		dispenser_script_ref.ActivateDispenser ();	
	}
}
