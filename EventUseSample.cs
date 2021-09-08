using System;

namespace EventReferenceTest
{
    public class EventUseSample
    {
        public event Action SampleEvent;
        
        public void Execute()
        {
            SampleEvent?.Invoke();
        }
    }
}