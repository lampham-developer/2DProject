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
        if(Weapon.isShootingUp){
            if(PlayerMovementScript.PlayerMovementSingleton.horizontalMove != 0){
                rb.velocity = transform.up * sparkSpeed + transform.right * sparkSpeed;
                transform.Rotate(0f, 0f, 45f);
            }else{
                rb.velocity = transform.up * sparkSpeed;
                transform.Rotate(0f, 0f, 90f);
            }
            
        }else{
            rb.velocity = transform.right * sparkSpeed;
        }
        
    }

    private void OnBecameInvisible() {
        Destroy(gameObject);
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

            EagleScript eagle = hitInfo.transform.GetComponent<EagleScript>();
			if (eagle != null)
			{
                SoundController.SoundControllerSingleton.playSound(SoundController.HIT_SOUND);
				eagle.TakeDamage(damage);
			}
        }
        
        GameObject impact = Instantiate(sparkImpact, transform.position, transform.rotation);
        Destroy(impact, 0.2f);
	}

}
