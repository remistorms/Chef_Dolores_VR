using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item_holder : MonoBehaviour {

	public Dispenser_Script dispenser_script_ref;

	void Awake()
	{
		dispenser_script_ref = GetComponentInParent<Dispenser_Script> ();
	}
	void OnTriggerExit(Collider other)
	{
		if (other.tag == "raw_ingredient") 
		{
			dispenser_script_ref.item_spawned = false;	
		}
	}
}
