using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BotonCadena : MonoBehaviour {

	public Text cadena_label;
	public Button cadena_button;

	void Awake()
	{
		cadena_label = GetComponentInChildren<Text> ();
		cadena_button = GetComponent<Button> ();
		cadena_button.onClick.AddListener (SetCadena);
	}

	void SetCadena()
	{
		Datos_Script.instance.cadena = cadena_label.text;
		Web_Services.instance.GetPremios ();
	}
}
