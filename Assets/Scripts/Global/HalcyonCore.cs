using UnityEngine;
using UnityEngine.Events;
using System.Collections;
using System.Collections.Generic;
using System;



namespace HalcyonCore
{
	//Delegates
	//Universal Delegate
	public delegate T genericDele<T, U>(params U[] link);

	//Modest Delegate
	public delegate void LightweightHandler();
	public delegate void messagingHandler(string message);
	public delegate void reflecMessagingHandler(string message, LightweightHandler reCall);	

	//=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=


	#region Active Scene Definition

	//씬 전반 진행 상태
	public enum sceneState
	{
		primalLoading, //최초 로딩 씬
		mainMenu,  //엔트리 메뉴 씬
		collecting,  //재료 수집 리듬겜 씬
		encounter  //몬스터 전투 리듬겜 씬
	}

	#endregion

	//노트 판정 열거자
	public enum noteJudgement
	{
		perfect,
		nice,
		miss
	}

	/// <summary>
	/// Dialogue Data Def
	/// </summary>
	[Serializable]
	public class Dialogue
	{
		public string speaker;  //화자(들)
		public string illust;  //뒷 배경, 일러스트
		public string state;  //화자의 상태 (이미지 일련 번호)
		public string dialogue;  //실질적인 대사 내용

		//=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=
	}
}