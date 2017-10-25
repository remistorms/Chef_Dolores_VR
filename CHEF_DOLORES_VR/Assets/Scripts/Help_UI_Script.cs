using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class Help_UI_Script : MonoBehaviour {

	public static Help_UI_Script instance;
	public GameObject tabla_canvas, ingredientes_canvas, abrelatas_canvas;

	void Awake()
	{
		instance = this;
		tabla_canvas.transform.localScale = Vector3.zero;
		ingredientes_canvas.transform.localScale = Vector3.zero;
		abrelatas_canvas.transform.localScale = Vector3.zero;
	}

	public void ShowTablaHelp()
	{
		tabla_canvas.transform.DOScale (new Vector3(0.0017f, 0.0017f, 0.0017f), 0.5f);
	}

	public void ShowIngredientesHelp()
	{
		ingredientes_canvas.transform.DOScale (new Vector3(0.0017f, 0.0017f, 0.0017f), 0.5f);
	}

	public void ShowAbrelatasHelp()
	{
		abrelatas_canvas.transform.DOScale (new Vector3(0.0017f, 0.0017f, 0.0017f), 0.5f);
	}

	public void HideAllHelp()
	{
		abrelatas_canvas.transform.DOScale (Vector3.zero, 0.25f);
		tabla_canvas.transform.DOScale (Vector3.zero, 0.25f);
		ingredientes_canvas.transform.DOScale (Vector3.zero, 0.25f);
	}


}
