using System;
using System.Collections.Generic;
using _Scripts.Event;
using UnityEngine;

namespace _Scripts.UI.MissionUI
{
    public class ManagerMission : MonoBehaviour
    {
        public static ManagerMission Instance;
        
        
        public GameObject Mission;
        
        // Misition For One Level => Get next level using Addressable
        public MissionSO MissionsSO;
        
        
        public Dictionary<EnumItem, Mission> TypeItems = new Dictionary<EnumItem, Mission>();

        private void Awake()
        {
            Instance = this;
            //Genetate Data for Mission 
            CreateMissions();


        }

        private void CreateMissions()
        {
            foreach (var missionSo in MissionsSO.misstionsData)
            {
                GameObject mission = Instantiate(Mission, transform);
                mission.name = "Mission";
                mission.GetComponent<Mission>().SetData(missionSo);
                TypeItems[missionSo.ItemType] = mission.GetComponent<Mission>();
            }
        }


        public void CheckMinusItems(EnumItem itemType, Vector3 position)
        {
            if (!TypeItems.ContainsKey(itemType)) return; ;
            TypeItems[itemType].MinusItem(position);
        }
    }
}