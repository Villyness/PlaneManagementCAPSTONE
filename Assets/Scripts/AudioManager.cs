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
        Master = FMODUnity.RuntimeManager.GetBus("bus:/Master");
        Music = FMODUnity.RuntimeManager.GetBus("bus:/Master/Music");
        SFX = FMODUnity.RuntimeManager.GetBus("bus:/Master/SFX");
    }

    void Start()
    {
        gameMusic = FMODUnity.RuntimeManager.CreateInstance("event:/Music/Gameplay Loop");
        gameMusic.start();

        musicDescription = FMODUnity.RuntimeManager.GetEventDescription("event:/Music/Gameplay Loop");
        musicDescription.getParameterDescriptionByName("Intensity", out pd);
        pID = pd.id;
    }

    public void GameplayStart()
    {
        gameMusic.setParameterByID(pID, 1);
    }

    // Update is called once per frame
    void Update()
    {
        Master.setVolume(MasterVolume);
        Music.setVolume(MusicVolume);
        SFX.setVolume(SFXVolume);
    }

    public void MasterVolumeLevel(float newMasterVolume)
    {
        MasterVolume = newMasterVolume;
    }

    public void MusicVolumeLevel(float newMusicVolume)
    {
        MusicVolume = newMusicVolume;
    }

    public void SFXVolumeLevel(float newSFXVolume)
    {
        SFXVolume = newSFXVolume;

        FMOD.Studio.PLAYBACK_STATE PbState;
        SFXVolumeTest.getPlaybackState(out PbState);
        if(PbState != FMOD.Studio.PLAYBACK_STATE.PLAYING)
        {
            SFXVolumeTest.start();
        }
    }
}
