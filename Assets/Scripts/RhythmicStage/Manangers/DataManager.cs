using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using HalcyonCore;
using Kaibrary.MusicScrolls;



namespace RhythmicStage
{
	//내부 실행 요소 정의
	public partial class DataManager : MonoBehaviour
	{
		//refs		
		//상위
		[SerializeField] RhythmicCore coreCtrl;  //RhythmicCore
		//하위
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

	//외부 소통 요소 정의
	public partial class DataManager : MonoBehaviour
	{
		public void relayD_importMusic(messagingDele simpleHandler)
		{
			portCtrl.exeImportMusicPath();
		}
	}
}