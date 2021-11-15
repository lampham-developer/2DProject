using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;
using System.Threading.Tasks;

public class GameController : MonoBehaviour
{
    public static GameController ControllerSingleton;

    public GameObject opossum;
    public Transform spawnPoint1;
    public Transform spawnPoint2;

    public int currentScore = 0;
	public Text scoreText;
	public Text endScoreText;
	public GameObject gamePanel;
	public GameObject gameOverMenu;
    
    bool isGameEnded = false;
    // Start is called before the first frame update

    private void Awake() {
        ControllerSingleton = this;

        currentScore = 0;
        isGameEnded = false;

        spawnOpossum(spawnPoint1);
        spawnOpossum(spawnPoint2);
    }

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void spawnOpossum(Transform spawnPoint){
        GameObject op = Instantiate(opossum, spawnPoint.position, spawnPoint.rotation);
        op.GetComponent<OpossumScript>().spawnPoint = spawnPoint;
    }

    async public void reSpawnOpossum(Transform spawnPoint){
        await Task.Delay(5000);
        if(!isGameEnded) spawnOpossum(spawnPoint);
    }

    public void addScore(int score){
		currentScore += score;
		scoreText.text = currentScore.ToString();
	}

	public async void endGame(){
        isGameEnded = true;
		await Task.Delay(1000);
		endScoreText.text = currentScore.ToString();
		gameOverMenu.SetActive(true);
		gamePanel.SetActive(false);
	}

}
