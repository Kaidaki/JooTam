using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using HalcyonCore;


namespace RhythmicStage
{
	public partial class RhythmicCore : MonoBehaviour
	{
		//refs
		//�������� Managers
		[SerializeField] InputManager inputCtrl;
		[SerializeField] DataManager dataCtrl;
		[SerializeField] SoundManager soundCtrl;
		[SerializeField] GameObjectManager objectsCtrl;
		[SerializeField] UIManager uiCtrl;

		//sigleTon parts
		public static RhythmicCore instance;

		//���� ��
		public inStageStates gameState { get; set; }  //�� ����	

		//-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-

		// Use this for primal initialization
		void Awake()
		{
			//sigleTon parts
			instance = this;

			//���� ���� ��
			gameState = inStageStates.enteringStage;  //���� ���� : �������� �ε�
		}

		// Use this for initialization after all Object are made
		void Start()  //GO!!
		{
			//!!Stage START POINT!!
			forcePreprocess();  //�������� �ε�
		}
	}



	public partial class RhythmicCore : MonoBehaviour
	{
		//forcing parts : force-
		//-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=

		//�������� �غ����� ������ ��-ó�� ( State : read files )
		void forcePreprocess()
		{
			messagingDele simpleHandler = null;
			simpleHandler = (string st) => { print(st); forceApplyData(); };

			//�� ���� �ϳ� �б� ���			
			dataCtrl.relayD_LoadOneFile(simpleHandler);
		}

		//���� ���� ���� �� ���� ( State : apply file Data )
		public void forceApplyData()
		{
			messagingDele simpleHandler = null;
			simpleHandler = (string st) => { print(st); forceLinkTrigger(); };

			//�������� �غ� ���
			dataCtrl.exePrepareStage(simpleHandler);
		}

		//�������� ���� Ʈ���� ���� & �ε� ( State : load & link stage trigger )
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

			//���� ȸ�� ȣ��� �������� �Ѿ
			if (callingCount == 3)
					forceStageOn(trigger);
			};


			dataCtrl.relayD_loadStage(handler);
			resourceCtrl.relayD_loadStage(handler);
		}

		//���� ���� ( Stage : onStage )
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