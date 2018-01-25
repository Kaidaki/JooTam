using UnityEngine;
using System.Collections.Generic;
using System.IO;
using HalcyonCore;




public class NoteDataReader
{
	StreamReader reader;  //읽기스트림 객체	
	int curReadingState;  //읽기 모드

	int curReadingUnit;  //현재 읽는 시점의 유닛
	List<MusicNoteData> noteDataStorage;  //임시 노트 저장공간
	float barBeatPerUnit;  //해당 마디의 유닛 수
	float currentBpm;  //현재 읽는 시점 BPM
	float noteReadDelay;//bpm에 따른 읽기 지연 시간(ms)
	int noteChannel;  //총 몇 키 인지

	enum ReadingState : int //보면 읽기 모드
	{
		Idle,  //idle
		barRead,  //마디 읽기
		bpmRead,  //BPM 읽기
		unitRead  //유닛 읽기(노트)
	}

	//-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-

	//생성자
	public NoteDataReader(StreamReader readIndicator)
	{
		//초기화 부
		curReadingState = (byte)ReadingState.Idle;  //유휴 상태
		curReadingUnit = 0;  //현재읽는 유닛 초기화 수치
		barBeatPerUnit = 64;  //기본 4/4

		reader = readIndicator;  //리더 스트림 받기

		noteDataStorage = new List<MusicNoteData>();  //저장소 객체화	
	}


	//Note Data Reader Method [ MAIN ]
	public List<MusicNoteData> readAllnoteData()
	{
		//초기 설정 부
		noteDataStorage.Clear();  //임시 저장공간 청소

		//총 입력 키 갯수 설정
		noteChannel = 4; // [4key]


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
		int [] noteDataBuffer = new int[noteChannel];  //추출된 노트데이터 저장 버퍼
		byte notebufferEmpty = 0;  //노트데이터 저장 버퍼 내부 공백 여부 누적 판단

		//구분자 문자 설정 부
		char [] delimiter = { '#' };  //유닛 구분자

		//읽기 부 (한 Unit 씩 == 한 줄)
		string [] determineBuffer = (reader.ReadLine()).Split(delimiter);  // 유닛 구분자를 걸러냄
																		  // xxxx 식으로 저장
																		  // [0]
		//현재 리니어 4키 방식으로는 버퍼 배열 요소가 오직 하나


		//노트 데이터 추출 부 (한 Unit 씩 == 한 줄) : 숏노트 추출 부
		if (determineBuffer[0].CompareTo("0000") > 0)  //한 세트가 모두 0000 값이 아니면 (노트 존재시)
		{
			//노트 데이터 추출
			for (int i = 0; i < noteChannel; i++)
			{
				//(숏)노트 데이터 입력
				//(i) 번째 [0 ~ 3]
				noteDataBuffer[i] = int.Parse(determineBuffer[i].ToString());
			}
		}
		else  //한 세트가 모두 0000 (노트 없음)
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
		for (int i = 0; i < 7; i++)
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