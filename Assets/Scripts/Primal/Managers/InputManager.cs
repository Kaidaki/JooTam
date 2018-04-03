using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using HalcyonCore;



namespace PrimalScene
{
	public class InputManager : MonoBehaviour
	{
		Button butctrl;
		event LightweightHandler touchDetected;

		//=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=

		void Update()
		{
			//when accept a touch input
			if(Input.touchCount != 0 || Input.GetMouseButtonDown(0) || Input.GetMouseButtonDown(1))
			{
				print("touch conf-!");
				if (touchDetected != null)  //(리스너 혹은 구독자) 존재 시
					touchDetected();
			}
		}

		public void addListener(LightweightHandler call)
		{
			touchDetected += call;
		}

		public void removeListener(LightweightHandler call)
		{
			touchDetected -= call;
		}

		public void removeAllListener()
		{
			touchDetected = null;
		}
	}
}