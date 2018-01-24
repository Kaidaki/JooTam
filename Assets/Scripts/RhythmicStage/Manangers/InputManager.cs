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
		// [ 3key ] ����Ʈ �Է� & �ճ�Ʈ �Է½���
		if (Input.GetKeyDown(KeyCode.Keypad0))  // FŰ ������
			coreCtrl.confShortInput(0);
		if (Input.GetKeyDown(KeyCode.Keypad1))  // DŰ ������
			coreCtrl.confShortInput(1);
		if (Input.GetKeyDown(KeyCode.Keypad2))  // JŰ ������
			coreCtrl.confShortInput(2);

		// [ 3key ] �ճ�Ʈ �Է����
		if (Input.GetKeyUp(KeyCode.Keypad0))  // FŰ ������
			coreCtrl.confLongDeactivate(0);
		if (Input.GetKeyUp(KeyCode.Keypad1))  // DŰ ������
			coreCtrl.confLongDeactivate(1);
		if (Input.GetKeyUp(KeyCode.Keypad2))  // JŰ ������
			coreCtrl.confLongDeactivate(2);
	}
}
