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
		// [4key] ����Ʈ �Է� & �ճ�Ʈ �Է½���
		if (Input.GetKeyDown(KeyCode.F))  // FŰ ������
			coreCtrl.confShortInput(0);
		if (Input.GetKeyDown(KeyCode.D))  // DŰ ������
			coreCtrl.confShortInput(1);
		if (Input.GetKeyDown(KeyCode.J))  // JŰ ������
			coreCtrl.confShortInput(2);
		if (Input.GetKeyDown(KeyCode.K))  // KŰ ������
			coreCtrl.confShortInput(3);

		// [4key] �ճ�Ʈ �Է����
		if (Input.GetKeyUp(KeyCode.F))  // FŰ ������
			coreCtrl.confLongDeactivate(0);
		if (Input.GetKeyUp(KeyCode.F))  // DŰ ������
			coreCtrl.confLongDeactivate(1);
		if (Input.GetKeyUp(KeyCode.F))  // JŰ ������
			coreCtrl.confLongDeactivate(2);
		if (Input.GetKeyUp(KeyCode.F))  // KŰ ������
			coreCtrl.confLongDeactivate(3);
	}
}
