using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpossumScript : MonoBehaviour
{

    public int health = 20;
    public GameObject deathEffect;
    public float speed = 10f;
    public int timePosition = 2;
    public Rigidbody2D rb;
    public bool goingLeft = true;
    public AudioSource impactSound;
    public GameObject character;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Move());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void TakeDamage(int damage){
        health -= damage;

        if (health <= 0)
		{
            character.GetComponent<CharacterController2D>().addScore(10);
			Die();
		}
    }

    void Die(){
        impactSound.Play();
        GameObject effect = Instantiate(deathEffect, transform.position, Quaternion.identity);
		Destroy(gameObject);
        Destroy(effect, 0.4f);
    }

    IEnumerator Move(){
      while(true) {
            
            if(goingLeft){
                rb.velocity = transform.right * -speed;
                transform.localScale = new Vector3(-15f,15f,1f);
            }else{
                rb.velocity = transform.right * speed;
                transform.localScale = new Vector3(15f,15f,1f);
            }

           yield return new WaitForSeconds(timePosition);
           goingLeft = !goingLeft;
        }
    } 

    void OnTriggerEnter2D (Collider2D hitInfo)
	{
        Debug.Log(hitInfo.name);
        if(hitInfo){
            CharacterController2D player = hitInfo.transform.GetComponent<CharacterController2D>();
			if (player != null)
			{
				player.Die();
			}
        }  
	}
}
