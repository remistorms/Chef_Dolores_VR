using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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

	public void SendPremio()
	{
		//PON AQUI LODE PREMIOS
		string insert_premio_string = "http://www.ispinnova.com.mx/app2017/insert_premio.php?i=" + PlayerPrefs.GetString ("Last_Cadena") + "&f=" + System.DateTime.Now.ToString("yyyyMMdd") + "&p=" + PlayerPrefs.GetString("Last_Premio") + "&n=" + PlayerPrefs.GetString("Last_Nombre").Replace("/","").Replace("#","").Replace("'","").Replace("@","").Replace("Ñ","N").Replace("ñ","n") + "&t=" + PlayerPrefs.GetString("Last_Ticket").Replace("/","").Replace("#","").Replace("'","").Replace("@","").Replace("Ñ","N").Replace("ñ","n") + "&r=" + PlayerPrefs.GetString("Resultado") + "&l=" + PlayerPrefs.GetInt("Last_Puntos");
	
		if (Manager_Web.instance.CheckInternetConection ()) 
		{
			//Si hay internet

			string respuesta_peticion_insert_premio = Manager_Web.instance.HttpGet (insert_premio_string);

			if (respuesta_peticion_insert_premio == "1") 
			{
				//TAKE TO MAIN SCREEN
				ResultadoPremio.instance.ShowConeccionResultado("PREMIO ENVIADO");
				EndMenu.instance.LoadScene(0);
			} 

			else 
			{
				//NO HAY INTERNET INTENTE DE NUEVO
				ResultadoPremio.instance.ShowConeccionResultado("ERROR DE ENVIO, INTENTAR NUEVAMENTE");
			}
		} 

		else 
		{
			// Almacena en player prefs el insert premio string
			//PlayerPrefs.SetString("url_pendiente", insert_premio_string);
			//MOSTRAR PANTALLA DE POST GAME GANE O PIERDA
			//MainUI.instance.ShowPostGameScreen();

			//NO HAY INTERNET INTENTE DE NUEVO
			ResultadoPremio.instance.ShowConeccionResultado("ERROR DE CONECCION, INTENTAR NUEVAMENTE");
		}
	}

}
