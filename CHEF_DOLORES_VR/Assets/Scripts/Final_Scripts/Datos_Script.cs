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

}
