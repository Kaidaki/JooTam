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

	//�� ���� ���� ����
	public enum sceneState
	{
		primalLoading, //���� �ε� ��
		mainMenu,  //��Ʈ�� �޴� ��
		collecting,  //��� ���� ����� ��
		encounter  //���� ���� ����� ��
	}

	#endregion

	//��Ʈ ���� ������
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
		public string speaker;  //ȭ��(��)
		public string illust;  //�� ���, �Ϸ���Ʈ
		public string state;  //ȭ���� ���� (�̹��� �Ϸ� ��ȣ)
		public string dialogue;  //�������� ��� ����

		//=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=
	}
}