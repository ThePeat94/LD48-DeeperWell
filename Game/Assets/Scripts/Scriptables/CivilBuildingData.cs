using UnityEngine;
using WellWellWell;
using WellWellWell.Util;

namespace Scriptables
{
    [CreateAssetMenu(fileName = "CivilBuildingData", menuName = "Data/CivilBuildingData", order = 0)]
    public class CivilBuildingData : BuildingData
    {
        [SerializeField] private Resource m_globalHumanResource;
        [SerializeField] private ResourceConsumption[] m_consumptionPerInhibitant;
        [SerializeField] private int m_maxInhibitants;

        public Resource GlobalHumanResource => this.m_globalHumanResource;
        public ResourceConsumption[] ConsumptionPerInhibitant => this.m_consumptionPerInhibitant;
        public int MaxInhibitants => this.m_maxInhibitants;
    }
}