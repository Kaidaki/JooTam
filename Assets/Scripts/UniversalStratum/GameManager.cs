using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using HalcyonCore;



public class GameManager : MonoBehaviour
{
	//SingleTon parts
	public static GameManager instance;

	//-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-

	// Use this for primal initialization
	void Awake()
	{
		instance = this;
		DontDestroyOnLoad(this);
	}

	// Use this for initialization after all Object are made
	void Start()
	{

	}

	IEnumerator FSM()
	{
		yield break;
	}
}