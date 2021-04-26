using System;
using UnityEngine;

namespace WellWellWell
{
    public class InputProcessor : MonoBehaviour
    {
        private PlayerInput m_playerInput;
        private EventHandler m_sprintEnded;

        private EventHandler m_sprintStarted;

        public Vector2 Movement { get; private set; }

        public bool LeftClickTriggered => this.m_playerInput.Actions.Click.triggered;
        public bool RightClickTriggered => this.m_playerInput.Actions.RightClick.triggered;
        public bool RotateTriggered => this.m_playerInput.Actions.Rotate.triggered;
        public Vector2 MousePosition => this.m_playerInput.Actions.MousePosition.ReadValue<Vector2>();

        public event EventHandler SprintEnded
        {
            add => this.m_sprintEnded += value;
            remove => this.m_sprintEnded -= value;
        }

        public event EventHandler SprintStarted
        {
            add => this.m_sprintStarted += value;
            remove => this.m_sprintStarted -= value;
        }

        private void Awake()
        {
            this.m_playerInput = new PlayerInput();
            this.m_playerInput.Actions.Sprint.started += context => this.m_sprintStarted?.Invoke(this, System.EventArgs.Empty);
            this.m_playerInput.Actions.Sprint.canceled += context => this.m_sprintEnded?.Invoke(this, System.EventArgs.Empty);
        }

        private void Update()
        {
            this.Movement = this.m_playerInput.Actions.CameraMovement.ReadValue<Vector2>().normalized;
        }

        private void OnEnable()
        {
            this.m_playerInput?.Enable();
        }

        private void OnDisable()
        {
            this.m_playerInput?.Disable();
            this.Movement = Vector3.zero;
        }
    }
}