using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EagleSpark : MonoBehaviour
{
    float sparkSpeed = 30f;
    public Rigidbody2D rb;
    public GameObject sparkImpact;
    Vector3 newVector;

    void Start()
    {
        newVector = CharacterController2D.characterController.m_Rigidbody2D.position - rb.position;
        rb.velocity = newVector / newVector.magnitude * sparkSpeed;
        transform.rotation = GetRotationTo();
        
    }

Quaternion GetRotationTo()
{
    float angle = Mathf.Atan2(newVector.y, newVector.x) * Mathf.Rad2Deg;
    return Quaternion.AngleAxis(angle, Vector3.forward);
}

    void OnTriggerEnter2D (Collider2D hitInfo)
	{
        EagleSpark spark = hitInfo.transform.GetComponent<EagleSpark>();
        if(spark != null) return;

        BossMovementScript boss = hitInfo.transform.GetComponent<BossMovementScript>();
        if(boss != null) return;

        Destroy(gameObject);
        
        CharacterController2D player = hitInfo.transform.GetComponent<CharacterController2D>();
			if (player != null)
			{
				player.Die();
			}
        
        GameObject impact = Instantiate(sparkImpact, transform.position, transform.rotation);
        impact.transform.localScale += new Vector3(5f,5f,0);
        Destroy(impact, 0.2f);
	}
}
