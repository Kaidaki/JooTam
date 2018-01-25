using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using HalcyonCore;



namespace RhythmicStage
{
	//내부 실행 요소 정의
	public partial class GameObjectManager : MonoBehaviour
	{
		//refs
		//상위
		[SerializeField] RhythmicCore coreCtrl;
		//하위
		[SerializeField] NoteDropper dropperCtrl;
		[SerializeField] NoteRailPlatform platformCtrl;
		//localStorage
		[SerializeField] LocalStorage storageCtrl;

		//-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-

	}

	//상하 명령 메서드 집합
	public partial class GameObjectManager : MonoBehaviour
	{
		//Execution parts : exe-
		//-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-

		//relay parts : relayU_- or relayD_-
		//-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-
	}
}