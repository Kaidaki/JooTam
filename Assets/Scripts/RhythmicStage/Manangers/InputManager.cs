using UnityEngine;
using RhythmicStage;



public class InputManager : MonoBehaviour
{
	//refs
	//����
	[SerializeField] RhythmicCore coreCtrl;

	//-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-

	// Update is called once per frame
	void Update()
	{
		#if UNITY_EDITOR_WIN || UNITY_STANDALONE_WIN
		// [ 3key ] ����Ʈ �Է� & �ճ�Ʈ �Է½���
		if (Input.GetKeyDown(KeyCode.Keypad1))  // 1Ű ������
			coreCtrl.confShortInput(0);
		if (Input.GetKeyDown(KeyCode.Keypad2))  // 2Ű ������
			coreCtrl.confShortInput(1);
		if (Input.GetKeyDown(KeyCode.Keypad3))  // 3Ű ������
			coreCtrl.confShortInput(2);

		// [ 3key ] �ճ�Ʈ �Է����
		if (Input.GetKeyUp(KeyCode.Keypad1))  // FŰ ������
			coreCtrl.confLongDeactivate(0);
		if (Input.GetKeyUp(KeyCode.Keypad2))  // DŰ ������
			coreCtrl.confLongDeactivate(1);
		if (Input.GetKeyUp(KeyCode.Keypad3))  // JŰ ������
			coreCtrl.confLongDeactivate(2);
		#else


		#endif
	}
}
