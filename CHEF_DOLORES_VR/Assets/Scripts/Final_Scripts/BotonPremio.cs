using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BotonPremio : MonoBehaviour {

	public Text premio_label;
	public Button premio_button;
	public int myIndex;

	void Awake()
	{
		premio_label = GetComponentInChildren<Text> ();
		premio_button = GetComponent<Button> ();
		premio_button.onClick.AddListener (SetPremio);
	}

	void SetPremio()
	{
		Datos_Script.instance.premio = premio_label.text;
		myIndex = Web_Services.instance.premios.IndexOf (premio_label.text);
		PlayerPrefs.SetString ("ScoreNeeded", Web_Services.instance.puntaje[myIndex]);
		Menu_Script.instance.SwapMenuScreen (14);
	}


}
