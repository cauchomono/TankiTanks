using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] Button startButton;
    [SerializeField] Button restartButton;
    public Text titleText;
    public Text gameoverText;
    public bool isGameActive;
    public Camera initialCamera;
    public Camera gameCamera;


    void Start()
    {
        startButton.onClick.AddListener(StartGame);
        restartButton.onClick.AddListener(RestartGame);
    }

    // Update is called once per frame
   

   public void StartGame()
    {
        isGameActive = true;
        titleText.gameObject.SetActive(false);
        startButton.gameObject.SetActive(false);
        restartButton.gameObject.SetActive(false);
        initialCamera.gameObject.SetActive(false);
        gameCamera.gameObject.SetActive(true);


    }

    public void GameOver()
    {
        isGameActive = false;
        gameoverText.gameObject.SetActive(true);
        restartButton.gameObject.SetActive(true);
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
