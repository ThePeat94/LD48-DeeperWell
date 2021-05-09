using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace WellWellWell
{
    public class HouseManager : MonoBehaviour
    {
        private static HouseManager s_instance;
        private Dictionary<Resource, List<CivilBuilding>> m_resourceBuildingMap;

        public static HouseManager Instance
        {
            get
            {
                if (s_instance == null)
                    s_instance = FindObjectOfType<HouseManager>();

                return s_instance;
            }
        }

        private void Awake()
        {
            this.m_resourceBuildingMap = new Dictionary<Resource, List<CivilBuilding>>();
        }

        public void AddBuilding(CivilBuilding toAdd)
        {
            if (!this.m_resourceBuildingMap.ContainsKey(toAdd.Data.Resource))
                this.m_resourceBuildingMap.Add(toAdd.Data.Resource, new List<CivilBuilding>());

            this.m_resourceBuildingMap[toAdd.Data.Resource].Add(toAdd);
        }

        public int GetInhabitantsForResource(Resource resource)
        {
            if (!this.m_resourceBuildingMap.ContainsKey(resource))
                return 0;

            return this.m_resourceBuildingMap[resource].Sum(c => c.CurrentInhabitants);
        }

        public void Remove(CivilBuilding toRemove)
        {
            if (!this.m_resourceBuildingMap.ContainsKey(toRemove.Data.Resource))
                return;
            this.m_resourceBuildingMap[toRemove.Data.Resource].Remove(toRemove);
        }
    }
}