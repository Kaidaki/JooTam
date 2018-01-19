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


//�κ� �� ���� ����
public enum inLobbyStates
{
	firstEntry,  //���� �ε�
	enteringList,  //���� ȭ�� �ε�
	InList,  //���� ȭ��
}

//�������� �� ���� ����
public enum inStageStates
{
	firstEntry,  //���� �ε�
	enteringStage,  //�������� �ε�
	InStage,  //�������� ȭ��
	result  //��� ȭ��
}
