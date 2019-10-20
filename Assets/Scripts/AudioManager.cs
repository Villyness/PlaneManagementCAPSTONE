using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    FMOD.Studio.EventInstance gameMusic; // game music
    FMOD.Studio.EventInstance SFXVolumeTest; // need to pick a sfx later in FMOD

    FMOD.Studio.EventDescription musicDescription;
    FMOD.Studio.PARAMETER_DESCRIPTION pd;
    FMOD.Studio.PARAMETER_ID pID;

    static AudioManager instance = null;

    FMOD.Studio.Bus Master;
    FMOD.Studio.Bus Music;
    FMOD.Studio.Bus SFX;
    float MasterVolume = 1f;
    float MusicVolume = 0.5f;
    float SFXVolume = 0.5f;


    void Awake()
    {
        if (instance != null)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
            GameObject.DontDestroyOnLoad(gameObject);
        }
        instance.Master = FMODUnity.RuntimeManager.GetBus("bus:/Master");
        instance.Music = FMODUnity.RuntimeManager.GetBus("bus:/Master/Music");
        instance.SFX = FMODUnity.RuntimeManager.GetBus("bus:/Master/SFX");
    }

    void Start()
    {
        instance.gameMusic = FMODUnity.RuntimeManager.CreateInstance("event:/Music/Gameplay Loop");
        instance.gameMusic.start();

        instance.musicDescription = FMODUnity.RuntimeManager.GetEventDescription("event:/Music/Gameplay Loop");
        instance.musicDescription.getParameterDescriptionByName("Intensity", out pd);
        instance.pID = pd.id;
    }

    public void GameplayStart()
    {
        instance.gameMusic.setParameterByID(pID, 1);
    }

    public void StartMenu()
    {
        instance.gameMusic.setParameterByID(pID, 0);
    }

    // Update is called once per frame
    void Update()
    {
        instance.Master.setVolume(instance.MasterVolume);
        instance.Music.setVolume(instance.MusicVolume);
        instance.SFX.setVolume(instance.SFXVolume);
    }

    public void MasterVolumeLevel(float newMasterVolume)
    {
        instance.MasterVolume = newMasterVolume;
    }

    public void MusicVolumeLevel(float newMusicVolume)
    {
        instance.MusicVolume = newMusicVolume;
    }

    public void SFXVolumeLevel(float newSFXVolume)
    {
        instance.SFXVolume = newSFXVolume;

        FMOD.Studio.PLAYBACK_STATE PbState;
        instance.SFXVolumeTest.getPlaybackState(out PbState);
        if(PbState != FMOD.Studio.PLAYBACK_STATE.PLAYING)
        {
            instance.SFXVolumeTest.start();
        }
    }
}
