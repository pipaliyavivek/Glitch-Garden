using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class StarDisplay : MonoBehaviour
{
    [SerializeField] int stars = 100;
    Text startext;
    void Start()
    {
        startext = GetComponent<Text>();
        UpdateDisplay();
    }
    public bool HaveEnoughStars(int amount)
    {
        return stars >= amount; 
    }
    void Update()
    {
        
    }
    private void UpdateDisplay()
    {
        startext.text = stars.ToString();
    }
    public void Addstars(int amount)
    {
        stars += amount; 
        UpdateDisplay();
    }
    public void Spendstar(int amount)
    {
        if(stars>=amount)
        {
            stars -= amount;
            UpdateDisplay();     

        }
    }
}
