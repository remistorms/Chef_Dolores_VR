using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PreGameScreen : MonoBehaviour {

	public Text nombre_label, ticket_label, plaza_label, cadena_label, premio_label;

	void FixedUpdate()
	{
		nombre_label.text = "Nombre: " + Datos_Script.instance.nombre;
		ticket_label.text = "Ticket: " + Datos_Script.instance.ticket;
		plaza_label.text = "Plaza: " + Datos_Script.instance.plaza;
		cadena_label.text = "Cadena: " + Datos_Script.instance.cadena;
		premio_label.text = "Premio: " + Datos_Script.instance.premio;
	}
}
