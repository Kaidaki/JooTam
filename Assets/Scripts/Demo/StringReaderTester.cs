using UnityEngine;
using System.Collections;
using System.IO;

public class StringReaderTester : MonoBehaviour
{

	[SerializeField] TextAsset asset;
	StringReader reader;

	// Use this for initialization
	void Start()
	{
		reader = new StringReader(asset.text);
	}	

	void OnGUI()
	{
		if (GUI.Button(new Rect(10, 70, 100, 50), "Testing"))
			testerExe();
	}

	void testerExe()
	{
		skipMetaDataBlock();

		print(reader.Peek());

	}

	private void skipMetaDataBlock()
	{
		for (int i = 0; i < 21; i++)
			reader.ReadLine();
	}
}
