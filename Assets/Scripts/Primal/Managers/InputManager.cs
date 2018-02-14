using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using HalcyonCore;



namespace PrimalScene
{
	public class InputManager : MonoBehaviour
	{
		event LightweightHandler touchEvent;

		//=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=

		private void Update()
		{
			//when accept a touch input
			if(Input.touchCount >= 1 || Input.GetMouseButtonUp(0))
			{
				print("touch triggered");
				if (touchEvent != null)  //(리스너 혹은 구독자) 존재 시
					touchEvent();
			}

			
		}

		public void subscribeEvent(LightweightHandler call)
		{
			touchEvent += call;
		}
	}
}