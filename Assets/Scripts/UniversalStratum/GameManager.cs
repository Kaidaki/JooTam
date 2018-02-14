using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using HalcyonCore;



public partial class GameManager : MonoBehaviour
{
	//SingleTon parts
	public static GameManager instance;

	//-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-

	// Use this for primal initialization
	void Awake()
	{
		DontDestroyOnLoad(this);
		instance = this;
	}

	// Use this for initialization after all Object are made
	void Start()
	{

	}

	class FSM : IEnumerator
	{
		public object Current { set; get; }

		public bool MoveNext()
		{
			return true;
		}

		public void Reset()
		{

		}
	}
}


public enum state
{

}