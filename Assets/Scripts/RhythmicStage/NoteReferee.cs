using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;
using HalcyonCore;
using System.Diagnostics;



namespace RhythmicStage
{
	public partial class NoteReferee : MonoBehaviour
	{

		//refs
		//immediate Manager(상위)
		[SerializeField] RhythmicCore coreCtrl;
		//LocalStorage
		[SerializeField] LocalStorage dataCtrl;

		//sigleTon parts
		public static NoteReferee instance;

		//Fields
		public Queue<NoteJudgeCard>[] judgeScroll { get; set; }  //각 라인에 노트 판정을 위한 노트배치표 큐
		[SerializeField] const float perfectJudgeflexibility = 200f;  //판정 상수(ms)
		[SerializeField] const float niceJudgeflexibility = 450f;  //판정 상수(ms)
		[SerializeField] float judgeFactor;  //판정 배수(널널함, 엄격함 결정)

		//스톱 워치
		public static Stopwatch stopwatch = new Stopwatch();

		//-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-

		// Use this for initialization
		void Awake()
		{
			//sigleTon parts
			instance = this;


			judgeFactor = 1.0f;
		}

		// Update is called once per frame
		void Update()
		{		
			for(int row = 0; row < dataCtrl.curChannel; row++)
			{
				try
				{
					//나이스 판정 시간대보다 뒤에 있는경우
					if (judgeScroll[row].Peek().time < stopwatch.ElapsedMilliseconds - niceJudgeflexibility)
					{
						// Miss 처리
						judgeScroll[row].Dequeue();  //큐에서 제외
						treatMissingNote(row);  //해당 노트 관련 처리 푸시
						print("Miss...");
					}
				}
				catch (InvalidOperationException)
				{
					
				}
			}			
		}

		//숏노트 판정 실행
		void judgeShortNote(int InputChannel)
		{
			//먼저 퍼펙트 여부 확인
			if (judgeScroll[InputChannel].Peek().time < stopwatch.ElapsedMilliseconds + perfectJudgeflexibility && judgeScroll[InputChannel].Peek().time > stopwatch.ElapsedMilliseconds - perfectJudgeflexibility)
			{
				//퍼팩트 처리 (판정 1)
				judgeScroll[InputChannel].Dequeue();
				print("PERFECT!!");
			}
			//그 다음 나이스 처리			
			else if (judgeScroll[InputChannel].Peek().time <= stopwatch.ElapsedMilliseconds + niceJudgeflexibility && judgeScroll[InputChannel].Peek().time >= stopwatch.ElapsedMilliseconds - niceJudgeflexibility)
			{
				//나이스 처리 (판정 2)
				judgeScroll[InputChannel].Dequeue();
				print("Nice");
			}
		}

		//롱노트 판정 실행
		void judgeLongNote()
		{
			//▨ 구현 예정
		}		

		//무대 쇼타임 시작
		void exeShowTime()
		{
			//시간 측정
			stopwatch.Start();
			print("time checking start");
		}

		//무대 막 내리기
		void exeEndStage()
		{
			//시간 멈춤
			stopwatch.Stop();
		}

		//미싱 노트 처리 관련
		void treatMissingNote(int channel)
		{
			coreCtrl.confMissingNote(channel);
		}
	}

	//상하 명령 메서드 집합
	public partial class NoteReferee : MonoBehaviour
	{
		//Execution parts : exe-
		//-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-

		//트리거 연결
		public void exeLinkTriggerNLoad(reflecMessagingDele Handler)
		{
			//데이터 수입 부
			judgeScroll = dataCtrl.judgeScroll;

			//로드 완료
			Handler("Referee : get a linker!", exeShowTime);
		}

		//노트 입력 시작 감지
		public void exeReferActivation(int Channel)
		{
			judgeShortNote(Channel);
		}

		//노트 지속 입력 릴리즈 감지
		public void exeReferDeActivation(int Channel)
		{

		}

		//relay parts : relayU_- or relayD_-
		//-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-
	}
}