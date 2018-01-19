using System.Collections.Generic;
using System.Globalization;
using UnityEngine;



//��Ʈ, ��Ÿ������ ����
namespace Kaibrary.MusicScrolls
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
		public float samplePlayCursor { get; set; }  //���� �̸���� ��� ��ġ
		public float sampleLength { get; set; }  //�̸���� ��� ����

		//��Ʈ ��ġ ������
		//MusicNoteData noteStruct;  //��Ʈ ������ ���� Ŭ���� ���۷���

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
		int[] noteData;  // ��Ʈ ��ġ ����. ũ��� 13
		float time;  // �ش� NoteUnit�� ��� �ð�
		int unitTiming; //���� �Ϸù�ȣ
		bool hasNoteData;  //�ش� ���ֿ� ��Ʈ ���� ����

		//000 | 000 | 000 | 000 | 0  ---+ ó�� ����

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
		///		get : ������� ��Ʈ ���� �迭 ��ȯ �޼ҵ�
		/// </summary>
		/// <returns>
		///		��Ʈ ���� �迭 ���۷���
		/// </returns>
		public int[] getLocatedArray()
		{
			return noteData;
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

		/// <summary>
		///		get : ��Ʈ�� ��ġ�ϴ� ���ֹ�ȣ
		/// </summary>
		public int getLineUnit()
		{
			return unitTiming;
		}

		/// <summary>
		///		get : �ش� ������ ��� ����(ms)
		/// </summary>		
		public float getLineTiming()
		{
			return time;
		}

		public string getCurNoteDataAsString( )
		{
			string temp = time + " (ms) :: " ;
			for(int i = 0; i < 13; i++)
			{
				temp += noteData[i].ToString( );
			}
			temp += "(" + unitTiming + ")";
			return temp;
		}
	}
}
