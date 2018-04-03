using UnityEngine;
using UnityEngine.UI;
using Kaibrary.UIForge;
using HalcyonCore;
using System.Collections;



public class CurtainBehaviour : MonoBehaviour
{
	[SerializeField] RawImage imgCtrl;
	public event LightweightHandler completed;  //when fade-out is completed trigger this event


	void OnEnable()
	{
		transform.SetAsFirstSibling();
	}

	public void curtainFadeOut()
	{
		StartCoroutine(FadeOut());
	}

	public void curtainFadeIn()
	{
		StartCoroutine(FadeIn());
	}


	IEnumerator FadeOut()
	{
		yield return StartCoroutine(UIForge.alphaFadeOut(imgCtrl));

		if (completed != null)
			completed();

		yield break;
	}
	
	IEnumerator FadeIn()
	{
		yield return StartCoroutine(UIForge.alphaFadeIn(imgCtrl));

		yield break;
	}


	//Events Add, Remove

	public void addListener(LightweightHandler call)
	{
		completed += call;
	}

	public void removeListener(LightweightHandler call)
	{
		completed -= call;
	}

	public void removeAllListener()
	{
		completed = null;
	}
}
