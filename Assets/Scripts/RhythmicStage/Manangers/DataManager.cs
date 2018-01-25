using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using HalcyonCore;
using System.IO;



namespace RhythmicStage
{
	//���� ���� ��� ����
	public partial class DataManager : MonoBehaviour
	{
		//refs
		//����
		[SerializeField] RhythmicCore coreCtrl;  //RhythmicCore
		//����
		[SerializeField] DataPort portCtrl;
		[SerializeField] ScrollParser parserCtrl;
		//localStorage
		[SerializeField] LocalStorage storageCtrl;


		//sigleTon parts
		public static DataManager instance;

		//-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-

		// Use this for primal initialization
		void Awake()
		{
			//sigleTon parts
			instance = this;
		}

		// Use this for initialization after all Object are made
		void Start()
		{

		}
	}

	//���� ��� �޼��� ����
	public partial class DataManager : MonoBehaviour
	{
		//Execution parts : exe-
		//-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-

		//���� �ε� ���
		public void exeLoadMusicScroll(messagingDele simpleHandler)
		{
			//��Ʈ�� ���� ��
			parserCtrl = new ScrollParser(new StreamReader(storageCtrl.musicPath));

			//���� ��Ÿ������ �ε� ��
			storageCtrl.metaDataStorage = parserCtrl.readMetaData();

			//���� ��Ʈ������ �ε� ��
			storageCtrl.noteDataStorage = parserCtrl.readAllnoteData();

			//��Ʈ������ ���� ��
			storageCtrl.judgeScroll = parserCtrl.ExtractJudgeScroll();

			//���� ������ ���� ���� ��
			storageCtrl.noteScroll = parserCtrl.copyRefinedQueue(storageCtrl.judgeScroll);

			//������ ��
			//Call Back
			simpleHandler("file loading Completed");
		}

		//relay parts : relayU_- or relayD_-
		//-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-
		
		public void relayD_importMusic(messagingDele simpleHandler)
		{			
			portCtrl.exeImportMusicPath(simpleHandler);
		}
	}
}