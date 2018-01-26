﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using HalcyonCore;



namespace RhythmicStage
{
	public class BackLighter : MonoBehaviour
	{
		[SerializeField] SpriteRenderer renderingCtrl;


		public void exeLightOn()
		{
			renderingCtrl.enabled = true;
		}

		public void exeLightOff()
		{
			renderingCtrl.enabled = false;
		}
	}
}