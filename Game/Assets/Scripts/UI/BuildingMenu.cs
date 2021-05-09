using System;
using System.Collections.Generic;
using Scriptables;
using UnityEngine;

namespace WellWellWell.UI
{
    public class BuildingMenu : MonoBehaviour
    {
        [SerializeField] private List<BuildingData> m_availableBuildings;
        [SerializeField] private GameObject m_gridLayout;
        [SerializeField] private GameObject m_buttonPrefab;


        private void Awake()
        {
            foreach (var availableBuilding in this.m_availableBuildings)
            {
                var buildingBtn = Instantiate(this.m_buttonPrefab, this.m_gridLayout.transform).GetComponent<BuildingButton>();
                buildingBtn.Show(availableBuilding);
            }
        }
    }
}