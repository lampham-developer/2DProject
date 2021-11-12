using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundController : MonoBehaviour
{
    public static SoundController SoundControllerSingleton;

    public AudioSource fireSound;
    public AudioSource hitSound;
    public AudioSource jumpSound;
    public AudioSource deathSound;

    public static string  FIRE_SOUND = "FIRE_SOUND";
    public static string  JUMP_SOUND = "JUMP_SOUND";
    public static string  HIT_SOUND = "HIT_SOUND";
    public static string  DEATH_SOUND = "DEATH_SOUND";
    
    private void Awake() {
        SoundControllerSingleton = this;
    }

    public void playSound(string soundType){
        switch (soundType)
        {
           case "FIRE_SOUND" :
                fireSound.Play();
                break;
            case "JUMP_SOUND" :
                jumpSound.Play();
                break;
            case "HIT_SOUND" :
                hitSound.Play();
                break;
            case "DEATH_SOUND" :
                deathSound.Play();
                break;
        }
    }
}
