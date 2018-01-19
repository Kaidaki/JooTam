using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using HalcyonCore;


namespace RhythmicStage
{
	public partial class DataManager : MonoBehaviour
	{
		//refs		
		//상위
		[SerializeField] GameManager coreCtrl;  //GM
												//하위	
		[SerializeField] fileReader fileDataCtrl;  //파일 정보 수입 클래스

		//sigleTon parts
		public static DataManager instance;

		//-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-

		// Use this for primal initialization
		void Awake()
		{
			//sigleTon parts
			instance = this;
		}
	}
}