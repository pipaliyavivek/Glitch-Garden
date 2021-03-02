using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class LivesDisplay: MonoBehaviour
{
    [SerializeField] float baseLives = 10;
    [SerializeField] int damage = 1;

    [HideInInspector]
    public  float  lives;
    Text liveText;

    public static  LivesDisplay instance;
    private void Awake()
    {
        instance = this;
    }
    void Start()
    {
       
        lives =(baseLives - PlayerPrefController.GetDifficulty());
        liveText  = GetComponent<Text>();
        UpdateDisplay();
        //Debug.Log("Get Your Difficulty" + PlayerPrefController.GetDifficulty());
    }
    private void UpdateDisplay()
    {
        liveText.text = lives.ToString();
    }

    public void TakeLife()
    {
            lives -= damage;
            UpdateDisplay();
            //Debug.Log(lives -= damage);
        
        if (lives == 0 || lives<=0)
        {
             LevelController.instace.handleLoseCondition();
             //FindObjectOfType<LevelLoader>().LoadYouLose();
        }

    }
}
