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
        public List<MissionSO> MissionsSO;
        
        
        public Dictionary<EnumItem, Mission> TypeItems = new Dictionary<EnumItem, Mission>();

        private void Awake()
        {
            Instance = this;
            //Genetate Data for Mission 
            CreateMissions();


        }

        private void CreateMissions()
        {
            foreach (var missionSo in MissionsSO)
            {
                GameObject mission = Instantiate(Mission, transform);
                mission.name = "Mission";
                mission.GetComponent<Mission>().SetData(missionSo);
                TypeItems[missionSo.ItemType] = mission.GetComponent<Mission>();
            }
        }


        public void CheckAddItems(EnumItem itemType)
        {
            if (!TypeItems.ContainsKey(itemType)) ;
            TypeItems[itemType].MinusItem();
        }
    }
}