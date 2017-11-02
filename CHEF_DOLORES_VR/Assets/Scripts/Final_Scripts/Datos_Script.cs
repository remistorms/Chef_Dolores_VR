using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Datos_Script : MonoBehaviour {

	public string nombre, ticket, plaza, cadena, premio;

	public static Datos_Script instance;

	void Awake()
	{
		instance = this;
	}

	//GUARDAR LOS DATOS EN ALGUN LUGAR

	public void SaveResults()
	{
		PlayerPrefs.SetString ("Last_Nombre", nombre);
		PlayerPrefs.SetString ("Last_Ticket", ticket);
		PlayerPrefs.SetString ("Last_Plaza", plaza);
		PlayerPrefs.SetString ("Last_Cadena", cadena);
		PlayerPrefs.SetString ("Last_Premio", premio);
		string fecha = System.DateTime.Now.ToString("yyyyMMdd");
		PlayerPrefs.SetString("Last_Fecha", fecha);

		//AQUI FALTA VER EL PUNTAJE DE ACUERDO AL PREMIO SELECCIONADO
	}

}
