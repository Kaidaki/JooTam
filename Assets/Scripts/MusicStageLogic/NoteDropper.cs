using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Kaibrary;
using HalcyonCore;



public class NoteDropper : MonoBehaviour
{

	[SerializeField] DataStorage dataCtrl;

	[SerializeField] Transform judgeLine;
	[SerializeField] Transform [] dropPoint;
	[SerializeField] float dropDistance;

	// Use this for initialization
	void Start()	
	{
		dropDistance = VectorTreatTools.distance(this.transform, judgeLine);
	}

	// Update is called once per frame
	void Update()
	{

	}
}