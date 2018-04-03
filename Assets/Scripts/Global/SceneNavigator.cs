using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections.Generic;
using System;
using System.Collections;
using HalcyonCore;



public class SceneNavigator : MonoBehaviour
{
	Dictionary<string, Scene> sceneList;
	int totalSceneCount;

	WaitForSeconds loadReportDelay;  //로딩 진행 콘솔 출력 딜레이(caching)
	AsyncOperation asyncSceneLoader;  //비동기 씬 로더

	event LightweightHandler prepared;  //씬 로딩 완료 이벤트

	//=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=

	void Awake()
	{
		totalSceneCount = SceneManager.sceneCountInBuildSettings;
		loadReportDelay = new WaitForSeconds(0.2f);  //delay set
		DontDestroyOnLoad(this);
	}

	public void initializer()
	{
		checkingScenes();
	}

	void checkingScenes()
	{
		print("Total Built Scenes Count : " + totalSceneCount);

		//part of import scenes has been Built 
		for (int i = 0; i < totalSceneCount; i++)
		{
			Scene pickedScene = SceneManager.GetSceneByBuildIndex(i);
			sceneList.Add(pickedScene.name, pickedScene);
		}

		print("Dictionary has " + sceneList.Count + " Scene(s)");
	}

	public void exeLoadNextScene()
	{
		StartCoroutine(forceLoadNext_beta());
	}

	IEnumerator forceLoadNext_beta()
	{
		//인위적 딜레이 	
		//yield return new WaitForSeconds(1f);

		// Start an asynchronous operation to load the scene that was passed to the LoadNewScene coroutine.
		asyncSceneLoader = SceneManager.LoadSceneAsync(SceneManager.sceneCount + 1);
		asyncSceneLoader.allowSceneActivation = false;
		Debug.Log("execute Loading Next scene!!");
		
		// While the asynchronous operation to load the new scene is not yet complete, continue waiting until it's done.
		while (!asyncSceneLoader.isDone)
		{
			yield return loadReportDelay;
			Debug.Log("Loading... : " + asyncSceneLoader.progress * 100 + " %");

			if (asyncSceneLoader.progress >= 0.9f)
			{
				Debug.Log("Loading complete");
				//asyncSceneLoader.allowSceneActivation = true;
				if (prepared != null)
					prepared();
			}
		}

		yield return null;
	}

	IEnumerator forceLoadNext_beta(Scene certainScene)
	{
		//인위적 딜레이 	
		//yield return new WaitForSeconds(1f);

		// Start an asynchronous operation to load the scene that was passed to the LoadNewScene coroutine.
		asyncSceneLoader = SceneManager.LoadSceneAsync(certainScene.buildIndex);
		asyncSceneLoader.allowSceneActivation = false;
		Debug.Log("execute Loading Next scene!!");

		// While the asynchronous operation to load the new scene is not yet complete, continue waiting until it's done.
		while (!asyncSceneLoader.isDone)
		{
			yield return loadReportDelay;
			Debug.Log("Loading... : " + asyncSceneLoader.progress * 100 + " %");

			if (asyncSceneLoader.progress >= 0.9f)
			{
				Debug.Log("Loading complete");
				//asyncSceneLoader.allowSceneActivation = true;
				if (prepared != null)
					prepared();
			}
		}

		yield return null;
	}
}