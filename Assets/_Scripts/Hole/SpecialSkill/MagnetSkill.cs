using System;
using System.Collections.Generic;
using DG.Tweening;
using DG.Tweening.Core;
using Unity.VisualScripting;
using UnityEngine;
using Sequence = DG.Tweening.Sequence;


public struct suckecObjectParameter
{
    public Vector3 originScale;
    public bool isSuction;

    public suckecObjectParameter(Vector3 originScale, bool isSuction)
    {
        this.originScale = originScale;
        this.isSuction = isSuction;
    }

    public void SetBoolSuction(bool isSuction)
    {
        this.isSuction = isSuction; 
    }
}

public class MagnetSkill : MonoBehaviour
{
    
    
    
    public float suctionforce = 1f;
    Dictionary<GameObject, suckecObjectParameter> _suckecObjects = new Dictionary<GameObject, suckecObjectParameter>();
   
    Vector3 directionMovement = Vector3.zero;   
    
    private SphereCollider _collider;


    private void Start()
    {
        _collider = GetComponent<SphereCollider>();
    }

    private void OnTriggerStay(Collider other)
    {
        if (!_suckecObjects.ContainsKey(other.gameObject))
        {
            _suckecObjects.Add(other.gameObject, new suckecObjectParameter(other.gameObject.transform.localScale, false) );
        }
    }


    private void FixedUpdate()
    {

        float radious = _collider.radius * HoleController.Instance.GetCurrentScale();
        
        // Get radious of Circle 
        
        // Pull All Item in the list to the Hole 
        foreach (var item in _suckecObjects)
        {
            
            
            GameObject obj = item.Key;
            // Move Object to the Hole 
            if(obj == null) continue;
            float distance = Vector3.Distance(transform.position, obj.transform.position);
            if (distance > radious + 0.1f)
            {
                if (obj.transform.localScale.x < item.Value.originScale.x)
                {
                    obj.transform.localScale /= 0.98f;
                }
                continue;
            }
            
            
            if (distance < 0.1f) continue;
            // Check distance of 
            Vector3 directionMovement = transform.position - obj.transform.position;
            directionMovement.Normalize();
            
            
        
            obj.transform.Translate(directionMovement * Time.deltaTime * suctionforce);
            
            // Scale object to the Hole 
            // Check if it is scaled => Don't Scale again 
            
            
            // Scale Object
            Vector3 minSacle = item.Value.originScale / 1.5f;
            if (obj.transform.localScale.x > minSacle.x)
            {
                obj.transform.localScale *= 0.98f;
            }
            
            
        }

        
        
    }
}