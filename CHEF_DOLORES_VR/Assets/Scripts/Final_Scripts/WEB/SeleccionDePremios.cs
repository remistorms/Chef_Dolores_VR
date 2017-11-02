using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SeleccionDePremios : MonoBehaviour {

	public GameObject premio_button_prefab;
	public GameObject buttons_container;
	public List<string> premios_list = new List<string>();
	public List<GameObject> botones_creados = new List<GameObject> ();
	public Web_Services web_services;
	public int tempInt;

	public void PopulatePremioButtons()
	{
		ClearPremioList ();
		
		web_services.FillAllStrings ();
		premios_list = web_services.premios;
		Debug.Log ("web services premios list count = " + web_services.premios.Count.ToString ());

		for (int i = 0; i < web_services.premios.Count; i++) 
		{
			Debug.Log ("Create Button");
			GameObject premio_btn = Instantiate (premio_button_prefab, buttons_container.transform) as GameObject;
			premio_btn.transform.SetParent (buttons_container.transform);
			botones_creados.Add (premio_btn);
			premio_btn.name = web_services.premios [i];
			premio_btn.GetComponentInChildren<Text> ().text = web_services.premios [i];
			tempInt = i;
			premio_btn.GetComponent<Button> ().onClick.AddListener (() => PremioButtonClick (tempInt));

		}
	}

	public void ClearPremioList()
	{
		premios_list.Clear ();
		botones_creados.Clear ();
		for (int i = 0; i < buttons_container.transform.childCount; i++) 
		{
			Destroy (buttons_container.transform.GetChild (i).gameObject);	
		}
	}

	void PremioButtonClick(int myint)
	{
		//Aqui se hara lo de el boton premio
		Debug.Log("A premio button has been clicked No:" + myint);
	}

	/*
	 premios_list = new List<string> ();
		botones_creados = new List<GameObject> ();
		premios_list.Clear ();
		botones_creados.Clear ();
		foreach (var item in botones_creados) 
		{
			Destroy (item);	
		}

*/


}
