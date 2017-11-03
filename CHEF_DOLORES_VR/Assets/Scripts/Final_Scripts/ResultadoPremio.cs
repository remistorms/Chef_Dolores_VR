using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ResultadoPremio : MonoBehaviour {

	public static ResultadoPremio instance;
	public Text info_text;
	public Text coneccion_resultado;
	public Button btn_aceptar;
	Color button_color;

	void Awake()
	{
		instance = this;
		button_color = btn_aceptar.image.color;
	}

	void OnEnable()
	{
		info_text.text = "Nombre: " + PlayerPrefs.GetString ("Last_Nombre") + "\n" +
		"Ticket: " + PlayerPrefs.GetString ("Last_Ticket") + "\n" +
		"Premio: " + PlayerPrefs.GetString ("Last_Premio") + "\n" +
		"Resultado: " + PlayerPrefs.GetString ("Resultado");
	}

	public void ShowConeccionResultado(string myString)
	{
		coneccion_resultado.text = myString;
	}

	public void DisableButtonRoutine()
	{
		StartCoroutine (DisableButton ());
	}

	IEnumerator DisableButton()
	{
		btn_aceptar.enabled = false;
		btn_aceptar.GetComponentInChildren<Text> ().text = "ESPERANDO RESPUESTA...";
		btn_aceptar.image.color = Color.gray;
		yield return new WaitForSeconds (10);
		btn_aceptar.enabled = true;
		btn_aceptar.image.color = button_color;
		btn_aceptar.GetComponentInChildren<Text>().text = "ENVIAR PREMIO";
	}
}
