using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EagleShoot : MonoBehaviour
{
    public Transform shootPoint;
    public GameObject eagleSpark;

    bool isMoving = false;
    float shootTime = 4f;
    int shootCount = 3;
    Coroutine cou;


    // Update is called once per frame
    void Update()
    {
        if(isMoving){
            if (shootTime > 0)
            {
                shootTime -= Time.deltaTime;
            }
            else
            {
                cou = StartCoroutine(Shoot());
                shootTime = 4f;
            }

            if(shootCount <= 0){
                    StopCoroutine(cou);
                    shootCount = 3;
                }
        }
    }

    IEnumerator Shoot(){

        while (shootCount > 0 && !GameController.ControllerSingleton.isGameEnded)
        {
        SoundController.SoundControllerSingleton.playSound(SoundController.EAGLE_SHOOT_SOUND);
        Instantiate(eagleSpark, shootPoint.position, shootPoint.rotation);
        yield return new WaitForSeconds(0.3f);
        shootCount--;
        }
    }

    public void startMoving(){
        isMoving = true;
    }


}
