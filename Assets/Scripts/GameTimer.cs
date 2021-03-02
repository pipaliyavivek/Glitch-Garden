using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class GameTimer : MonoBehaviour
{  

    [Tooltip("Our Level Timer In SECONDS")]
    [SerializeField] float leveltime ;
    bool triggerdlevelfinished = false;
    Slider m_Slider;
    int  S_Speed = 0;


    void Start()
    {
        m_Slider = GetComponent<Slider>();
        m_Slider.maxValue = leveltime;
        
    }

    void Update()
    {
        if (triggerdlevelfinished) { return; }

        m_Slider.value = (Time.timeSinceLevelLoad / leveltime );

        bool timerFinished = Time.timeSinceLevelLoad >= leveltime;

        if(timerFinished)
        {
            Debug.Log("Has Time is Finished::--" + Time.timeSinceLevelLoad);
            LevelController.instace.levelTimerFinished();
            triggerdlevelfinished = true;         
        }

    }
}
