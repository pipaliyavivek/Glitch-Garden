using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class DiffenderButton : MonoBehaviour
{
    [SerializeField] Defender difenderprefab;
    private void Start()
    {
        LabelButtonWithCost();
    }

    private void LabelButtonWithCost()
    {
        Text costText = GetComponentInChildren<Text>();
        if(!costText)
        {
          //  Debug.LogError(name+"Has No CostText Add Some!");
        }
        else
        {
            costText.text = difenderprefab.GetStarCost().ToString();
        }
    }

    private void OnMouseDown()
    {
        var buttons = FindObjectsOfType<DiffenderButton>();
        foreach(DiffenderButton button in buttons)
        {
            button.GetComponent<SpriteRenderer>().color = new Color32(41, 41, 41, 255);
        }

        GetComponent<SpriteRenderer>().color = Color.white;
        FindObjectOfType<DefenderSpwaner>().SetSelectedDefender(difenderprefab);   
    }
}
