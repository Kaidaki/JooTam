using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextImportTest : MonoBehaviour
{
	[SerializeField] TextAsset txt;


	void Start()
	{
		print(txt.text);
	}
}