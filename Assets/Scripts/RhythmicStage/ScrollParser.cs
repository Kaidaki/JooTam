using UnityEngine;
using System.Collections.Generic;
using System.IO;
using Kaibrary.MusicScrolls;



/// <summary>
/// main def & MetaData Reader part
/// </summary>
public partial class ScrollParser
{
	StreamReader reader;  //읽기스트림 객체(Demo)
		

	int curReadingUnit;  //현재 읽는 시점의 유닛
	List<MusicNoteData> noteDataStorage;  //임시 노트 저장공간
	float barBeatPerUnit;  //해당 마디의 유닛 수
	float currentBpm;  //현재 읽는 시점 BPM
	float noteReadDelay;//bpm에 따른 읽기 지연 시간(ms)
	int noteChannel;  //총 몇 키 인지


	int curReadingState;  //읽기 모드
	enum ReadingState : int //보면 읽기 모드
	{
		Idle,  //idle
		barRead,  //마디 읽기
		bpmRead,  //BPM 읽기
		unitRead  //유닛 읽기(노트)
	}

	//-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-

	//생성자(Demo)
	public ScrollParser(StreamReader readIndicator)
	{
		//초기화 부
		reader = readIndicator;  //리더 스트림 받기

		curReadingState = (byte)ReadingState.Idle;  //유휴 상태
		curReadingUnit = 0;  //현재읽는 유닛 초기화 수치
		barBeatPerUnit = 64;  //기본 4/4

		noteDataStorage = new List<MusicNoteData>();  //저장소 객체화	
	}


	//메타데이터 저장 객체 생성 메소드
	public MusicMetaData readMetaData(StreamReader readIndicator)
	{
		List<string> metaList = new List<string>();  //메타데이터 저장 리스트 객체		

		//구분자 문자 설정 부
		char[] delimiter = { '=' };  //'이퀄' 구분자를 구분

		//메타데이터가 있는 9줄 읽기 부
		for (int i = 0; i < 9; i++)
		{
			//읽기 부(한 줄 씩)			
			string[] values = (readIndicator.ReadLine()).Split(delimiter);  //'=' 문자를 기준으로 분석

			//정보 유무 확인 부
			if (values.Length < 2)  //해당 입력 정보가 없을 경우
			{
				values[1] = null;  //'비어있음'을 입력
			}

			//분석된 (메타)데이터 부분들만 리스트에 추가
			metaList.Add(values[1]);
		}

		//마무리 부
		//읽기스트림 되감기(For Test)
		readIndicator.BaseStream.Seek(0, SeekOrigin.Begin);
		readIndicator.DiscardBufferedData();

		//읽은 메타 데이터 객체 레퍼런스 반환
		return new MusicMetaData(metaList);
	}
}



/// <summary>
/// NoteData Reader part
/// </summary>
public partial class ScrollParser
{

	//-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-

	//Note Data Reader Method [ MAIN ]
	public List<MusicNoteData> readAllnoteData()
	{
		//초기 설정 부
		noteDataStorage.Clear();  //임시 저장공간 청소

		//총 입력 키 갯수 설정
		noteChannel = 3; // [3key]


		//메타데이터 읽기 부
		readCertainMetaData();

		//노트데이터 모두 읽기
		while (!(reader.EndOfStream))
		{
			//마디 읽기 부
			readTranscriptionData(); //마디 첫 줄 읽기

			//개개 마디에 구성된 노트 읽기 부
			for (int i = 0; i < barBeatPerUnit; i++)
				noteDataStorage.Add(readNoteData()); //다음 유닛 읽기(한 줄)
		}

		//마무리 부
		//스트림 닫기
		reader.Close();

		//담은 노트 데이터 송출
		return noteDataStorage;
	}

	//'마디' 부분 읽기 메소드
	void readTranscriptionData()
	{
		//마디 인식 부
		if (reader.Peek() == '-')  //마디 구분자 일부 인 경우
		{
			//마디 인식 완료
			reader.ReadLine();  //마디 줄 넘김			
			curReadingState = (byte)ReadingState.bpmRead;  //해당 마디 변화 BPM 읽기 전환

			if (reader.Peek() >= 'A')  //숫자가 아닌 값이 있을 경우
			{
				//BPM 변속 마디 구간 감지 완료
				//데이터 추출 부
				//구분자 문자 설정 부
				char[] tempDelimiter = { '=' };  //'이퀄' 구분자를 구분
				string[] temp = (reader.ReadLine()).Split(tempDelimiter);  //'=' 문자를 기준으로 분석				

				//BPM 변속 적용 부 : BPM  수치 업데이트
				currentBpm = float.Parse(temp[1]);  //temp[1]이 파싱되어 나온 BPM 값
				updateReadingDelay();  //BPM에 따른 읽기 지연 시간 업데이트
				Debug.Log("BPM : " + currentBpm);
			}
		}
	}

