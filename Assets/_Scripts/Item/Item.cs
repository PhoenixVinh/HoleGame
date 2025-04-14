using System;
using Unity.VisualScripting;
using UnityEngine;

public class Item : MonoBehaviour
{
    public int score  = 1;
    public EnumItem type = EnumItem.Apple;
        
        
    private bool _inTheHole = false;

    public bool InTheHole
    {
        get { return _inTheHole; }
        set { _inTheHole = value; }
    }

}