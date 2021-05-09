using UnityEngine;
using WellWellWell.Util;

namespace Scriptables
{
    [CreateAssetMenu(fileName = "CivilBuildingData", menuName = "Data/CivilBuildingData", order = 0)]
    public class CivilBuildingData : BuildingData
    {
        [SerializeField] private ResourceConsumption[] m_consumptionPerInhibitant;
        [SerializeField] private int m_maxInhibitants;
        [SerializeField] private Sprite m_extraInhabitantsIcon;

        public ResourceConsumption[] ConsumptionPerInhibitant => this.m_consumptionPerInhibitant;
        public int MaxInhibitants => this.m_maxInhibitants;
        public Sprite ExtraInhabitantsIcon => this.m_extraInhabitantsIcon;
    }
}