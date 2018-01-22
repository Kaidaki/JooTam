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
		// [ 3key ] 숏노트 입력 & 롱노트 입력시작
		if (Input.GetKeyDown(KeyCode.Keypad0))  // F키 릴리즈
			coreCtrl.confShortInput(0);
		if (Input.GetKeyDown(KeyCode.Keypad1))  // D키 릴리즈
			coreCtrl.confShortInput(1);
		if (Input.GetKeyDown(KeyCode.Keypad2))  // J키 릴리즈
			coreCtrl.confShortInput(2);

		// [ 3key ] 롱노트 입력취소
		if (Input.GetKeyUp(KeyCode.Keypad0))  // F키 릴리즈
			coreCtrl.confLongDeactivate(0);
		if (Input.GetKeyUp(KeyCode.Keypad1))  // D키 릴리즈
			coreCtrl.confLongDeactivate(1);
		if (Input.GetKeyUp(KeyCode.Keypad2))  // J키 릴리즈
			coreCtrl.confLongDeactivate(2);
	}
}
