using System;
using System.Collections.Generic;
using _Scripts.Data;
using Unity.VisualScripting;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    // it can load by recouses
    public  List<LevelSO> levels;

    public int currentLevel = 0;
    public void Start()
    {
        //Set Data for hole 
        HoleController.Instance.LoadLevel(levels[currentLevel].AmountExp, levels[currentLevel].Radious);
    }

    private void OnEnable()
    {
        HoleEvent.OnLevelUp += OnLevelup;
    }

    private void OnLevelup()
    {
        currentLevel++;
        if (currentLevel < levels.Count)
        {
            HoleController.Instance.LoadLevel(levels[currentLevel].AmountExp, levels[currentLevel].Radious);
        }
        else
        {
            Debug.Log("No more levels");
        }
       
    }

    private void OnDisable()
    {
        HoleEvent.OnLevelUp -= OnLevelup;
    }
    
    
    
    
    
    
}