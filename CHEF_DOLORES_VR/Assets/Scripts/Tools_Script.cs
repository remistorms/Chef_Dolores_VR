using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Tools_Script : MonoBehaviour {

	public GameObject[] tools_objects;
	public static Tools_Script instance;

	void Awake()
	{
		instance = this;
	}

	public void DissapearTools()
	{
		StartCoroutine (DissapearRoutine ());
	}

	IEnumerator DissapearRoutine()
	{
		Debug.Log ("SHRINK OBJECTS NOW");
		for (int i = 0; i < tools_objects.Length; i++) 
		{
			tools_objects [i].transform.DOScale (Vector3.zero, 0.3f);
			yield return new WaitForSeconds (0.2f);
		}
	}


}