	//'노트배치' 부분 읽는 메소드 (한 줄)
	MusicNoteData readNoteData()
	{
		curReadingState = (int)ReadingState.unitRead;  //노트 읽기 전환
		int[] noteDataBuffer = new int[noteChannel];  //추출된 노트데이터 저장 버퍼
		byte notebufferEmpty = 0;  //노트데이터 저장 버퍼 내부 공백 여부 누적 판단

		//구분자 문자 설정 부
		char[] delimiter = { '#' };  //유닛 구분자

		//읽기 부 (한 Unit 씩 == 한 줄)
		string[] determineBuffer = (reader.ReadLine()).Split(delimiter);  // 유닛 구분자를 걸러냄
																		  // xxxx 식으로 저장
																		  // [0]
																		  //현재 리니어 4키 방식으로는 버퍼 배열 요소가 오직 하나


		//노트 데이터 추출 부 (한 Unit 씩 == 한 줄) : 숏노트 추출 부
		if (determineBuffer[0].CompareTo("000") > 0)  //한 세트가 모두 0000 값이 아니면 (노트 존재시)
		{
			//노트 데이터 추출
			for (int i = 0; i < noteChannel; i++)
			{
				//(숏)노트 데이터 입력
				//(i) 번째 [0 ~ 2]
				noteDataBuffer[i] = int.Parse(determineBuffer[i].ToString());
			}
		}
		else  //한 세트가 모두 000 (노트 없음)
		{
			//(숏)노트 데이터 '공백' 입력
			for (int i = 0; i < noteChannel; i++)
			{
				noteDataBuffer[i] = 0;
			}
			notebufferEmpty++;  //공백 정보 누적
		}

		//노트데이터 한 줄 추출 완료

		//다음 유닛으로 설정 부
		++curReadingUnit;  //현재 시점 유닛수 증가

		//노트데이터 송출(한 줄)
		if (notebufferEmpty == 0)  //노트 데이터 존재
		{
			//Debug.Log("ms : " + (curReadingUnit - 1) * noteReadDelay + " 노트입력 감지!  [ " + (curReadingUnit - 1) + " ]" );
			return new MusicNoteData(noteDataBuffer, (curReadingUnit - 1) * noteReadDelay, curReadingUnit - 1, true);
		}  //하나도 없다면
		else return new MusicNoteData(noteDataBuffer, (curReadingUnit - 1) * noteReadDelay, curReadingUnit - 1, false);
	}

	//메타 데이터 부분 건너뛰기 메소드
	void skipMetaDataPart()
	{
		//메타 데이터 줄 수 만큼 읽고 넘기기
		for (int i = 0; i < 9; i++)
			reader.ReadLine();
	}

	//노트 읽기 지연시간 계산 메소드
	void updateReadingDelay()
	{
		noteReadDelay = 3750f / currentBpm;
	}

	//메타데이터 부분 특정 정보 읽기 메소드(for Test)
	void readCertainMetaData()
	{
		//구분자 문자 설정 부
		char[] delimiter = { '=' };  //'이퀄' 구분자를 구분

		//필요없는 메타데이터 5줄 읽기 부
		for (int i = 0; i < 5; i++)
		{
			reader.ReadLine();  //한 줄씩 건너 뛰기
		}

		//BPM 읽기 부(한 줄 씩)			
		string[] values = (reader.ReadLine()).Split(delimiter);  //'=' 문자를 기준으로 분석
																 //BPM 정보 추출
		this.currentBpm = float.Parse(values[1]);
		Debug.Log("BPM ex : " + currentBpm);
		updateReadingDelay();  //BPM에 따른 읽기 지연시간 초기 계산

		//필요없는 메타데이터 마지막 3 줄 스킵 부
		reader.ReadLine(); reader.ReadLine(); reader.ReadLine();
	}
}



/// <summary>
/// NoteData refinery part
/// </summary>
public partial class ScrollParser
{
	//노트 데이터 재가공 메서드
	public Queue<NoteJudgeCard>[] exeExtractJudgeScroll(List<MusicNoteData> noteDataStorage)
	{
		Debug.Log("start Refine NoteData...List size : " + noteDataStorage.Count);
		//재가공 노트 데이터 저장 큐
		Queue<NoteJudgeCard>[] judgeScroll = new Queue<NoteJudgeCard>[13];
		//큐 배열 생성 부
		for (int i = 0; i < noteChannel; i++)  //[ x key ] x개의 큐
		{
			judgeScroll[i] = new Queue<NoteJudgeCard>();
		}


		//노트 데이터 순차 접근
		foreach (MusicNoteData indic in noteDataStorage)
		{
			//노트데이터 있는 unit 찾을 시
			if (indic.noteExistCheck() == true)
			{
				//해당 유닛의 노트데이터 배열에 순차 접근
				for (int i = 0; i < 13; i++)
				{
					int note = indic.noteData[i];
					if (note >= 1)  //노트 데이터만 검출
					{
						judgeScroll[i].Enqueue(new NoteJudgeCard(note, indic.time, indic.unitTiming));
						//Debug.Log(indic.getLineTiming( ));
						//judgeScroll[i].Peek().printContent(); //입력된 정보 출력
					}
				}
			}
		}

		//마무리
		Debug.Log("refining Completed");
		return judgeScroll;
	}


	//재가공 판정큐 깊은 복사 메소드
	public Queue<NoteJudgeCard>[] copyRefinedQueue(Queue<NoteJudgeCard>[] original)
	{
		Queue<NoteJudgeCard>[] target = original;  //복사할 원본
		int queueVolume = target.Length;  //큐 크기
		Debug.Log("COPYING queueVolume : " + queueVolume);

		//사본 큐 배열 생성 부
		Queue<NoteJudgeCard>[] copyScroll = new Queue<NoteJudgeCard>[queueVolume];
		for (int i = 0; i < queueVolume; i++)
		{
			copyScroll[i] = new Queue<NoteJudgeCard>();
		}

		for (int i = 0; i < queueVolume; i++)
		{
			NoteJudgeCard[] sigleLine = target[i].ToArray();

			for (int j = 0; j < sigleLine.Length; j++)
			{
				copyScroll[i].Enqueue(sigleLine[j].turnToObject());
			}
		}

		//마무리
		Debug.Log("Copying Completed");
		return copyScroll;
	}
}
