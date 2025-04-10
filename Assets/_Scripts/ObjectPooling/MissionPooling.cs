using _Scripts.UI.MissionUI;
using UnityEngine;
using UnityEngine.UIElements;

namespace _Scripts.ObjectPooling
{
    public class MissionPooling : ObjectPoolingBase<MissionPooling>
    {
        public GameObject spawnImage(Sprite sprite)
        {
            GameObject obj = this.GetPooledObject();
            obj.GetComponent<Image>().sprite = sprite;
            return obj;
        }
        
    }
}