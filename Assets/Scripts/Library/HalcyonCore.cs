using UnityEngine;
using UnityEngine.Events;
using System.Collections;



namespace HalcyonCore
{
	//Delegates
	//Universal Delegate
	public delegate T genericDele<T, U>(params U[] link);

	//Modest Delegate
	public delegate void LightweightDele();
	public delegate void messagingDele(string message);
	public delegate void reflecMessagingDele(string message, LightweightDele reCall);

	//-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=
}


//로비 씬 진행 상태
public enum inLobbyStates
{
	firstEntry,  //최초 로딩
	enteringList,  //선곡 화면 로딩
	InList,  //선곡 화면
}

//스테이지 씬 진행 상태
public enum inStageStates
{
	firstEntry,  //최초 로딩
	enteringStage,  //스테이지 로딩
	InStage,  //스테이지 화면
	result  //결과 화면
}
