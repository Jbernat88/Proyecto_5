using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameObject[] targetPrefabs;
    public bool isGameOver;
    public List<Vector3> targetPosition;

    private float minX = -3.75f;
    private float minY = -3.75f;
    private float distanceBetweenSquares = 2.5f;

    public float spawnRate;
    private Vector3 randomPos;
    private GameManager gameManagerScript;

    public TextMeshProUGUI pointText;
    private int score = 0;
    public GameObject gameOverPanel;
    public GameObject mainMenuPanel;
  
    void Start()
    {
        mainMenuPanel.SetActive(true);
       
    }

    private void OnMouseDown()
    {
        Destroy(gameObject);
        if (gameObject.CompareTag("Bad"))
        {
            gameManagerScript.isGameOver = true;
        }
    }




    private Vector3 RandomSpawnPosition()
    {
        int SaltosX = Random.Range(0, 4);
        int SaltosY = Random.Range(0, 4);

        float spawnPosX = minX + SaltosX * distanceBetweenSquares;
        float spawnPosY = minX + SaltosY * distanceBetweenSquares;

        return new Vector3(spawnPosX, spawnPosY, 0);
    }
    private IEnumerator SpawnRandomTarget()
    {
        while (!isGameOver)
        {
            yield return new WaitForSeconds(spawnRate);
            int randomIndex = Random.Range(0, targetPrefabs.Length);
            randomPos = RandomSpawnPosition();
            while (targetPosition.Contains(randomPos)) ;
            {
                randomPos = RandomSpawnPosition();
            }

            Instantiate(targetPrefabs[randomIndex], randomPos, targetPrefabs[randomIndex].transform.rotation);
            targetPosition.Add(randomPos);


            Debug.Log("AAAAAAAAAA");
        }

        
    }

    public void updateScore(int pointsToAdd)
    {
        score += pointsToAdd; //Nos actualiza la puntuación, 
        pointText.text = $"Score: {score}"; //mi puntuzción la guarda mi variable score.
    }

    public void GameOver()
    {
        isGameOver = true;
        gameOverPanel.SetActive(true);//Cuando game over sea true se instacia el panel
    }

    public void RestratGame()
    {
        SceneManager.LoadScene(0);
    }

    public void StartGame(int difficulty)
    {
        mainMenuPanel.SetActive(false);

        isGameOver = false;
        gameOverPanel.SetActive(false); //CUANDO GAME OVER ES FALSE NO ESTA ACTIVADO EL PANEL DE GAME OVER

        score = 0;
        updateScore(0);

        spawnRate = 2f;
        spawnRate /= difficulty;
       
        StartCoroutine(SpawnRandomTarget());


    }


    
}
