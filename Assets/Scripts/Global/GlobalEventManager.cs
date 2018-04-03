using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using HalcyonCore;



public class GlobalEventManager : MonoBehaviour
{
	private static GlobalEventManager s_Instance = null;

	// Use this for initialization
	void Awake()
	{
		DontDestroyOnLoad(this);
	}

	// Update is called once per frame
	void Update()
	{

	}
}