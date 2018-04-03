using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class SceneTrigger : MonoBehaviour
{
	// Use this for initialization
	void Start()
	{
		GameManager.instance.exeTrigger();
	}
}