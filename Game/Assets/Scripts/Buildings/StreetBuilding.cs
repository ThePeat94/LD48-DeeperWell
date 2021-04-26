using Scriptables;
using UnityEngine;
using WellWellWell.UI;

namespace WellWellWell
{
    public class StreetBuilding : Building
    {
        [SerializeField] private BuildingData m_buildingData;
        public BuildingData Data => this.m_buildingData;

        public override void Destruct()
        {
            Destroy(this.gameObject);
        }

        public override void ShowUI()
        {
            GameHUD.Instance.ShowStreetUI(this);
        }
    }
}