using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Kaibrary;



namespace PrimalScene
{
	public class SoundManager : MonoBehaviour
	{
		//refs
		//상위

		//for Test
		public AudioClip[] auidioFile;  //오디오 파일 연결 클립(배열)
		[SerializeField] AudioSource musicPlayer;  //오디오 플레이어

		//-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-
		
		/*
		//클립 선택 재생
		void playMusic(int clipNum = 0)
		{
			musicPlayer.clip = auidioFile[clipNum];  //특정 번호의 클립 연결
			musicPlayer.time = 0.0f;
			musicPlayer.Play();  //재생
		}*/

		//Execution parts : exe-
		//-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-

		//페이드 아웃 후 정지
		public void exeStopMusic()
		{
			StartCoroutine(AudioForge.volumeFadeOutNStop(musicPlayer, 1.5f));
		}
	}
}