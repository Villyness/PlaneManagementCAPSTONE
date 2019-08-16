using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    FMOD.Studio.EventInstance music;// game music

    FMOD.Studio.EventDescription musicDescription;
    FMOD.Studio.PARAMETER_DESCRIPTION pd;
    FMOD.Studio.PARAMETER_ID pID;

    static AudioManager instance = null;


    void awake()
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
    }

    void Start()
    {
        music = FMODUnity.RuntimeManager.CreateInstance("event:/Music/Gameplay Loop");
        music.start();

        musicDescription = FMODUnity.RuntimeManager.GetEventDescription("event:/Music/Gameplay Loop");
        musicDescription.getParameterDescriptionByName("Intensity", out pd);
        pID = pd.id;
    }

    public void GameplayStart()
    {
        music.setParameterByID(pID, 1);
    }

    // Update is called once per frame
    void Update()
    {


    }
}
