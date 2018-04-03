using UnityEngine;
using System.Collections;
using HalcyonCore;



namespace PrimalScene
{
	public partial class PrimalPageCore : CoreBase, ICoreTrigger
	{
		//refs
		[SerializeField] CurtainBehaviour curtainCtrl;

		//=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=

		/// <summary>
		///		trigger from GM
		/// </summary>
		public void trigger()
		{
		}

		void Start()
		{
			curtainCtrl.addListener(reportNextScene);
		}

		//다음 씬 준비 보고
		public void reportNextScene()
		{
			
		}
	}
}