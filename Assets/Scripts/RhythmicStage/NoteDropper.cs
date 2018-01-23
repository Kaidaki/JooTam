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
		//상위
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
			//판정선과 거리 계산(= 노트의 총 이동거리)
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