using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spark : MonoBehaviour
{
    public float sparkSpeed = 300f;
    public Rigidbody2D rb;
    public GameObject sparkImpact;
    public int damage = 10;

    void Start()
    {
        rb.velocity = transform.right * sparkSpeed;
    }

    void OnTriggerEnter2D (Collider2D hitInfo)
	{

        Destroy(gameObject);
        if(hitInfo){
            OpossumScript opossum = hitInfo.transform.GetComponent<OpossumScript>();
			if (opossum != null)
			{
                SoundController.SoundControllerSingleton.playSound(SoundController.HIT_SOUND);
				opossum.TakeDamage(damage);
			}
        }
        
        GameObject impact = Instantiate(sparkImpact, transform.position, transform.rotation);
        Destroy(impact, 0.2f);
	}

}
