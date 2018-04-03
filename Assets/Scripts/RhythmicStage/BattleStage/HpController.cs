using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;



namespace RhythmicStage
{
	public class HpController : MonoBehaviour
	{
		public Slider slider;

		void Start()
		{
			slider = CoreManager.coreManagerIns.slider;

			slider.maxValue = 100f;
			slider.value = 100f;
		}

		public void Damaged()  //체력이 줄어드는 함수
		{
			if (CoreManager.coreManagerIns.shield.shieldOn == false)
			{
				slider.value -= 5;
				CoreManager.coreManagerIns.judgeNote = true;
			}
			else
			{
				CoreManager.coreManagerIns.shield.shieldOn = false;
				CoreManager.coreManagerIns.judgeNote = true;
			}
		}
	}
}