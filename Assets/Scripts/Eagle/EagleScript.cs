using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading.Tasks;

public class EagleScript : MonoBehaviour
{
    float health = 100;
    public GameObject deathEffect;
    public float speed = 20f; 
    public int timePosition = 4;
    public Rigidbody2D rb;
    public bool goingLeft = true;
    bool isMoving = false;
    bool canHit = false;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void TakeDamage(float damage){
        if(canHit){
            health -= damage;
            if (health <= 0)
		    {
                GameController.ControllerSingleton.addScore(200);
                GameController.ControllerSingleton.killEagle();
			    Die();
		    }
        }
    }

    async void Die(){
        GameObject effect = Instantiate(deathEffect, transform.position, Quaternion.identity);
		Destroy(gameObject);
        Destroy(effect, 0.4f);
        await Task.Delay(200);
        SoundController.SoundControllerSingleton.playSound(SoundController.DEATH_SOUND);
    }

    IEnumerator Move(){
      while(isMoving) {
                if(goingLeft){
                    rb.velocity = transform.right * -speed;
                    transform.localScale = new Vector3(20f,20f,1f);
                }else{
                    rb.velocity = transform.right * speed;
                    transform.localScale = new Vector3(-20f,20f,1f);
                }

                yield return new WaitForSeconds(timePosition);
                goingLeft = !goingLeft;
        }
    } 

    void OnTriggerEnter2D (Collider2D hitInfo)
	{
        if(hitInfo){
            CharacterController2D player = hitInfo.transform.GetComponent<CharacterController2D>();
			if (player != null)
			{
				player.Die();
			}
        }  
	}

    public void startMoving(){
        canHit = true;
        isMoving = true;
        StartCoroutine(Move());
    }
}
