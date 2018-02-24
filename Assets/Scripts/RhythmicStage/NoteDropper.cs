using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using Kaibrary;
using HalcyonCore;
using System.Diagnostics;



namespace RhythmicStage
{
	//내부 실행 요소 정의
	public partial class NoteDropper : MonoBehaviour
	{
		//refs
		//상위
		[SerializeField] GameObjectManager objectCtrl;
		//LocalStorage
		[SerializeField] LocalStorage dataCtrl;

		//Prefab Storage
		[SerializeField] GameObject shortNoteObject;  //숏 노트 오브젝트	

		//Pure fields
		[SerializeField] Transform judgeLine;  //판정선 위치
		[SerializeField] Transform[] dropPoint;  //노트 생성 위치
		[SerializeField] float dropDistance;  //판정선과 노트 생성 위치 거리

		//Object Pool
		Queue<GameObject>[] poolQueue;  //비활성 오브젝트 대기큐
		Queue<GameObject>[] activePoolQueue;  //활성 오브젝트 관리큐
		int poolSize;  //오브젝트 풀 최대 수용량

		//etc
		Queue<NoteJudgeCard>[] noteScroll;  //복사본(임시)
		Stopwatch stopwatch = NoteReferee.stopwatch;  //판정자 클래스의 스톱워치 받기
		float preLoadingTime;
		int Channel;  // x key
		float noteSpeed = 0;  //

		//-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-

		// Use this for primal initialization
		void Awake()
		{
			//초기, 임의값 초기화 부
			poolSize = 50;  //생성량 초기설정값		
			preLoadingTime = 500f;  //프리로딩
			Channel = dataCtrl.curChannel;


			//비활성 오브젝트 대기큐 배열 생성 부
			poolQueue = new Queue<GameObject>[Channel];
			for (int i = 0; i < Channel; i++)  //채널 수 만큼 대기열 생성
			{
				poolQueue[i] = new Queue<GameObject>(poolSize);  //설정 크기 만큼 
			}

			//활성 오브젝트 관리큐 배열 생성 부
			activePoolQueue = new Queue<GameObject>[Channel];
			for (int i = 0; i < Channel; i++)  //채널 수 만큼 대기열 생성
			{
				activePoolQueue[i] = new Queue<GameObject>(poolSize);  //설정 크기 만큼 
			}
		}

		// Use this for initialization after all Object are made
		void Start()
		{
			//판정선과 거리 계산(= 노트의 총 이동거리)
			dropDistance = VectorTreatTools.distance(this.transform, judgeLine);
			//노트속도 계산 부
			speedCal();			
		}

		// Update is called once per frame
		void Update()
		{
			#region ShortNote PreLoading Part	
			
			for (int row = 0; row < Channel; row++)
			{
				Queue<NoteJudgeCard> noteLine = noteScroll[row];

				try
				{
					//프리로드 시점에 걸친 노트 발견
					if (noteLine.Peek().time <= stopwatch.ElapsedMilliseconds + preLoadingTime)
					{
						//Short Note Pop
						dealShortNote(noteLine.Dequeue(), row);  //큐에서 제외
						print("Pop ShortNote! __ PreLoading ( " + (stopwatch.ElapsedMilliseconds + preLoadingTime) );
					}
				}
				catch (InvalidOperationException)
				{
					
				}
			}
			#endregion

			#region LongNote PreLoading part


			#endregion
		}

		//오브젝트 풀 요소 생성 
		void createNoteObject()
		{
			for (int row = 0; row < Channel; row++)
			{  //채널 수에 따른
				for (int i = 0; i < poolSize; i++)
				{  //풀 사이즈 만큼
					GameObject creation = Instantiate(shortNoteObject, dropPoint[row]);  //오브젝트 생성
					
					creation.SetActive(false);  //비활성화
					poolQueue[row].Enqueue(creation);  //오브젝트를 대기큐 입력
				}
			}
		}

		//스테이지 최초 로드 직후 노트 배치
		void dealInitialNote()
		{

		}

		//알맞는 시점(다음)에 노트 배치
		void dealShortNote(NoteJudgeCard shortNoteData, int channel)
		{
			GameObject shortNote = poolQueue[channel].Dequeue();  //비활성 풀에서 갓 꺼낸 노트			
			shortNote.GetComponent<ShortNoteBehaviour>().setSpeed(noteSpeed);
			shortNote.SetActive(true);  //활성화 (노트 발사)
			activePoolQueue[channel].Enqueue(shortNote);
		}

		//풀링 오브젝트 회수 (백 투더 풀)
		public void collectObject(GameObject endedNote, int channel)
		{
			poolQueue[channel].Enqueue(endedNote);  //알맞는 큐에 다시 입력(오브젝트 회수)
		}

		//노트 오브젝트 회수
		public void returnShortNote(int channel)
		{
			GameObject ShortNote = activePoolQueue[channel].Dequeue();  //활성 풀에서 꺼낸 후
			ShortNote.SetActive(false);  //비활성화,
			ShortNote.transform.position = dropPoint[channel].position;  //위치 초기화 후			
			poolQueue[channel].Enqueue(ShortNote);  //비활성 풀에 넣기
		}

		//BPM에 따른 속도 계산
		public void speedCal()
		{	
			noteSpeed = dropDistance / (preLoadingTime / 1000f);
		}

		//업데이트 활성화
		public void ShowTime()
		{
			this.enabled = true;
			print("start Checking Note Queue");
		}
	}

	//상하 명령 메서드 집합
	public partial class NoteDropper : MonoBehaviour
	{
		//Execution parts : exe-
		//-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-

		//트리거 연결
		public void exeLinkTriggerNLoad(reflecMessagingHandler Handler)
		{
			//오브젝트 생성 부
			createNoteObject();

			//데이터 수입 부
			noteScroll = dataCtrl.noteScroll;			

			//로드 완료
			Handler("NoteDropper : get a linker!", ShowTime);
		}

		//숏노트 처리
		public void exeShortNoteJudge(int channel)
		{
			returnShortNote(channel);
		}

		//미스 노트 처리
		public void exeTreatMissingNote(int channel)
		{
			returnShortNote(channel);
		}
	}
}