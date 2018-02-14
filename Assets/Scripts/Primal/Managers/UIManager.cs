using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using HalcyonCore;



namespace PrimalScene
{
	public class UIManager : MonoBehaviour
	{
		//refs
		[SerializeField] PrimalPageCore coreCtrl;
		[SerializeField] WelComeTextBehaviour txtCtrl;		

		//=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=

		// Use this for initialization
		void Awake()
		{
			coreCtrl.subscribeEvent(confNextScene);
		}

		void confNextScene()
		{
			txtCtrl.exeStopPulsing();
		}
	}
}