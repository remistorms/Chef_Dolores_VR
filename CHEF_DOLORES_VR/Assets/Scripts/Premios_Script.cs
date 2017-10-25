using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class Premios_Script : MonoBehaviour {

	int selected_premio;
	public Button[] premio_button;
	public Color unselected_color, selected_color;

	void Awake()
	{
		unselected_color = premio_button [0].image.color;
	}

	public void SelectPremio(int id)
	{
		foreach (var item in premio_button) 
		{
			item.image.color = unselected_color;	
		}

		premio_button [id].image.color = selected_color;
		selected_premio = id;
	}

}
