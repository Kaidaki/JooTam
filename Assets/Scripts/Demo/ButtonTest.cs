using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;



public class ButtonTest : MonoBehaviour
{

	[SerializeField] CustomMessaging testCtrl;
	[SerializeField] Button buttonCtrl;

	// Use this for initialization
	void Start()
	{
		buttonCtrl.onClick.AddListener(testCtrl.Message1);
	}
}