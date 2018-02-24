using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using HalcyonCore;



public partial class GameManager : MonoBehaviour
{
	//SingleTon parts
	public static GameManager instance;
	[SerializeField] float distance = 10f;
	List<ICoreTrigger> triggers;

	//-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-

	// Use this for primal initialization
	void Awake()
	{
		DontDestroyOnLoad(this);
		instance = this;
	}

	//Main() of Game
	// Use this for initialization after all Object are made
	void Start()
	{
		print("GM Triggered!");
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