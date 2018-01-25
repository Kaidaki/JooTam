using UnityEngine;
using UnityEngine.Events;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;



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

#region State Definition

	//�κ� �� ���� ����
	public enum inLobbyStates
	{
		firstEntry,  //���� �ε�
		enteringList,  //���� ȭ�� �ε�
		InList,  //���� ȭ��
	}

	//�������� �� ���� ����
	public enum inRhythmicStageStates
	{
		firstEntry,  //���� �ε�
		enteringStage,  //�������� �ε�
		stageOn,  //�������� ȭ��
		result  //��� ȭ��
}

#endregion