using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoader : MonoBehaviour
{
    public static LevelLoader instance;
    [SerializeField] int TimeToWait = 3;
      
    int currentSceneIndex;

    private void Awake()
    {
        instance = this;
    }
    void Start()
    {
       
        currentSceneIndex = SceneManager.GetActiveScene().buildIndex;

        if(currentSceneIndex == 0)
        {
            StartCoroutine(WaitForTime());
            //LoadNextScene();

        }

    }
    public void LoadNextScene()
    {
        SceneManager.LoadScene(currentSceneIndex + 1);
    }
    public void RestartScene()
    {
        Time.timeScale = 1;  
        SceneManager.LoadScene( currentSceneIndex );
    }
    public void LoadMainMenu()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("StartScreen");

    }

    IEnumerator WaitForTime()
    {
        yield return new WaitForSeconds(TimeToWait);
        LoadNextScene();

    }

    public void LoadYouLose()
    {
        SceneManager.LoadScene("Lose Screen");
    }    
    public void QuitGame()
    {
        Application.Quit();
    }
    public void LoadOptions()
    {        
        SceneManager.LoadScene("Options Screen");
    }
}
   