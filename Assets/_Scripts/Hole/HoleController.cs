using System;
using System.Collections;
using System.Collections.Generic;
using _Scripts.Hole;
using Unity.VisualScripting;
using UnityEngine;

public class HoleController : MonoBehaviour
{
    public static HoleController Instance;
    
    
    
    
    
    [Header("Variables")]
    public float _speedMovement;
    public float _radious;


    
    
    private HoleMovement _holeMovement;
    public HoleMovement HoleMovement => _holeMovement;

    public BlackHole _blackHole;


    private HoleLevel _holeLevel;
    public HoleLevel HoleLevel => _holeLevel;
    
    private void Awake()
    {
        Instance = this;
        _holeMovement = GetComponent<HoleMovement>();
        _blackHole = GetComponent<BlackHole>();
        _holeLevel = GetComponent<HoleLevel>();
        SetData();
    }

    

    private void SetData()
    {
        _holeMovement.SetSpeedMovement(_speedMovement);
    }


    public void OnUpLevelHole()
    {
        this._blackHole.changeInitialScale(this.transform.localScale.x);
    }


    public void LoadLevel(int amountExp, float radius)
    {
        Vector3 localScale = transform.localScale;
        Vector3 newScale = new Vector3(radius, localScale.y, radius);
        // Update Scale of Hole 
        this.transform.localScale = newScale;
        this._blackHole.changeInitialScale(this.transform.localScale.x);
        this._holeLevel.SetData(amountExp);
    }
    
    
    
    
}
