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
		//[SerializeField] InputManager inputCtrl;
		[SerializeField] DataManager dataCtrl;
		[SerializeField] SoundManager soundCtrl;
		[SerializeField] GameObjectManager objectsCtrl;
		[SerializeField] UIManager uiCtrl;

		//sigleTon parts
		public static RhythmicCore instance;

		//���� ��
		public inRhythmicStageStates State { get; set; }  //�� ����	

		//-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-

		// Use this for primal initialization
		void Awake()
		{
			//sigleTon parts
			instance = this;

			//���� ���� ��
			State = inRhythmicStageStates.firstEntry;  //���� ���� : �������� �ε�
		}

		// Use this for initialization after all Object are made
		void Start()  //GO!!
		{
			//!!Stage START POINT!!
			forcePreprocess();  //�������� �ε�
		}
		private void OnEnable()
		{
			
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
			simpleHandler = (string st) => { print("RhythmicCore : " + st); forceApplyData(); };

			//���� ���� ��
			State = inRhythmicStageStates.firstEntry;
			//�ϴ� : �� ���� ����
			dataCtrl.relayD_importMusic(simpleHandler);
		}

		//���� ���� ���� �� ���� ( State : apply file Data )
		public void forceApplyData()
		{
			messagingDele simpleHandler = null;
			simpleHandler = (string st) => { print("RhythmicCore : " + st); forceLinkTrigger(); };

			//���� ���� ��
			State = inRhythmicStageStates.enteringStage;
			//�ϴ� : �������� �غ� ���
			dataCtrl.exeLoadMusicScroll(simpleHandler);
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
					forceStageOn(trigger);  //�ε� �Ϸ�
			};

			//�ϴ� : ���� �غ�			
			soundCtrl.exeLinkTrigger(handler);
			//objectsCtrl.exeLinkTrigger(handler);
		}

		//���� ���� ( Stage : onStage )
		public void forceStageOn(LightweightDele trigger)
		{
			//   !!SHOWTIME!!
			trigger();

			//���� ���� ��
			State = inRhythmicStageStates.stageOn;
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