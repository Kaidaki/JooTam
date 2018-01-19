using UnityEngine;
using RhythmicStage;


public class InputManager : MonoBehaviour
{
	//refs
	//상위
	[SerializeField] RhythmicCore coreCtrl;

	//-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-

	// Update is called once per frame
	void Update()
	{
		// [4key] 숏노트 입력 & 롱노트 입력시작
		if (Input.GetKeyDown(KeyCode.F))  // F키 릴리즈
			coreCtrl.confShortInput(0);
		if (Input.GetKeyDown(KeyCode.D))  // D키 릴리즈
			coreCtrl.confShortInput(1);
		if (Input.GetKeyDown(KeyCode.J))  // J키 릴리즈
			coreCtrl.confShortInput(2);
		if (Input.GetKeyDown(KeyCode.K))  // K키 릴리즈
			coreCtrl.confShortInput(3);

		// [4key] 롱노트 입력취소
		if (Input.GetKeyUp(KeyCode.F))  // F키 릴리즈
			coreCtrl.confLongDeactivate(0);
		if (Input.GetKeyUp(KeyCode.F))  // D키 릴리즈
			coreCtrl.confLongDeactivate(1);
		if (Input.GetKeyUp(KeyCode.F))  // J키 릴리즈
			coreCtrl.confLongDeactivate(2);
		if (Input.GetKeyUp(KeyCode.F))  // K키 릴리즈
			coreCtrl.confLongDeactivate(3);
	}
}
