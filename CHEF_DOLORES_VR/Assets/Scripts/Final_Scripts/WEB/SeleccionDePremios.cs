using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SeleccionDePremios : MonoBehaviour {

	public GameObject premio_button_prefab;
	public GameObject buttons_container;
	public List<string> premios_list;
	public Web_Services web_services;

	void OnEnable()
	{
		web_services.FillAllStrings ();
		premios_list = web_services.premios;

		for (int i = 0; i < premios_list.Count; i++) 
		{
			GameObject premio_btn = Instantiate (premio_button_prefab, buttons_container.transform) as GameObject;
			premio_btn.transform.SetParent (buttons_container.transform);
		}
	}


}
