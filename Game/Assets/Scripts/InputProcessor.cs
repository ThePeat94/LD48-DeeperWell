using UnityEngine;

namespace WellWellWell
{
    public class InputProcessor : MonoBehaviour
    {
        private PlayerInput m_playerInput;
        private Vector2 m_movementInput;

        public Vector2 Movement => this.m_movementInput;
        public bool LeftClickTriggered => this.m_playerInput.Actions.Click.triggered;
        public bool RightClickTriggered => this.m_playerInput.Actions.RightClick.triggered;
        public Vector2 MousePosition => this.m_playerInput.Actions.MousePosition.ReadValue<Vector2>();
    
        private void Awake()
        {
            this.m_playerInput = new PlayerInput();
        }

        private void OnEnable()
        {
            this.m_playerInput?.Enable();
        }
        
        private void OnDisable()
        {
            this.m_playerInput?.Disable();
            this.m_movementInput = Vector3.zero;
        }
    }
}
