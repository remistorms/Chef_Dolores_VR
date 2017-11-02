using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SendPremio : MonoBehaviour {

	//GANO O PERDIO
	public string resultado_de_juego;

	public void SendNewPremio()
	{
		string insert_premio_string = "http://www.ispinnova.com.mx/app2017/insert_premio.php?i=" + PlayerPrefs.GetString ("Last_Nombre") + "&f=" + System.DateTime.Now.ToString("yyyyMMdd") + "&p=" + PlayerPrefs.GetString("Last_Premio") + "&n=" + PlayerPrefs.GetString("Last_Name").Replace("/","").Replace("#","").Replace("'","").Replace("@","").Replace("Ñ","N").Replace("ñ","n") + "&t=" + PlayerPrefs.GetString("Last_Ticket").Replace("/","").Replace("#","").Replace("'","").Replace("@","").Replace("Ñ","N").Replace("ñ","n") + "&r=" + resultado_de_juego + "&l=" + PlayerPrefs.GetInt("Last_Puntaje"); 

		if (Manager_Web.instance.CheckInternetConection ()) 
		{
			//Si hay internet

			string respuesta_peticion_insert_premio = Manager_Web.instance.HttpGet (insert_premio_string);

			if (respuesta_peticion_insert_premio == "1") 
			{
				//Clear Player Prefs
				PlayerPrefs.SetString("url_pendiente", "");
				// MOSTRAR PANTALLA DE POST GAME GANO O PIERDE
				//MainUI.instance.ShowPostGameScreen();
			} 

			else 
			{
				// Almacena en player prefs el insert premio string
				PlayerPrefs.SetString("url_pendiente", insert_premio_string);
				//MOSTRAR PANTALLA DE POST GAME GANE O PIERDA
				//MainUI.instance.ShowPostGameScreen();
			}
		} 

		else 
		{
			// Almacena en player prefs el insert premio string
			PlayerPrefs.SetString("url_pendiente", insert_premio_string);
			//MOSTRAR PANTALLA DE POST GAME GANE O PIERDA
			//MainUI.instance.ShowPostGameScreen();
		}
	}

}
