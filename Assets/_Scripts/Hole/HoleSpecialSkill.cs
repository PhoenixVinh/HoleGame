using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using _Scripts.Event;
using DG.Tweening;
using UnityEngine;
using UnityEngine.Serialization;

namespace _Scripts.Hole
{
    public class HoleSpecialSkill : MonoBehaviour
    {
        private bool[] IsProcessSkill = new bool[4];
        [Header("Variable Skill Increase Size")]
        public float timeSkill01 = 30f;
        
        
        [Header("Variable Skill Use Magnet")]
        public float timeSkill02 = 20f;

        public GameObject TriggerMagnet;
        

        [Header("Variable Skill Freeze Time")]
        public float timeSkill04 = 30f;
        public ParticleSystem EffectSkill02; 
        private void Start()
        {
            EffectSkill02.Stop(); 
            TriggerMagnet.SetActive(false);
            for (int i = 0; i < IsProcessSkill.Length; i++)
            {
                IsProcessSkill[i] = false;
            }
        }

        public void ProcessSkill(SpecialSkill skill)
        {
            // Check is Skill is Action => Dont use 
            if(IsProcessSkill[(int) skill]) return;
            switch (skill)
            {
                case SpecialSkill.IncreaseRange:
                    StartCoroutine(IncreaseRangeCoroutine()) ;
                    break;
                case SpecialSkill.Magnet:
                    StartCoroutine(UseMagnetCoroutine());
                    break;
                case SpecialSkill.Direction:
                    break;
                case SpecialSkill.FreezeColdown:
                    StartCoroutine(FreezeTimeCoroutine());
                    break;
            }
        }

        private IEnumerator FreezeTimeCoroutine()
        {
            TimeEvent.OnFreezeTime?.Invoke(timeSkill04);
            IsProcessSkill[3] = true;
            yield return new WaitForSeconds(timeSkill04);
            IsProcessSkill[3] = false;
        }

        private IEnumerator UseMagnetCoroutine()
        {
            IsProcessSkill[1] = true;
            float timeColdown = timeSkill02;
            
            EffectSkill02.Play();
            TriggerMagnet.SetActive(true);
            while (timeColdown > 0)
            {
                EffectSkill02.startSpeed = HoleController.Instance.GetCurrentScale() * 1.5f;
                timeColdown -= Time.deltaTime;
                yield return null;
            }
            TriggerMagnet.SetActive(false);
            EffectSkill02.Stop();
            IsProcessSkill[1] = false;
        }

        private IEnumerator IncreaseRangeCoroutine()
        {
            IsProcessSkill[0] = true;
            float scaleIncrease = transform.localScale.x *1.5f;
            var sequence = DOTween.Sequence();
            sequence.Append(transform.DOScale(new Vector3(scaleIncrease, transform.localScale.y, scaleIncrease), 1f));
            sequence.OnUpdate(
                () => { HoleController.Instance.OnUpLevelHole(); }
            );
            DOTween.Kill(sequence);
            yield return new WaitForSeconds(timeSkill01);
            
            DOTween.Kill(sequence);
            // Decease Scale 
            float scaleDecrease = transform.localScale.x /1.5f;
            
            sequence = DOTween.Sequence();
            sequence.Append(transform.DOScale(new Vector3(scaleDecrease, transform.localScale.y, scaleDecrease), 1f));
            sequence.OnUpdate(
                () => { HoleController.Instance.OnUpLevelHole(); }
            );
            IsProcessSkill[0] = false;
        }


        private void OnDrawGizmosSelected()
        {
            Gizmos.color = Color.red;
            Vector3 positionCenterOverLap = new Vector3(transform.position.x, 0, transform.position.z);
            Gizmos.DrawWireSphere(positionCenterOverLap, transform.localScale.x );
            
        }
    }
}