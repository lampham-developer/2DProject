using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading.Tasks;

public class OpossumScript : MonoBehaviour
{

    public int health = 20;
    public GameObject deathEffect;
    public float speed = 10f;
    public int timePosition = 2;
    public Rigidbody2D rb;
    public bool goingLeft = true;
    public Transform spawnPoint;

    public HealthBarScript healthBar;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Move());
        healthBar.setHealthBar(health);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void TakeDamage(int damage){
        health -= damage;
        healthBar.setHealth(health);

        if (health <= 0)
		{
            GameController.ControllerSingleton.addScore(10);
			Die();
		}
    }

    async void Die(){
        GameController.ControllerSingleton.reSpawnOpossum(spawnPoint);
        GameObject effect = Instantiate(deathEffect, transform.position, Quaternion.identity);
		Destroy(gameObject);
        Destroy(effect, 0.4f);
        await Task.Delay(200);
        SoundController.SoundControllerSingleton.playSound(SoundController.DEATH_SOUND);
    }

    IEnumerator Move(){
      while(true) {
            
            if(goingLeft){
                rb.velocity = transform.right * -speed;
                transform.localScale = new Vector3(15f,15f,1f);
            }else{
                rb.velocity = transform.right * speed;
                transform.localScale = new Vector3(-15f,15f,1f);
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
}
