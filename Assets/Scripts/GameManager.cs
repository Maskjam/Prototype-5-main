using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class GameManager : MonoBehaviour
{
    public TextMeshProUGUI gameOverText;
    public List<GameObject> targets;
    private float spawnRate = 1;
    private int score;
    public TextMeshProUGUI scoreText;
     public bool isGameActive;
     public Button restartButton;
     public GameObject titleScreen;
     public int Health; 
     public TextMeshProUGUI lifeText;
     public bool pause;
     public TextMeshProUGUI pauseScreen;
    // Start is called before the first frame update
    void Start()
    {
        
    }
    
       

    IEnumerator SpawnTarget()
    {
        while (true)
        {
            yield return new WaitForSeconds(spawnRate);
            int index = Random.Range(0, targets.Count);
            Instantiate(targets[index]);
        }
    }

   public void UpdateScore(int scoreToAdd)
    {
        score += scoreToAdd;
        scoreText.text = "Score:" + score;
    }    

    public void GameOver()
    {
        gameOverText.gameObject.SetActive(true);
        isGameActive = false;
        restartButton.gameObject.SetActive(true);
    }


    // Update is called once per frame
    void Update()
    {
        if (Health == 0)
        {
            GameOver(); 
        }

        lifeText.text = "Lives: " + Health;

        //////////////////////////
        if(Input.GetKeyDown(KeyCode.Z))
        {
            if (pause == true && isGameActive == true)
            {
              PausedScreen();
            }
            else
            {
             ResumeGame();
            }
        }
        
        
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        restartButton.gameObject.SetActive(true);
    }

    public void StartGame(int difficulty)
    {
        isGameActive = true;
        score = 0;
        StartCoroutine(SpawnTarget());
        UpdateScore(0);
        spawnRate /= difficulty;
        titleScreen.gameObject.SetActive(false);
    }

    public void PausedScreen()
    {
       Time.timeScale = 0f;
       pause = false;
       pauseScreen.gameObject.SetActive(true);
    }

    public void ResumeGame()
    {
      Time.timeScale = 1f;
       pause = true;
       pauseScreen.gameObject.SetActive(false);
    }

}



    
   

