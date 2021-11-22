using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;
using System.Threading.Tasks;
using Cinemachine;
using TMPro;

public class GameController : MonoBehaviour
{
    public static GameController ControllerSingleton;

    public GameObject opossum;
    public Transform spawnPoint1;
    public Transform spawnPoint2;

    public int currentScore = 0;
	public Text scoreText;
    public Text yourScoreText;
	public Text endScoreText;
    public Text highScoreText;
    public TMP_Text endGameText;
	public GameObject gamePanel;
	public GameObject gameOverMenu;
    public GameObject gamePausePanel;

    public CinemachineVirtualCamera myCinemachine;
    public Transform bossEventPoint;
    
    public bool isGameEnded = false;
    bool isGamePaused = false;

    public UnityEvent FinalBossEvent;
    int egaleCount = 0;
    // Start is called before the first frame update

    private void Awake() {
        ControllerSingleton = this;

        gamePanel.SetActive(true);
		gameOverMenu.SetActive(false);

        currentScore = 0;
        isGameEnded = false;

        spawnOpossum(spawnPoint1);
        spawnOpossum(spawnPoint2);

        highScoreText.text = PlayerPrefs.GetInt(Constant.TEXT_HIGH_SCORE).ToString();
    }

    void Start()
    {
        if (FinalBossEvent == null)
		FinalBossEvent = new UnityEvent();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape)){
            if(isGamePaused){
                resumeGame();
            }else{
                pauseGame();
            }
        }
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

	public async void endGame(bool isDead){
        isGameEnded = true;
		await Task.Delay(1000);
        setHighScore();
		if(isDead) {endGameText.text = Constant.TEXT_GAME_OVER;}
        else {endGameText.text = Constant.TEXT_CONGRATULATION;}
        
		gameOverMenu.SetActive(true);
		gamePanel.SetActive(false);
	}

    public void changeToBossCamera(){
        myCinemachine.m_Follow = bossEventPoint;
        myCinemachine.m_Lens.OrthographicSize = 40;
    }

    void setHighScore(){
        int highScore = PlayerPrefs.GetInt(Constant.TEXT_HIGH_SCORE);
        if(currentScore > highScore){
            yourScoreText.text = Constant.TEXT_NEW_HIGH_SCORE;
            PlayerPrefs.SetInt(Constant.TEXT_HIGH_SCORE, currentScore);
            highScoreText.text = currentScore.ToString();
        }else {
            yourScoreText.text = Constant.TEXT_YOUR_SCORE;
            }

        endScoreText.text = currentScore.ToString();
    }

    public void killEagle(){
        egaleCount++;
        if(egaleCount >= 2){
            FinalBossEvent.Invoke();
        }
    }

    public void pauseGame(){
        gamePanel.SetActive(false);
        gamePausePanel.SetActive(true);
        Time.timeScale = 0;
        isGamePaused = true;
    }

    public void resumeGame(){
        gamePanel.SetActive(true);
        gamePausePanel.SetActive(false);
        Time.timeScale = 1;
        isGamePaused = false;
    }

}
