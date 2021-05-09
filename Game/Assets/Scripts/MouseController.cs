using System.Linq;
using Scriptables;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;
using WellWellWell.Interface;

namespace WellWellWell
{
    public class MouseController : MonoBehaviour
    {
        public enum MouseState
        {
            NORMAL,
            BUILDING
        }

        private static MouseController s_instance;

        [SerializeField] private InputProcessor m_inputProcessor;
        [SerializeField] private LayerMask m_constructionLayers;
        [SerializeField] private LayerMask m_selectionLayer;

        private BuildingData m_currentBuildingToPlace;
        private float m_currentRotation;
        private MouseState m_currentState;
        private PreviewBuilding m_previewBuilding;

        public static MouseController Instance
        {
            get
            {
                if (s_instance == null)
                    s_instance = FindObjectOfType<MouseController>();

                return s_instance;
            }
        }


        private void Awake()
        {
            if (s_instance == null)
            {
                s_instance = this;
            }
            else
            {
                Destroy(this);
                return;
            }

            this.m_currentState = MouseState.NORMAL;
        }

        private void Update()
        {
            if (this.m_inputProcessor.RightClickTriggered && this.m_currentState == MouseState.BUILDING)
            {
                this.StopBuilding();
                return;
            }

            if (this.m_currentState == MouseState.BUILDING)
                if (this.m_previewBuilding != null)
                {
                    if (this.m_inputProcessor.RotateTriggered)
                    {
                        this.m_currentRotation += 90f;
                        this.m_previewBuilding.transform.Rotate(Vector3.up, 90f);
                    }

                    this.UpdatePreviewPosition();

                    var resourceCosts = this.m_currentBuildingToPlace.Costs;
                    var canBeBuilt = resourceCosts.All(c => c.Type.ResourceController.CanAfford(c.Cost));
                    if (this.m_currentBuildingToPlace.GetType() == typeof(ProductionBuildingData))
                    {
                        var productionBuildingData = this.m_currentBuildingToPlace as ProductionBuildingData;
                        var canAffordWorkforce = productionBuildingData.WorkforceConsumption.HumanResource.ResourceController.CanAfford(productionBuildingData.WorkforceConsumption.Amount);
                        canBeBuilt = canAffordWorkforce && canBeBuilt;
                    }

                    if (canBeBuilt)
                        this.m_previewBuilding.TurnAvailable();
                    else
                        this.m_previewBuilding.TurnUnavailable();

                    if (this.m_inputProcessor.LeftClickTriggered && !this.m_previewBuilding.HitObstacles)
                    {
                        if (EventSystem.current.IsPointerOverGameObject())
                            return;

                        if (!canBeBuilt)
                            return;

                        this.PlaceCurrentBuilding();
                        return;
                    }
                }

            if (this.m_inputProcessor.LeftClickTriggered && this.m_currentState == MouseState.NORMAL)
            {
                if (EventSystem.current.IsPointerOverGameObject())
                    return;

                var ray = Camera.main.ScreenPointToRay(Mouse.current.position.ReadValue());
                if (Physics.Raycast(ray, out var hit, Mathf.Infinity, this.m_selectionLayer))
                    hit.collider.GetComponent<IClickable>().ShowUI();
            }
        }

        public void StartBuilding(BuildingData toBuild)
        {
            if (this.m_currentBuildingToPlace != null)
                this.StopBuilding();

            this.m_currentState = MouseState.BUILDING;
            this.m_currentBuildingToPlace = toBuild;
            this.CreatePreview();
        }

        private void CreatePreview()
        {
            var pos = Vector3.negativeInfinity;
            var ray = Camera.main.ScreenPointToRay(Mouse.current.position.ReadValue());
            if (Physics.Raycast(ray, out var hit, Mathf.Infinity, this.m_constructionLayers))
                pos = this.GetGridPos(hit.point);

            this.m_previewBuilding = Instantiate(this.m_currentBuildingToPlace.ToPlace, pos, Quaternion.identity).GetComponent<PreviewBuilding>();
            this.m_previewBuilding.enabled = true;
            this.m_previewBuilding.name += "(Preview)";
        }

        private Vector3Int GetGridPos(Vector3 pos)
        {
            return new Vector3Int(Mathf.FloorToInt(pos.x), 0, Mathf.CeilToInt(pos.z));
        }

        private void PlaceCurrentBuilding()
        {
            var ray = Camera.main.ScreenPointToRay(Mouse.current.position.ReadValue());
            if (Physics.Raycast(ray, out var hit, Mathf.Infinity, this.m_constructionLayers))
            {
                foreach (var buildingCost in this.m_currentBuildingToPlace.Costs)
                    buildingCost.Type.ResourceController.TryUseResource(buildingCost.Cost);

                if (this.m_currentBuildingToPlace.GetType() == typeof(ProductionBuildingData))
                {
                    var productionBuildingData = this.m_currentBuildingToPlace as ProductionBuildingData;
                    productionBuildingData.WorkforceConsumption.HumanResource.ResourceController.TryUseResource(productionBuildingData.WorkforceConsumption.Amount);
                }

                var gridPos = this.GetGridPos(hit.point);
                var go = Instantiate(this.m_currentBuildingToPlace.ToPlace, gridPos, Quaternion.identity);
                Destroy(go.GetComponent<PreviewBuilding>());
                go.GetComponent<Building>().enabled = true;
                go.transform.Rotate(Vector3.up, this.m_currentRotation);
                this.StopBuilding();
            }
        }

        private void StopBuilding()
        {
            this.m_currentBuildingToPlace = null;
            this.m_currentState = MouseState.NORMAL;
            Destroy(this.m_previewBuilding.gameObject);
            this.m_previewBuilding = null;
            this.m_currentRotation = 0f;
        }

        private void UpdatePreviewPosition()
        {
            var ray = Camera.main.ScreenPointToRay(Mouse.current.position.ReadValue());
            if (Physics.Raycast(ray, out var hit, Mathf.Infinity, this.m_constructionLayers))
            {
                var gridPos = this.GetGridPos(hit.point);
                this.m_previewBuilding.transform.position = gridPos;
            }
        }
    }
}