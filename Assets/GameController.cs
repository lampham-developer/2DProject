using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public GameObject opossum;
    public Transform spawnPoint1;
    public Transform spawnPoint2;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void spawnOpossum(Transform spawnPoint){
        Instantiate(opossum, spawnPoint.position, spawnPoint1.rotation);
    }
}
