using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using DG.Tweening;

public class Trash_Script : MonoBehaviour {

	public static Trash_Script instance;
	public Canvas trash_canvas;
	public Animator trash_animator;
	public Transform trash_end_point;
	public Vector3 original_scale;
	public bool lid_up = false;

	void Awake()
	{
		instance = this;
		trash_canvas.transform.localPosition = new Vector3 (0, 0.5f, 0);
		trash_canvas.transform.localScale = Vector3.zero;
		original_scale = transform.localScale;
	}

	public void TrowGarbage(GameObject garbage)
	{
		Debug.Log ("THROW GARBAGE");
		garbage.transform.parent = null;
		garbage.transform.DOMove (trash_end_point.position, 0.3f);
		garbage.transform.DOScale (Vector3.zero, 0.3f);
		StartCoroutine (animate_can ());
		Destroy (garbage, 0.3f);
	}


	public void OpenLid()
	{
		trash_animator.SetBool ("lid_up", true);
		trash_canvas.transform.DOScale (new Vector3 (0.001f, 0.001f, 0.001f), 0.2f);
		trash_canvas.transform.DOLocalMove (new Vector3 (0, 1.5f, 0), 0.2f);
	}

	public void CloseLid()
	{
		trash_animator.SetBool ("lid_up", false);
		trash_canvas.transform.DOScale (Vector3.zero, 0.2f);
		trash_canvas.transform.DOLocalMove (Vector3.zero, 0.2f);
	}

	IEnumerator animate_can()
	{
		transform.DOScaleY (original_scale.y + 0.1f, 0.1f);
		yield return new WaitForSeconds (0.1f);
		transform.DOScaleY (original_scale.y, 0.1f);
	}
}
