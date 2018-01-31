using System.Collections.Generic;
using System.Globalization;
using UnityEngine;



//��Ʈ, ��Ÿ������ ����
namespace HalcyonCore
{
	/// <summary>
	///		��Ʈ���� ť�� �־��� ��Ʈ ��ġ ���
	/// </summary>
	public struct NoteJudgeCard
	{
		public int noteType { get;  set; }  //��Ʈ Ÿ��
		public float time { get;  set; }  // �ش� NoteUnit�� ��� �ð�
		public int unitNum { get;  set; }  //���� �Ϸù�ȣ
	
		//-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-
		
		/// <summary>
		///		��Ʈ���� ī�� ������
		/// </summary>
		/// <param name="noteType">� ��Ʈ ��������</param>
		/// <param name="time">ó�� ���� ����</param>
		/// <param name="unitNum">ó�� ���� ���� ����</param>
		public NoteJudgeCard(int noteType, float time, int unitNum)
		{
			this.noteType = noteType;
			this.time = time;
			this.unitNum = unitNum;
		}

		/// <summary>
		///		�ش� ī�� ���� ��� for Test
		/// </summary>
		public void printContent()
		{
			Debug.Log("Type : " + noteType + " :: " + time + " (ms)__[ " + unitNum + " ]");
		}

		public NoteJudgeCard turnToObject()
		{
			return new NoteJudgeCard(noteType, time, unitNum);
		}
	}
	

	/// <summary>
	///		��Ÿ ������ Ŭ����
	/// </summary>
	public class MusicMetaData
	{
		//ä�� ��Ÿ ������
		public string title { get; private set; }  //��������
		public string jacket { get; private set; }  //�����̹��� ���ϸ�(���)
		public string difficulty { get; private set; }  //���� ���̵�
		public string music { get; private set; }  //���� ���ϸ�(���)
		public int length { get; set; }  //���� ����(second)
		public float bpm { get; set; }  //Beat Per Minute
		public int unit { get; set; }  //���� ���� ��
		public float? samplePlayCursor { get; set; }  //���� �̸���� ��� ��ġ
		public float? sampleLength { get; set; }  //�̸���� ��� ����		

		//-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-

		/// <summary>
		///		��Ÿ ������ Ŭ���� ������
		/// </summary>
		/// <param name="metaList">���� ���� ���ڿ� ����Ʈ ���۷���</param>
		public MusicMetaData(List<string> metaList)
		{
			title = metaList[0];
			jacket = metaList[1];
			difficulty = metaList[2];
			music = metaList[3];
			length = int.Parse(metaList[4]);
			bpm = float.Parse(metaList[5], CultureInfo.InvariantCulture);
			unit = int.Parse(metaList[6]);
			samplePlayCursor = float.Parse(metaList[7], CultureInfo.InvariantCulture);
			sampleLength = float.Parse(metaList[8], CultureInfo.InvariantCulture);
		}

		/// <summary>
		///		��Ÿ ������ ����Ʈ ��� (�� �ٷ� Test)
		/// </summary>
		public void printMetaData()
		{
			Debug.Log(title + " || " + jacket + " || " + difficulty + " || " 
				+ music + " || " + length + " || " + bpm + " || " + unit + " || " 
				+ samplePlayCursor + " || " + sampleLength);
		}
	}


	/// <summary>
	///		��Ʈ ������ ���� ����ü
	/// </summary>
	public struct MusicNoteData
	{
		public int[] noteData { get; set; }  // ��Ʈ ��ġ ����. ũ��� 3 [ 3Key ]
		public float time { get; set; }  // �ش� NoteUnit�� ��� �ð�
		public int unitTiming { get; set; } //���� �Ϸù�ȣ
		public bool hasNoteData { get; set; }  //�ش� ���ֿ� ��Ʈ ���� ����

		//000 ---+ ó�� ���� [ 3Key ]

		//-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-

		/// <summary>
		///		��Ʈ ������ ���� ����ü ������
		/// </summary>
		/// <param name="unitNoteData">��Ʈ ���� �迭 ���۷���</param>
		/// <param name="unitTime">��Ʈ ����</param>
		/// <param name="treatUnit">��Ʈ ���� ����</param>
		/// <param name="hasNoteData">��Ʈ ������ ���� ����</param>
		public MusicNoteData(int[] unitNoteData, float unitTime, int treatUnit, bool hasNoteData)
		{
			noteData = unitNoteData;
			time = unitTime;
			unitTiming = treatUnit;
			this.hasNoteData = hasNoteData;
		}

		/// <summary>
		///		get : ���� ���� ��Ʈ ������ ���
		/// </summary>
		public void printNoteArray()
		{
			foreach(int i in noteData)
			{
				Debug.Log(i + " : " + unitTiming);
			}
		}

		/// <summary>
		///		get : ���� ���� ��Ʈ ������ ���� ����
		/// </summary>
		/// <returns>
		///		��� ��Ʈ ������ ���� : true
		///		���� ���� ���� : false
		/// </returns>
		public bool noteExistCheck()
		{
			return hasNoteData;
		}

		public string getCurNoteDataAsString( )
		{
			string temp = time + " (ms) :: " ;
			for(int i = 0; i < noteData.Length; i++)
			{
				temp += noteData[i].ToString( );
			}
			temp += "(" + unitTiming + ")";
			return temp;
		}
	}
}