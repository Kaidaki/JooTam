using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Kaibrary;
using HalcyonCore;
using System.Diagnostics;
using UnityEngine;



namespace RhythmicStage
{
	public partial class NoteDropper : MonoBehaviour
	{
		//refs
		//����
		[SerializeField] GameObjectManager objectCtrl;
		//LocalStorage
		[SerializeField] LocalStorage dataCtrl;

		//Pure fields
		[SerializeField] Transform judgeLine;
		[SerializeField] Transform[] dropPoint;
		[SerializeField] float dropDistance;

		[SerializeField] GameObject noteObject;  //�� ��Ʈ ������Ʈ	
		int poolSize;  //������Ʈ Ǯ �ִ� ���뷮

		//������Ʈ Ǯ ���۷���
		Queue<GameObject>[] poolQueue;  //��Ȱ�� ������Ʈ ���ť
		Queue<GameObject>[] activePoolQueue;  //Ȱ�� ������Ʈ ����ť

		//��Ÿ
		Queue<NoteJudgeCard>[] judgeScroll;  //���纻(�ӽ�)
		Stopwatch stopwatch = NoteReferee.stopwatch;  //��Ʈ ���� Ŭ������ �����ġ �ޱ�
		float preLoadingTime;

		//-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-

		// Use this for initialization
		void Start()
		{
			//�������� �Ÿ� ���(= ��Ʈ�� �� �̵��Ÿ�)
			dropDistance = VectorTreatTools.distance(this.transform, judgeLine);
		}

		// Update is called once per frame
		void Update()
		{

		}
	}

	public partial class NoteDropper : MonoBehaviour
	{

	}
}