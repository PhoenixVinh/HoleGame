
using _Scripts.Event;
using _Scripts.ObjectPooling;
using UnityEngine;

namespace _Scripts.Hole
{
    public class HoleBottom : MonoBehaviour
    {
        private void OnTriggerEnter(Collider other)
        {
            // Check if it is the item Destroy it 
            if (other.CompareTag("Item"))
            {
                int score = other.gameObject.GetComponent<Item>().score;
                ItemEvent.OnAddScore?.Invoke(score);
                
                TextPooling.Instance.SpawnText(this.transform.position + Vector3.up*2 , score);
                Destroy(other.gameObject);
            }
            
        }
    }
}