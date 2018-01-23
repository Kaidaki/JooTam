using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using HalcyonCore;
using Kaibrary.MusicScrolls;



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

		void Start()
		{

		}
	}

	//�ܺ� ���� ��� ����
	public partial class DataManager : MonoBehaviour
	{
		public void relayD_importMusic(messagingDele simpleHandler)
		{
			portCtrl.exeImportMusicPath();
		}
	}
}