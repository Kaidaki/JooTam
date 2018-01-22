using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using HalcyonCore;
using Kaibrary.MusicScrolls;



namespace RhythmicStage
{
	public class LocalStorage : ScriptableObject
	{
		[SerializeField] string musicPath;

		Queue<NoteJudgeCard>[] judgeScroll;
		Queue<NoteJudgeCard>[] noteScroll;

		public List<MusicMetaData> metaDataStorage { get; set; }  //읽은 곡들 메타 데이터
		public List<MusicNoteData> noteDataStorage { get; set; }  //선택 곡의 노트 데이터

		//배속 관련
		const float SPEEDCONST = 1f;  //배속 상수s
		public float curBpm { get; set; }  //현재 재생 곡 BPM		
		[SerializeField] [Range((0), (10))] float speedMultiplier;  //배속 배수
		public float railSpeed { get; set; }  //레일 스피드 : 최종 노트 속도
	}
}