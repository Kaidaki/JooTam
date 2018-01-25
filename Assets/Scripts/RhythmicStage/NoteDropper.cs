using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Kaibrary;
using HalcyonCore;
using System.Diagnostics;
using UnityEngine;



namespace RhythmicStage
{
	public partial class NoteDropper : MonoBehaviour
	{
		//refs
		//상위
		[SerializeField] GameObjectManager objectCtrl;
		//LocalStorage
		[SerializeField] LocalStorage dataCtrl;

		//Pure fields
		[SerializeField] Transform judgeLine;
		[SerializeField] Transform[] dropPoint;
		[SerializeField] float dropDistance;

		[SerializeField] GameObject noteObject;  //숏 노트 오브젝트	
		int poolSize;  //오브젝트 풀 최대 수용량

		//오브젝트 풀 레퍼런스
		Queue<GameObject>[] poolQueue;  //비활성 오브젝트 대기큐
		Queue<GameObject>[] activePoolQueue;  //활성 오브젝트 관리큐

		//기타
		Queue<NoteJudgeCard>[] judgeScroll;  //복사본(임시)
		Stopwatch stopwatch = NoteReferee.stopwatch;  //노트 딜러 클래스의 스톱워치 받기
		float preLoadingTime;

		//-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-

		// Use this for initialization
		void Start()
		{
			//판정선과 거리 계산(= 노트의 총 이동거리)
			dropDistance = VectorTreatTools.distance(this.transform, judgeLine);
		}

		// Update is called once per frame
		void Update()
		{

		}
	}

	public partial class NoteDropper : MonoBehaviour
	{

	}
}