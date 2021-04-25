using System.Linq;
using Scriptables;
using UnityEngine;
using UnityEngine.InputSystem;
using WellWellWell.Interface;

namespace WellWellWell
{
    public class MouseController : MonoBehaviour
    {
        public enum MouseState { NORMAL, BUILDING }

        [SerializeField] private InputProcessor m_inputProcessor;
        [SerializeField] private LayerMask m_constructionLayers;
        [SerializeField] private LayerMask m_selectionLayer;
        
        private MouseState m_currentState;
        private BuildingData m_currentBuildingToPlace;
        private Grid m_worldGrid;

        private PreviewBuilding m_previewBuilding;

        private static MouseController s_instance;

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
                s_instance = this;
            else
            {
                Destroy(this);
                return;
            }
            
            this.m_currentState = MouseState.NORMAL;
            this.m_worldGrid = FindObjectOfType<Grid>();
        }

        private void Update()
        {
            if (this.m_inputProcessor.RightClickTriggered && this.m_currentState == MouseState.BUILDING)
            {
                this.StopBuilding();
                return;
            }

            if (this.m_currentState == MouseState.BUILDING && this.m_previewBuilding != null)
            {
                this.UpdatePreviewPosition();
                var resourceCosts = this.m_currentBuildingToPlace.Costs;
                var canBeBuilt = resourceCosts.All(c => c.Type.ResourceController.CanAfford(c.Cost));
                if (canBeBuilt)
                    this.m_previewBuilding.TurnAvailable();
                else
                    this.m_previewBuilding.TurnUnavailable();
            }

            if (this.m_inputProcessor.LeftClickTriggered && this.m_currentState == MouseState.BUILDING && this.m_currentBuildingToPlace != null && !this.m_previewBuilding.HitObstacles)
            {
                var resourceCosts = this.m_currentBuildingToPlace.Costs;
                var canBeBuilt = resourceCosts.All(c => c.Type.ResourceController.CanAfford(c.Cost));
                if (!canBeBuilt)
                    return;

                this.PlaceCurrentBuilding();
                return;
            }

            if (this.m_inputProcessor.LeftClickTriggered && this.m_currentState == MouseState.NORMAL)
            {
                var ray = Camera.main.ScreenPointToRay(Mouse.current.position.ReadValue());
                if (Physics.Raycast(ray, out var hit, Mathf.Infinity, this.m_selectionLayer))
                {
                    Debug.Log("Show UI for building");
                    hit.collider.GetComponent<IClickable>().ShowUI();
                }
            }
        }

        public void StartBuilding(BuildingData toBuild)
        {
            if (this.m_currentBuildingToPlace != null)
            {
                this.StopBuilding();
            }
            
            this.m_currentState = MouseState.BUILDING;
            this.m_currentBuildingToPlace = toBuild;
            this.CreatePreview();
        }

        private void CreatePreview()
        {
            var pos = Vector3.negativeInfinity;
            var ray = Camera.main.ScreenPointToRay(Mouse.current.position.ReadValue());
            if (Physics.Raycast(ray, out var hit, Mathf.Infinity, this.m_constructionLayers))
            {
                pos = this.GetGridPos(hit.point);
            }

            this.m_previewBuilding = Instantiate(this.m_currentBuildingToPlace.ToPlace, pos, Quaternion.identity).GetComponent<PreviewBuilding>();
            this.m_previewBuilding.enabled = true;
            this.m_previewBuilding.name += "(Preview)";
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

        private void StopBuilding()
        {
            this.m_currentBuildingToPlace = null;
            this.m_currentState = MouseState.NORMAL;
            Destroy(this.m_previewBuilding.gameObject);
            this.m_previewBuilding = null;
        }

        private void PlaceCurrentBuilding()
        {
            var ray = Camera.main.ScreenPointToRay(Mouse.current.position.ReadValue());
            if (Physics.Raycast(ray, out var hit, Mathf.Infinity, this.m_constructionLayers))
            {
                foreach (var buildingCost in this.m_currentBuildingToPlace.Costs)
                {
                    buildingCost.Type.ResourceController.TryUseResource(buildingCost.Cost);
                }
                var gridPos = this.GetGridPos(hit.point);
                var go = Instantiate(this.m_currentBuildingToPlace.ToPlace, gridPos, Quaternion.identity);
                Destroy(go.GetComponent<PreviewBuilding>());
                go.GetComponent<Building>().enabled = true;
                this.StopBuilding();
            }
        }

        private Vector3Int GetGridPos(Vector3 pos)
        {
            return new Vector3Int(Mathf.FloorToInt(pos.x), 0, Mathf.CeilToInt(pos.z));
        }
    }
}