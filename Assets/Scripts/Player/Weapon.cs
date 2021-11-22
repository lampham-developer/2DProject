using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public Transform shootPoint;
    public Transform shootUpPoint;
    public GameObject sparkPrefab;

    public static bool isShootingUp = false;

    // Update is called once per frame
    void Update()
    {
        if(Input.GetButtonDown("Fire1")){
            Shoot();
        }

        if(Input.GetButtonDown("ShootUp")){
            isShootingUp = true;
        }

        if(Input.GetButtonUp("ShootUp")){
            isShootingUp = false;
        }
    }

    public void Shoot(){
        SoundController.SoundControllerSingleton.playSound(SoundController.FIRE_SOUND);
        
        if(isShootingUp) {
            Instantiate(sparkPrefab, shootUpPoint.position, shootPoint.rotation);
        }
        else{
            Instantiate(sparkPrefab, shootPoint.position, shootPoint.rotation);
        }
    }

    public void ShootUp(){
        isShootingUp = !isShootingUp;
    }
}
