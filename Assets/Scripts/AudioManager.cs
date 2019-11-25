using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    // https://www.youtube.com/watch?v=QujIch7TPBU
    // https://alessandrofama.com/tutorials/fmod-unity/parameters/#Labeled_Parameters

    FMOD.Studio.EventInstance gameMusic;
    FMOD.Studio.EventInstance flightAttendantTurbulence, flightAttendantWelcome, planeAtmos, planeTakeOff;

    public FMOD.Studio.EventInstance drinking, eating;
    public FMOD.Studio.EventInstance pourDrink, serveFood;
    public FMOD.Studio.EventInstance mopping;
    public FMOD.Studio.EventInstance walking;
    public FMOD.Studio.EventInstance SFXVolumeTest; // at the moment it's toilet flush sound

    // For parameters of gameplay loop
    FMOD.Studio.EventDescription musicDescription;
    FMOD.Studio.PARAMETER_DESCRIPTION pd;
    FMOD.Studio.PARAMETER_ID pID;

    // For gameplay loop progression
    public static float progression = 0;

    public static AudioManager instance = null;

    // For audio accessibility 
    FMOD.Studio.Bus Master;
    FMOD.Studio.Bus Music;
    FMOD.Studio.Bus SFX;
    float MasterVolume = 1f;
    float MusicVolume = 0.5f;
    float SFXVolume = 0.5f;


    void Awake()
    {
        // the singleton
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
        SFXVolumeTest = FMODUnity.RuntimeManager.CreateInstance("event:/SFX/SFXVolumeTest");

    }

    void Start()
    {
        // connecting sounds in FMOD for unity
        // set up music
        gameMusic = FMODUnity.RuntimeManager.CreateInstance("event:/Music/Gameplay Loop");
        // set up atmos
        flightAttendantTurbulence = FMODUnity.RuntimeManager.CreateInstance("event:/Atmos/FlightAttendantTurbulence");
        flightAttendantWelcome = FMODUnity.RuntimeManager.CreateInstance("event:/Atmos/FlightAttendantWelcome");
        planeAtmos = FMODUnity.RuntimeManager.CreateInstance("event:/Atmos/PlaneAtmos");
        planeTakeOff = FMODUnity.RuntimeManager.CreateInstance("event:/Atmos/PlaneTakeOff");
        // set up sfx


        // set up parameters for gameplay loop
        musicDescription = FMODUnity.RuntimeManager.GetEventDescription("event:/Music/Gameplay Loop");
        musicDescription.getParameterDescriptionByName("Intensity", out pd);
        pID = pd.id;

        StartMenu();

    }

    public void StartMenu()
    {
        gameMusic.start();
        progression = 0;
        gameMusic.setParameterByID(pID, progression);
    }

    // Run this after "progression" has been changed
    public void MusicProgression()
    {
        gameMusic.setParameterByID(pID, progression);
    }


    void Update()
    {
        Master.setVolume(instance.MasterVolume);
        Music.setVolume(instance.MusicVolume);
        SFX.setVolume(instance.SFXVolume);

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
        if (PbState != FMOD.Studio.PLAYBACK_STATE.PLAYING)
        {
            SFXVolumeTest.start();
        }
    }
}
