using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.VR;

public class VRMODESCRIPT : MonoBehaviour {

	public bool vr_enabled = false;

	void Awake()
	{
		VRSettings.enabled = vr_enabled;
	}
}
