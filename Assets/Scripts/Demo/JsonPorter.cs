using UnityEngine;
using System.Collections;
using System;
using System.IO;
using HalcyonCore;



public class JsonPorter : MonoBehaviour
{
	private string FilePath;

	[SerializeField]
	TextAsset targetJson;

	void Start()
	{
		FilePath = Path.Combine(Application.persistentDataPath, "saveTest.json");
	}


	void OnGUI()
	{

		if (GUI.Button(new Rect(10, 70, 100, 50), "exeParsing"))
			testerExe();
		//exeForceLoadJson(targetJson.text);

	}

	/*
	void exeForceSaving()
	{
		MyClass myObject = new MyClass();
		myObject.level = 1;
		myObject.timeElapsed = 47.5f;
		myObject.playerName = "Dr Charles Francis";


		string json = JsonUtility.ToJson(myObject);
		File.WriteAllText(FilePath, json);
	}*/

	public void exeForceLoadJson(string jsonString)
	{
		Dialogue [] aw = JsonUtility.FromJson<Dialogue []>(jsonString);

		print(aw[0].dialogue);
		print(aw[1].dialogue);
		print(aw[2].dialogue);
		print(aw[3].dialogue);
	}


	public void testerExe()
	{
		print("{ \"items\": " + "some text" + "}");
	}
}


[Serializable]
public class MyClass
{
	public int level;
	public float timeElapsed;
	public string playerName;
}