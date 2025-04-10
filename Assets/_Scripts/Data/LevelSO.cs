using UnityEngine;

namespace _Scripts.Data
{
    [CreateAssetMenu(fileName = "Level Hole", menuName = "Data/Level Hole")]
    public class LevelSO : ScriptableObject
    {
        public int LevelID = 1;
        public int AmountExp = 3;
        public float Radious = 5f;
    }
}