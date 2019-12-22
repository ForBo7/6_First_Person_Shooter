using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisplayBloodSplatter : MonoBehaviour
{
	[SerializeField] Canvas bloodVFXCanvas;
	[SerializeField] float impactTime;

	private void Start()
	{
		bloodVFXCanvas.enabled = false;
	}

	public void ShowBloodVFX()
	{
		StartCoroutine(ShowBloodSplatter());
	}

	IEnumerator ShowBloodSplatter()
	{
		bloodVFXCanvas.enabled = true;
		yield return new WaitForSeconds(impactTime);
		bloodVFXCanvas.enabled = false;
	}
}
