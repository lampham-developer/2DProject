using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManagerScript : MonoBehaviour
{

    public static AudioClip fireSound, jumpSound, hitSound, impactSound;
    public static AudioSource audioSrc;
    // Start is called before the first frame update
    void Start()
    {
        fireSound = Resources.Load<AudioClip>("fire");
        jumpSound = Resources.Load<AudioClip>("jump");
        hitSound = Resources.Load<AudioClip>("hit");
        impactSound = Resources.Load<AudioClip>("impact");

        audioSrc = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public static void playSound(string name){
        switch (name)
        {
            case "fire" :
                audioSrc.PlayOneShot(fireSound);
                break;

            case "jump" :
                audioSrc.PlayOneShot(jumpSound);
                break;

            case "hit" :
                audioSrc.PlayOneShot(hitSound);
                break;

            case "impact" :
                audioSrc.PlayOneShot(impactSound);
                break;
            
        }
    }
}
