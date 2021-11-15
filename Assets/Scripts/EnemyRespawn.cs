using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyRespawn : MonoBehaviour
{

    Transform spawnPoint;
    bool isCount = false;
    float timer;
    float coolDown;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if(isCount){
            timer += Time.deltaTime;
            Debug.Log(timer);
        }

        if(timer > coolDown){
                GameController.ControllerSingleton.spawnOpossum(spawnPoint);
                Destroy(gameObject);
            }
    }

    public void respawn(Transform current){
        spawnPoint = current;
        isCount = true;
        timer = Time.time;
        coolDown = Time.time + 5f;
    }
}
