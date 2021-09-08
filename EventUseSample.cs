using System;

namespace EventReferenceTest
{
    public class EventUseSample
    {
        public event Action SampleEvent;

        public delegate void SampleDelegate();
        
        public void Execute()
        {
            SampleEvent?.Invoke();
        }

        public void ExecuteDelegate(SampleDelegate sampleDelegate)
        {
            sampleDelegate();
        }
    }
}