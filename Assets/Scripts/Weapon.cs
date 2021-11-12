using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public Transform shootPoint;
    public GameObject sparkPrefab;

    // Update is called once per frame
    void Update()
    {
        if(Input.GetButtonDown("Fire1")){
            Shoot();
        }
    }

    void Shoot(){
        SoundController.SoundControllerSingleton.playSound(SoundController.FIRE_SOUND);
        Instantiate(sparkPrefab, shootPoint.position, shootPoint.rotation);
    }
}
