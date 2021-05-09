namespace WellWellWell.EventArgs
{
    public class ResourceValueChangedEvent : System.EventArgs
    {
        public ResourceValueChangedEvent(float newValue)
        {
            this.NewValue = newValue;
        }

        public float NewValue { get; }
    }
}