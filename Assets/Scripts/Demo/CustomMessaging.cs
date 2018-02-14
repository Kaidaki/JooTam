using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;



public class CustomMessaging : MonoBehaviour, ICustomMessageTarget
{

	// Use this for initialization
	void Start()
	{

	}

	// Update is called once per frame
	void Update()
	{

	}

	public void Message1()
	{
		Debug.Log("Message 1 received");
	}

	public void Message2()
	{
		Debug.Log("Message 2 received");
	}

}


public interface ICustomMessageTarget : IEventSystemHandler
{
	// functions that can be called via the messaging system
	void Message1();
	void Message2();
}