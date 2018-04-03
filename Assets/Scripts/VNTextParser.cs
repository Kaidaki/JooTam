using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System;
using HalcyonCore;



public class VNTextParser : MonoBehaviour
{
	//Parser Target
	[SerializeField] TextAsset txt;  //dialog TXT
		
	public void exeParsing()
	{
		try
		{
			StringReader reader = new StringReader(txt.text);
			string singleLine = "something";
			

			//read one Line
			for(; ; )
			{
				singleLine = reader.ReadLine();

				if (singleLine == null)
					break;

				print(singleLine);
			}
		}

		catch(ObjectDisposedException ex)
		{			
			print("End Of Stream!");
		}
	}

	void OnGUI()
	{

		if (GUI.Button(new Rect(10, 70, 50, 30), "exeParsing"))
			exeParsing();
	}


	public class JsonHelper
	{
		public static T[] getJsonArray<T>(string json)
		{
			string newJson = "{ \"array\": " + json + "}";
			Wrapper<T> wrapper = JsonUtility.FromJson<Wrapper<T>>(newJson);
			return wrapper.array;
		}

		[Serializable]
		private class Wrapper<T>
		{
			public T[] array;
		}
	}

	public void exeParsingTest()
	{
		//YouObject[] objects = JsonHelper.getJsonArray<YouObject>(jsonString);
	}
}