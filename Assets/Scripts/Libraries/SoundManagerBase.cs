using UnityEngine;



public class SoundManagerBase : MonoBehaviour
{
	//refs
	//상위

	//for Test
	public AudioClip[] auidioFile;  //오디오 파일 연결 클립(배열)
	[SerializeField] AudioSource musicPlayer;  //오디오 플레이어

	//=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=

	//Selective playing a Clip
	protected void playMusic(int clipNum = 0)
	{
		musicPlayer.clip = auidioFile[clipNum];  //특정 번호의 클립 연결
		musicPlayer.time = 0.0f;
		musicPlayer.Play();  //재생
	}

	//Manual Clip PreLoading
	protected void manualPreLoading(int clipNum = 0)
	{
		musicPlayer.clip = auidioFile[clipNum];  //특정 번호의 클립 연결
		musicPlayer.Play();  //재생
		musicPlayer.Stop();
		musicPlayer.time = 0.0f;
	}
}
