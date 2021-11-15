using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using anogamelib;
using UnityEngine.SceneManagement;

public class AudioManager : Singleton<AudioManager>
{
    public AudioClip[] clips;
    public AudioClip[] SE_Unit;
    public AudioClip[] SE_Enemy;
    private AudioSource audios;
    private int SceneIndex;

    public override void Initialize()
    {
        base.Initialize();
        audios = GetComponent<AudioSource>();
        ChangeBGM();
        DontDestroyOnLoad(gameObject);
        SceneManager.sceneLoaded += SceneManager_sceneLoaded;
    }

    private void SceneManager_sceneLoaded(Scene arg0, LoadSceneMode arg1)
    {
        if (arg1 == LoadSceneMode.Single)
        {
            ChangeBGM();
        }
    }

    private void ChangeBGM()
    {
        if (SceneIndex != SceneManager.GetActiveScene().buildIndex)
        {
            SceneIndex = SceneManager.GetActiveScene().buildIndex;
            audios.clip = clips[SceneIndex];
        }
        SetBGM();
    }

    public void SetBGM()
    {
        if (TitleData.Instance.Config.GetInt(Define.KeyBGMOn) == 0)
        {
            audios.Play();
        }
        else
        {
            audios.Stop();
        }
    }
}