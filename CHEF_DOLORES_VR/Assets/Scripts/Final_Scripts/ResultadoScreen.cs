using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ResultadoScreen : MonoBehaviour {

	public Text nombre_label, ticket_label, plaza_label, cadena_label, premio_label, platillos_label, puntos_label, fecha_label;

	void FixedUpdate()
	{
		nombre_label.text = "Nombre: " + PlayerPrefs.GetString ("Last_Nombre");
		ticket_label.text = "Ticket: " + PlayerPrefs.GetString ("Last_Ticket");
		plaza_label.text = "Plaza: " + PlayerPrefs.GetString ("Last_Plaza");
		cadena_label.text = "Cadena: " + PlayerPrefs.GetString ("Last_Cadena");
		premio_label.text = "Premio: " + PlayerPrefs.GetString ("Last_Premio");
		platillos_label.text = "Platillos: " + PlayerPrefs.GetInt ("Last_Platillos");
		puntos_label.text = "Puntos: " + PlayerPrefs.GetInt ("Last_Puntos") + " / " + PlayerPrefs.GetString("ScoreNeeded");
		fecha_label.text = "Fecha y hora: " + PlayerPrefs.GetString ("Last_Fecha");
	}
}