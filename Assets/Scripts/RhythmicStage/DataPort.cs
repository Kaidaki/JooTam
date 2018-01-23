using UnityEngine;
using System.Collections;



namespace RhythmicStage
{
	public class DataPort : MonoBehaviour
	{
		//refs
		//직속상위
		[SerializeField] DataManager dataCtrl;
		//DeepStorageUnit
		[SerializeField] DeepDataStorage deepDataCtrl;
		//localStorage
		[SerializeField] LocalStorage storageCtrl;

		//# for Test
		string path = @"D:\Unity_Workspace\GroupWorkSpace\ProjectJT\JooTam\Assets\Resources\Songs\Inixia\Inixia.txt";

		//-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-

		//선곡 정보 경로 수입 메소드
		public string exeImportMusicPath()
		{
			return path;
		}
	}
}