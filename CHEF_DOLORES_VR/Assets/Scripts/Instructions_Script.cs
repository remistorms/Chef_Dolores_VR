using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Instructions_Script : MonoBehaviour {

	public int current_tip_number;
	public Text tips_title_label, public_main_label;
	public string[] tips_text;
	public GameObject[] arrow_colliders;


	void Start()
	{
		tips_title_label.text = "instrucciones (1/6)";
		public_main_label.text = tips_text [0];
		current_tip_number = 0;
	}

	/*
	void Update()
	{
		if (Input.GetKeyDown(KeyCode.N)) {
			NextTip ();
		}

		if (Input.GetKeyDown(KeyCode.P)) {
			PreviousTip ();
		}
	}*/

	public void NextTip()
	{
		//Do things to show next tip
		if (current_tip_number < tips_text.Length - 1) 
		{
			current_tip_number++;
			tips_title_label.text = "instrucciones (" + (1+current_tip_number).ToString () + "/6)";
			public_main_label.text = tips_text [current_tip_number];
		}
	}

	public void PreviousTip()
	{
		if (current_tip_number > 0) 
		{
			current_tip_number = current_tip_number - 1;	
			tips_title_label.text = "instrucciones (" + (1+current_tip_number).ToString () + "/6)";
			public_main_label.text = tips_text [current_tip_number];
		}
	}
}
