using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class LevelController : MonoBehaviour
{
    [SerializeField] GameObject winlebal;
    [SerializeField] GameObject Loselebal;

    [SerializeField] float  WaitToLoad = 2f;
    public static LevelController instace;
    [HideInInspector ]
   public  int NumberOfAttacker = 0; 
    
  public  bool LevelTimerFinished = false;
    private void Start()
    {
      
        instace = this;
        winlebal.SetActive(false);
        Loselebal.SetActive(false);

    }
    // Start is called before the first frame update
    public void AttackerSpawned()
    {
        NumberOfAttacker++;
        Debug.Log("Number Of Attacker Spawner::" + NumberOfAttacker);
    }
    public void AttackerKilled()
    { 
        NumberOfAttacker--;
        if(NumberOfAttacker <= 0  && LevelTimerFinished)
        {
            Debug.Log("You Win!!");
            StartCoroutine(HandleWinCondition());
        }
    }
    IEnumerator HandleWinCondition()
    {
        winlebal.SetActive(true);
        GetComponent<AudioSource>().Play();
        yield return new WaitForSeconds(WaitToLoad);
        FindObjectOfType<LevelLoader>().LoadNextScene();
      //  LevelLoader.instance.LoadNextScene(); 
    }

    public void levelTimerFinished()
    {
        LevelTimerFinished = true;
        StopSpawner();
        //if (LivesDisplay.instance.lives >= 0) 
        //{
        //    StartCoroutine(HandleWinCondition());
        //}
        //else
        //{
        //    handleLoseCondition();
        //}
    }
    public void handleLoseCondition()
    {
            //if (!Loselebal) return;           
            Loselebal.SetActive(true);
            Time.timeScale = 0;
        
    }
    private void StopSpawner()
    {
        AttackerSpwner[] spawnerArray = FindObjectsOfType<AttackerSpwner>();
        foreach (AttackerSpwner spawner in spawnerArray)
        {
            spawner.StopSpawing();
        }
    }
}

