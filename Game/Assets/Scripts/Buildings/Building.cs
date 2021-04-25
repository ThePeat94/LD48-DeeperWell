using UnityEngine;
using WellWellWell.Interface;

namespace WellWellWell
{
    public abstract class Building : MonoBehaviour, IClickable
    {
        public abstract void ShowUI();
    }
}