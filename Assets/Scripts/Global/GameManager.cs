using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using HalcyonCore;



public partial class GameManager : MonoBehaviour, ICoreLinker
{
	//sigleTon parts
	public static GameManager instance = null;

	//refs
	[SerializeField] SceneNavigator sceneCtrl;  //as a Tool
	//DSU
	[SerializeField] DeepDataStorage deepDataCtrl;

	//Pure fields	
	List<ICoreTrigger> triggers;

	#region Const List
	const string coreGroupName = "Controllers";
	#endregion

	//-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-

	// Use this for primal initialization
	void Awake()
	{
		//sigleTon parts
		if (instance == null)
			instance = this;
		else
			Destroy(gameObject);

		DontDestroyOnLoad(this);
	}

	//Main() of Game
	// Use this for initialization after all Object are made
	// primary Loading
	void Start()
	{
		print("GM Triggered!");
		deepDataCtrl.linkerOfgm = this;

		//SceneNavigator initialize
		sceneCtrl.initializer();
	}

	//Searching Cores	
	public void exeLinkCores(ICoreTrigger linker)
	{
		triggers.Add(linker);
	}

	//Core Trigger On
	public void exeTrigger()
	{
		for(int i = 0; i < triggers.Count; i++)
		{
			triggers[i].trigger();
		}
	}
}