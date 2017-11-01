using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BotonPlaza : MonoBehaviour {

	public Text plaza_label;
	public Button plaza_button;

	void Awake()
	{
		plaza_label = GetComponentInChildren<Text> ();
		plaza_button = GetComponent<Button> ();
		plaza_button.onClick.AddListener (SetPlaza);
	}

	void SetPlaza()
	{
		Datos_Script.instance.plaza = plaza_label.text;
	}
}
