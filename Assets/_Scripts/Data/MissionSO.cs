using UnityEngine;


[System.Serializable]
[CreateAssetMenu(fileName = "Mission", menuName = "Data/Mission")]
public class MissionSO : ScriptableObject
{
    public EnumItem ItemType;
    public int AmountItems;
    public Sprite image;
}

 