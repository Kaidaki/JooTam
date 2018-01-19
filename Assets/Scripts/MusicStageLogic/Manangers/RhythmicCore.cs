using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using HalcyonCore;


namespace RhythmicStage
{
	public partial class RhythmicCore : MonoBehaviour
	{
		//refs
		//직속하위 Managers
		[SerializeField] InputManager inputCtrl;
		[SerializeField] DataManager dataCtrl;
		[SerializeField] SoundManager soundCtrl;
		[SerializeField] GameObjectManager objectsCtrl;
		[SerializeField] UIManager uiCtrl;

		//sigleTon parts
		public static RhythmicCore instance;

		//상태 계
		public inStageStates gameState { get; set; }  //현 상태	

		//-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-

		// Use this for primal initialization
		void Awake()
		{
			//sigleTon parts
			instance = this;

			//상태 설정 부
			gameState = inStageStates.enteringStage;  //최초 상태 : 스테이지 로딩
		}

		// Use this for initialization after all Object are made
		void Start()  //GO!!
		{
			//!!Stage START POINT!!
			forcePreprocess();  //스테이지 로딩
		}
	}



	public partial class RhythmicCore : MonoBehaviour
	{
		//forcing parts : force-
		//-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=

		//스테이지 준비직전 데이터 선-처리 ( State : read files )
		void forcePreprocess()
		{
			messagingDele simpleHandler = null;
			simpleHandler = (string st) => { print(st); forceApplyData(); };

			//곡 정보 하나 읽기 명령			
			dataCtrl.relayD_LoadOneFile(simpleHandler);
		}

		//선곡 정보 받은 후 동작 ( State : apply file Data )
		public void forceApplyData()
		{
			messagingDele simpleHandler = null;
			simpleHandler = (string st) => { print(st); forceLinkTrigger(); };

			//스테이지 준비 명령
			dataCtrl.exePrepareStage(simpleHandler);
		}

		//스테이지 시작 트리거 연결 & 로딩 ( State : load & link stage trigger )
		public void forceLinkTrigger()
		{
			reflecMessagingDele handler = null;
			LightweightDele trigger = null;
			int callingCount = 0;
			handler = (string st, LightweightDele recall) =>
			{
				callingCount++;
				print(st + "||" + callingCount);
				trigger += recall;

			//일정 회수 호출시 다음으로 넘어감
			if (callingCount == 3)
					forceStageOn(trigger);
			};


			dataCtrl.relayD_loadStage(handler);
			resourceCtrl.relayD_loadStage(handler);
		}

		//무대 시작 ( Stage : onStage )
		public void forceStageOn(LightweightDele trigger)
		{
			//   !!SHOWTIME!!
			trigger();
		}


		//(receiving) report parts : conf-
		//-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=

		public void confShortInput(int keyIndex)
		{

		}

		public void confLongDeactivate(int keyIndex)
		{

		}
	}
}