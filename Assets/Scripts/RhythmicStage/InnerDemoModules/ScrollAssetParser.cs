using UnityEngine;
using System.Collections.Generic;
using System.IO;
using HalcyonCore;



namespace RhythmicStage
{
	/// <summary>
	/// main def & MetaData Reader part
	/// </summary>
	public partial class ScrollAssetParser : MonoBehaviour
	{
		StringReader reader;  //읽기스트림 객체(Demo)
		[SerializeField] TextAsset asset;


		int curReadingUnit = 0;  //현재 읽는 시점의 유닛
		List<MusicNoteData> noteDataStorage;  //임시 노트 저장리스트
		Queue<RefinedNoteData>[] noteQueue;  //임시 노트 저장큐
		Stack<char> parserStack;  //판정자
		Dictionary<char, LightweightHandler> orderSet;
		string sigleLine = null;
		List<string> unitSaver;
		
		float currentBpm = 136.0f;  //현재 읽는 시점 BPM
		float noteReadDelay;  //bpm에 따른 읽기 지연 시간(ms)		
		int Channel;  //총 몇 키 인지
		int metaLineCount;  //메타데이터 저장 줄 수
		int BarCount = 0;  //현재 마디 수


		int curReadingState;  //읽기 모드
		enum ReadingState : int //보면 읽기 모드
		{
			Idle,  //idle
			barRead,  //마디 읽기
			bpmRead,  //BPM 읽기
			unitRead  //유닛 읽기(노트)
		}

		//-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-


		//생성자(Demo)
		void Start()
		{
			//총 입력 키 갯수 설정 ▨
			Channel = 3; // [3 key]	


			 //초기화 부
			reader = new StringReader(asset.text);  //스트링 리더 연계
			curReadingState = (byte)ReadingState.Idle;  //유휴 상태
			noteDataStorage = new List<MusicNoteData>();  //저장소 객체화
			noteQueue = new Queue<RefinedNoteData>[3];
			for (int i = 0; i < Channel; i++)  //채널 수 만큼 대기열 생성
			{
				noteQueue[i] = new Queue<RefinedNoteData>();  //설정 크기 만큼 
			}
			orderSet = new Dictionary<char, LightweightHandler>();
			unitSaver = new List<string>(192);
			parserStack = new Stack<char>();
			metaLineCount = 19;

			orderSet.Add('b', nothing);  //미구현
			orderSet.Add('0', stackUnit);  //파싱
			orderSet.Add('1', stackUnit);  //파싱
			orderSet.Add('-', readStartBar);  //미구현
			orderSet.Add('2', null);  //미구현				
		}
		
		public void exeExtractNote()
		{			
			//메타데이터 건너 뛰기 [ Optional ]
			skipMetaDataBlock();

			//노트데이터 읽기 부
			while(true)
			{
				//일단 먼저 한 줄 읽기
				sigleLine = reader.ReadLine();
				if (sigleLine == null)  //끝에 도달 시 
					break;  //탈출

				//첫번째 단일 문자 읽기
				print(sigleLine[0]);
				if(orderSet[sigleLine[0]] != null)
					orderSet[sigleLine[0]]();  //적절한 행동 취하기
			}

		}


		/// <summary>
		///	Simple skip meta data block as StringReader
		/// </summary>
		private void skipMetaDataBlock()
		{
			for (int i = 0; i < metaLineCount; i++)
				reader.ReadLine();
		}

		private bool ishasNoteData()
		{
			char[] tempDelimiter = { '|' };  //'|' 구분자를 구분
			string[] temp = sigleLine.Split(tempDelimiter);  //'=' 문자를 기준으로 분석

			//검열 부
			//앞 줄 확인
			if (temp[0].CompareTo("0000") > 0)  //노트 존재시
				return true;
			//다음 줄 확인
			if (temp[1].CompareTo("00") > 0)  //노트 존재시
				return true;
			//다음 마지막 확인
			if (temp[1].CompareTo("0-") == 0)  //터닝 포인트 존재시
				return true;

			//마무리
			return false;
		}

		private void readStartBar()
		{
			//일단 구분자 푸시
			parserStack.Push(sigleLine[0]);

			if(parserStack.Count == 2)
			{//마디 하나 다 읽은 상태

				BarCount++;  //마디 ++
				//그 동안 저장된 유닛들 분석 명령
				refineUnits();


				//마무리 부
				refinaryInit();
			}
			else
			{ }
		}

		private void refineUnits()
		{
			char[] tempDelimiter = { '|' };  //'|' 구분자를 구분
			int nullCheckerCount = 0;


			//init
			int barBit = unitSaver.Count;  //현재 가공중인 마디의 최대 저장 비트 수			
			float startMs = 240000 / currentBpm * (BarCount - 1);
			float endMs = 240000 / currentBpm * (BarCount);
			float bitGapMs = 240000 / currentBpm / barBit;


			for (int bit = 0; bit < unitSaver.Count; bit++)
			{
				string[] temp = unitSaver[bit].Split(tempDelimiter);  //'=' 문자를 기준으로 분석


				//가공 부
				//앞 칸 확인
				if (temp[0].CompareTo("0000") == 0)
				{	//노트 미 존재시
					nullCheckerCount++;
					print(temp[0]);
				}
				else  //존재!
				{					
					for (int channel = 0; channel < 3; channel++)
					{
						char quaq = temp[0][channel];
						if (quaq == '1')  //진짜 노트 존재 시 (일단 숏노트)
						{
							noteQueue[channel].Enqueue(new RefinedNoteData(quaq, startMs + bitGapMs * bit));
							noteQueue[channel].Dequeue().printContent(channel);
						}
					}
				}

				/*
				//다음 칸 확인
				if (temp[1].CompareTo("00") == 0)  //노트 미 존재시
					nullCheckerCount++;
				else  //존재!
				{
					//▨▨
					//▨▨ 확장키 저장 미구현
					//▨▨
				}

				//다음 마지막 확인
				if (temp[2].CompareTo("--") == 0)  //터닝 포인트 미 존재시
					nullCheckerCount++;
				else //존재!
				{
					//▨▨
					//▨▨ 터닝 포인트 저장 미구현
					//▨▨
				}*/

				//해당 유닛이 공백 여부 확인
				if (nullCheckerCount == 1)  //공백 데이터 이면
				{

				}
			}
		}

		private void stackUnit()
		{
			unitSaver.Add(sigleLine);  //Raw 스트링을 리스트에 추가			
		}

		/// <summary>
		/// ready for next the Cycle
		/// </summary>
		private void refinaryInit()
		{
			unitSaver.Clear();			
			parserStack.Pop();
		}

		private void nothing()
		{

		}


		public void exeImportMusicPath(messagingHandler simpleHandler)
		{
			exeExtractNote();

			//로딩 계속
			simpleHandler("Importing a Music Path Completed");
		}
	}
}