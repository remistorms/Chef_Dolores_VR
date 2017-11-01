using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Usuario_Script : MonoBehaviour {
	
	public InputField nombre, ticket;
	public Button next_button;

	void Update()
	{
		if (nombre.text == "" || ticket.text == "") {
			next_button.interactable = false;	
		} 
		else 
		{
			next_button.interactable = true;	
		}
	}

	public void SetDatos()
	{
		Datos_Script.instance.nombre = nombre.text.ToString ();
		Datos_Script.instance.ticket = ticket.text.ToString ();
	}

}
