using System;
using System.Collections;
using _Scripts.ObjectPooling;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace _Scripts.UI.MissionUI
{
    public class Mission : MonoBehaviour
    {
        
        public int amountItem;
        public EnumItem itemType;
        
        private TMP_Text _text;
        private Image image;


        private void Start()
        {
            _text = GetComponentInChildren<TMP_Text>();
            image = transform.Find("Image").GetComponent<Image>();
        }


        public void SetData(MissionSO missionSo)
        {
            this.amountItem = missionSo.AmountItems;
            _text.text = this.amountItem.ToString();
            image.sprite = missionSo.image;    
        }

        public void MinusItem(Vector3 positionMinus)
        {
            StartCoroutine(AddItemCoroutine(positionMinus));
        }

        private IEnumerator AddItemCoroutine(Vector3 positionMinus)
        {
            amountItem--;
            
            
            GameObject EffectMission = MissionPooling.Instance.spawnImage(image.sprite);
            EffectMission.transform.position = 
            
            
            
            
            yield return new WaitForSeconds(0.2f);
            // Add Pooling to create Image for it 
            
            
            
        }
    }
}