/*
*	Original Code :
*	https://forum.unity.com/threads/how-to-load-an-array-with-jsonutility.375735/#post-3039397
*	
*/

using System;
using UnityEngine;



public static class JsonParserHelper
{

	public static T[] FromJson<T>(string jsonArray)
	{
		jsonArray = "{ \"items\": " + jsonArray + "}";
		return FromJsonWrapped<T>(jsonArray);
	}

	public static T[] FromJsonWrapped<T>(string jsonObject)
	{
		Wrapper<T> wrapper = JsonUtility.FromJson<Wrapper<T>>(jsonObject);
		return wrapper.dialogues;
	}

	public static string ToJson<T>(T[] array)
	{
		Wrapper<T> wrapper = new Wrapper<T>();
		wrapper.dialogues = array;
		return JsonUtility.ToJson(wrapper);
	}

	public static string ToJson<T>(T[] array, bool prettyPrint)
	{
		Wrapper<T> wrapper = new Wrapper<T>();
		wrapper.dialogues = array;
		return JsonUtility.ToJson(wrapper, prettyPrint);
	}

	/// <summary>
	/// Json Wrapper Class Def
	/// </summary>
	/// <typeparam name="T"></typeparam>
	[Serializable]
	private class Wrapper<T>
	{
		public T[] dialogues;
	}
}