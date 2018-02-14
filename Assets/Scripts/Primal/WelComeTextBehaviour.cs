using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using Kaibrary.UIForge;


namespace PrimalScene
{
	public class WelComeTextBehaviour : MonoBehaviour
	{
		[SerializeField] RawImage imgCtrl;

		WaitForSeconds delayRoutine = new WaitForSeconds(0.4f);

		//=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=

		void Start()
		{
			StartCoroutine("pulse");
		}


		public void exeStopPulsing()
		{
			StopCoroutine("pulse");
			imgCtrl.color = Color.white;
			StartCoroutine(UIForge.alphaFadeOut(imgCtrl, 1f));
		}


		IEnumerator pulse()
		{
			while(true)
			{
				yield return delayRoutine;
				yield return UIForge.alphaFadeOut(imgCtrl, 0.75f);
				yield return UIForge.alphaFadeIn(imgCtrl, 0.75f);
			}
		}
	}
}