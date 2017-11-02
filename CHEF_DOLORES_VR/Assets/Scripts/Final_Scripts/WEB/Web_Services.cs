using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Web_Services : MonoBehaviour {

	public static Web_Services instance;

	// Strings
	public string full_string_to_send;
	public string super_string_lista;
	public string[] premio_puntaje;
	public  List<string> premios;
	public  List<string> puntaje;

	public int puntos_necesarios;

	void Awake()
	{
		instance = this;
	}

	public void FillAllStrings()
	{
		ClearPremios ();
		
		full_string_to_send = "http://www.ispinnova.com.mx/app2017/get_premios.php?" + "i=" + Datos_Script.instance.cadena; 

			super_string_lista = Manager_Web.instance.HttpGet (full_string_to_send);
			premio_puntaje = super_string_lista.Split ('|');

		for (int i = 0; i < premio_puntaje.Length - 1; i++) {
			string[] temp_string = premio_puntaje [i].Split (',');
				premios.Insert (i, temp_string [0]);
				puntaje.Insert (i, temp_string [1]);
			}

	}

	void Update()
	{

	}

	public void GetPremios()
	{
		FillAllStrings ();
	}

	public void ClearPremios()
	{
		super_string_lista = "";
		premios.Clear ();
		puntaje.Clear ();
	}

}
