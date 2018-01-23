using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Kaibrary;
using HalcyonCore;



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