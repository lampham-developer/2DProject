using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Elevator : MonoBehaviour
{
    public float speed = 10f;
    public int timePosition = 2;
    public Rigidbody2D rb;
    public bool goingUp = true;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Move());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator Move(){
      while(true) {
            if(goingUp){
                rb.velocity = transform.up * speed;
            }else {
                rb.velocity = transform.up * -speed;
            }
           yield return new WaitForSeconds(timePosition);
           goingUp = !goingUp;
        }
    } 
}
