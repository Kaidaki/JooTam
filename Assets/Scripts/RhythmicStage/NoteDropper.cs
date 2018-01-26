using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using Kaibrary;
using HalcyonCore;
using System.Diagnostics;



namespace RhythmicStage
{
	//���� ���� ��� ����
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

		[SerializeField] GameObject shortNoteObject;  //�� ��Ʈ ������Ʈ	
		

		//Object Pool
		Queue<GameObject>[] poolQueue;  //��Ȱ�� ������Ʈ ���ť
		Queue<GameObject>[] activePoolQueue;  //Ȱ�� ������Ʈ ����ť
		int poolSize;  //������Ʈ Ǯ �ִ� ���뷮

		//etc
		Queue<NoteJudgeCard>[] noteScroll;  //���纻(�ӽ�)
		Stopwatch stopwatch = NoteReferee.stopwatch;  //������ Ŭ������ �����ġ �ޱ�
		float preLoadingTime;
		int Channel;
		float railSpeed = 0;

		//-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-

		// Use this for primal initialization
		void Awake()
		{
			//�ʱ�, ���ǰ� �ʱ�ȭ ��
			poolSize = 50;  //������ �ʱ⼳����		
			preLoadingTime = 750f;  //�����ε�
			Channel = dataCtrl.curChannel;


			//��Ȱ�� ������Ʈ ���ť �迭 ���� ��
			poolQueue = new Queue<GameObject>[Channel];
			for (int i = 0; i < Channel; i++)  //ä�� �� ��ŭ ��⿭ ����
			{
				poolQueue[i] = new Queue<GameObject>(poolSize);  //���� ũ�� ��ŭ 
			}

			//Ȱ�� ������Ʈ ����ť �迭 ���� ��
			activePoolQueue = new Queue<GameObject>[Channel];
			for (int i = 0; i < Channel; i++)  //ä�� �� ��ŭ ��⿭ ����
			{
				activePoolQueue[i] = new Queue<GameObject>(poolSize);  //���� ũ�� ��ŭ 
			}		
		}

		// Use this for initialization after all Object are made
		void Start()
		{
			//�������� �Ÿ� ���(= ��Ʈ�� �� �̵��Ÿ�)
			dropDistance = VectorTreatTools.distance(this.transform, judgeLine);
			//��Ʈ�ӵ� ��� ��
			speedCal();

			//this.enabled = false;
		}

		// Update is called once per frame
		void Update()
		{
			#region ShortNote PreLoading Part	
			
			for (int row = 0; row < Channel; row++)
			{
				Queue<NoteJudgeCard> noteLine = noteScroll[row];

				try
				{
					//�����ε� ������ ��ģ ��Ʈ �߰�
					if (noteLine.Peek().time <= stopwatch.ElapsedMilliseconds + preLoadingTime)
					{
						//Short Note Pop
						dealShortNote(noteLine.Dequeue(), row);  //ť���� ����
						//print("Pop ShortNote! __ PreLoading ( " + (stopwatch.ElapsedMilliseconds + preLoadingTime) + " ) corr : " + stopwatch.ElapsedMilliseconds);
					}
				}
				catch (InvalidOperationException)
				{
					
				}
			}
			#endregion

			#region LongNote PreLoading part


			#endregion
		}

		//������Ʈ Ǯ ��� ���� �޼ҵ�
		void createNoteObject()
		{
			for (int row = 0; row < Channel; row++)
			{  //ä�� ���� ����
				for (int i = 0; i < poolSize; i++)
				{  //Ǯ ������ ��ŭ
					GameObject creation = Instantiate(shortNoteObject, dropPoint[row]);  //������Ʈ ����
					
					creation.SetActive(false);  //��Ȱ��ȭ
					poolQueue[row].Enqueue(creation);  //������Ʈ�� ���ť �Է�
				}
			}
		}

		//�������� ���� �ε� ���� ��Ʈ ��ġ
		void dealInitialNote()
		{

		}

		//�˸´� ����(����)�� ��Ʈ ��ġ
		void dealShortNote(NoteJudgeCard shortNoteData, int channel)
		{
			GameObject shortNote = poolQueue[channel].Dequeue();  //��Ȱ�� Ǯ���� �� ���� ��Ʈ			
			shortNote.GetComponent<ShortNoteBehaviour>().setSpeed(railSpeed);
			shortNote.SetActive(true);  //Ȱ��ȭ (��Ʈ �߻�)
			activePoolQueue[channel].Enqueue(shortNote);
		}

		//Ǯ�� ������Ʈ ȸ�� �޼ҵ�(�� ���� Ǯ)
		public void collectObject(GameObject endedNote, int channel)
		{
			poolQueue[channel].Enqueue(endedNote);  //�˸´� ť�� �ٽ� �Է�(������Ʈ ȸ��)
		}

		//�̽� ��Ʈ ������Ʈ ȸ��
		public void returnMissingNote(int channel)
		{
			GameObject missingShortNote = activePoolQueue[channel].Dequeue();  //Ȱ�� Ǯ���� ���� ��
			missingShortNote.SetActive(false);  //��Ȱ��ȭ
			missingShortNote.transform.position = dropPoint[channel].position;  //��ġ �ʱ�ȭ ��			
			poolQueue[channel].Enqueue(missingShortNote);  //��Ȱ�� Ǯ�� �ֱ�
		}

		//BPM�� ���� �ӵ� ��� ��
		public void speedCal()
		{	
			railSpeed = dropDistance / (preLoadingTime / 1000f);
		}

		public void exeShowTime()
		{
			this.enabled = true;
			print("start Checking Note Queue " + isActiveAndEnabled.ToString());			
		}
	}

	//���� ��� �޼��� ����
	public partial class NoteDropper : MonoBehaviour
	{
		//Execution parts : exe-
		//-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-

		//Ʈ���� ����
		public void exeLinkTriggerNLoad(reflecMessagingDele Handler)
		{
			//������Ʈ ���� ��
			createNoteObject();

			//������ ���� ��
			noteScroll = dataCtrl.noteScroll;			

			//�ε� �Ϸ�
			Handler("NoteDropper : Order is received!", exeShowTime);
		}
	}
}