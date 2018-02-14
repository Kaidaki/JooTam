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


	#region State Definition

	//�� ���� ���� ����
	public enum sceneState
	{
		primalLoading, //���� �ε� ��
		mainMenu,  //��Ʈ�� �޴� ��
		collecting,  //��� ���� ����� ��
		encounter  //���� ���� ����� ��
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

	//��Ʈ ���� ������
	public enum noteJudgement
	{
		perfect,
		nice,
		miss
	}
}