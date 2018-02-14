using UnityEngine;
using System.Collections;
using HalcyonCore;



namespace PrimalScene
{
	public class PrimalPageCore : CoreBase
	{
		//refs
		[SerializeField] InputManager inputCtrl;
		[SerializeField] SoundManager soundCtrl;

		event LightweightHandler Click; // Event Def

		enum coreState
		{
			standBy,
			Idle,
			Entering
		}

		//=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=

		void Start()
		{
			Invoke("exeLinkInput", 2f);
		}

		//인풋 모듈의 이벤트 구독
		void exeLinkInput()
		{
			print("subscribed Input Manager");
			inputCtrl.subscribeEvent(issueNextScene);
		}

		//다음 씬 준비 명령
		void issueNextScene()
		{
			if (Click != null)  //(리스너 혹은 구독자) 존재 시
				Click();

			soundCtrl.exeStopMusic();
		}

		//구독 실행
		public void subscribeEvent(LightweightHandler listener)
		{
			Click += listener;
		}

		//FSM 
		IEnumerator FSM()
		{
			yield break;
		}
	}
}