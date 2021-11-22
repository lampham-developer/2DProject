using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading.Tasks;

public class BossMovementScript : MonoBehaviour
{

    public Transform player;
    public Rigidbody2D rb;
    public Animator animator;
    public HealthBarScript healthBar;
    public GameObject deathEffect;

    float speed = 10f;
    float attackRange = 10f;
    float health = 1000;
    float speedUpHealth = 1000;
    float speedUpStep = 100;

	bool isFlipped = false;
    bool isMoving = false;
    bool canHit = false;

    // Start is called before the first frame update
    void Start()
    {
        speedUpHealth -= speedUpStep;
    }

    // Update is called once per frame
    void Update()
    {
        animator.SetBool("isMoving", isMoving && !GameController.ControllerSingleton.isGameEnded);

        if(isMoving && !GameController.ControllerSingleton.isGameEnded){
            move();
        }

        if(GameController.ControllerSingleton.isGameEnded){
            rb.velocity = new Vector2(0f,0f);
        }
    }

	public void LookAtPlayer()
	{
		Vector3 flipped = transform.localScale;
		flipped.z *= -1f;

		if (transform.position.x > player.position.x && isFlipped)
		{
			transform.localScale = flipped;
			transform.Rotate(0f, 180f, 0f);
			isFlipped = false;
		}
		else if (transform.position.x < player.position.x && !isFlipped)
		{
			transform.localScale = flipped;
			transform.Rotate(0f, 180f, 0f);
			isFlipped = true;
		}
	}

    public void startMoving(){
        canHit = true;
        isMoving = true;
        healthBar.setHealthBar(health);
    }

    void move(){
        LookAtPlayer();
        //Vector3 newVector = player.position - rb.position;

        Vector2 newVector = new Vector2(player.position.x - transform.position.x, 0);
		// Vector2 newPos = Vector2.MoveTowards(rb.position, target, speed * Time.fixedDeltaTime);
		// rb.MovePosition(newPos);
        rb.velocity = newVector / newVector.magnitude * speed;

		if (Vector2.Distance(player.position, rb.position) <= attackRange)
		{
			animator.SetTrigger("Attack");
		}
    }

    public void TakeDamage(float damage){
        if(canHit){
            health -= damage;
            healthBar.setHealth(health);
            if (health <= 0)
		    {
                GameController.ControllerSingleton.addScore(10000);
			    Die();
		    }else{
                if(health <= speedUpHealth){
                    speedUpHealth -= speedUpStep;
                    speed = speed * 1.1f;
                }
            }

            
        }
    }

    async void Die(){
        GameObject effect = Instantiate(deathEffect, transform.position, Quaternion.identity);
		Destroy(gameObject);
        Destroy(effect, 0.4f);
        await Task.Delay(200);
        SoundController.SoundControllerSingleton.playSound(SoundController.DEATH_SOUND);
        GameController.ControllerSingleton.endGame(false);
    }
}
