using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class MainMenuCam : MonoBehaviour {

	public Vector3 rotation_vector;
	public float rotation_time = 1200f;
	void Start()
	{
		transform.DOLocalRotate (rotation_vector, rotation_time, RotateMode.LocalAxisAdd);
	}

}
