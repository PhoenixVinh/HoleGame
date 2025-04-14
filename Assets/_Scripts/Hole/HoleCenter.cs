
using System.Collections;

using UnityEngine;



public enum LayerMaskVariable
{
    Collision,
    NoCollision,
}


public class HoleCenter : MonoBehaviour
{
    [Header("   Back Hole Variables ")]
    [SerializeField] private float _backHoleGravity = 1f;
    [SerializeField] private float _timeSuction = 0.3f;
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Item"))
        {
            
            other.gameObject.layer = LayerMask.NameToLayer(LayerMaskVariable.NoCollision.ToString());
            // Item item  = other.GetComponent<Item>();
            // //Move to the center of Game Object 
            // StartCoroutine(MoveCenterCoroutine(item));
            
           // other.gameObject.layer = LayerMask.NameToLayer(LayerMaskVariable.NoCollision.ToString());
        }
    }

    private IEnumerator MoveCenterCoroutine(Item item)
    {
        item.InTheHole = true;
        float timeMove = _timeSuction;
        while (timeMove > 0)
        {
            if (item == null) break;
            Vector3 direction = this.transform.position - item.transform.position;
            direction.Normalize();
            direction.y = -1;
           
            item.transform.Translate(direction*Time.deltaTime*_backHoleGravity);
            timeMove -= Time.deltaTime;
            yield return null;
        }



        if (item.InTheHole)
        {
            item.gameObject.layer = LayerMask.NameToLayer(LayerMaskVariable.NoCollision.ToString());
        }
 
        
        
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Item"))
        {
            other.gameObject.layer = LayerMask.NameToLayer(LayerMaskVariable.Collision.ToString());
            //other.gameObject.GetComponent<Item>().InTheHole = false;
        }
    }
}