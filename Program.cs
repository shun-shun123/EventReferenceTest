using System;

namespace EventReferenceTest
{
    class Program
    {
        private static void Main(string[] args)
        {
            var program = new Program();
            program.Execute();
        }
        
        private static void SayHello()
        {
            Console.WriteLine($"Program.SayHello");
        }

        private void Execute()
        {
            var eventSample = new EventUseSample();
            var behaviour = new Behaviour();
            
            eventSample.SampleEvent += SayHello;
            eventSample.SampleEvent += behaviour.SayHello;
            eventSample.SampleEvent += () => Console.WriteLine("Lambda.SayHello");
            eventSample.SampleEvent += () => SayHello();
            eventSample.SampleEvent += () => behaviour.SayHello();
            Action lambda = () => Console.WriteLine("Cached.Lambda.SayHello");
            Action staticLambda = () => SayHello();
            Action instanceLambda = () => behaviour.SayHello();
            eventSample.SampleEvent += lambda;
            eventSample.SampleEvent += staticLambda;
            eventSample.SampleEvent += instanceLambda;

            lambda = null;
            staticLambda = null;
            instanceLambda = null;
            
            eventSample.SampleEvent -= SayHello;
            eventSample.SampleEvent -= behaviour.SayHello;
            eventSample.SampleEvent -= () => Console.WriteLine("Lambda.SayHello");
            eventSample.SampleEvent -= () => SayHello();
            eventSample.SampleEvent -= () => behaviour.SayHello();
            eventSample.SampleEvent -= lambda;
            eventSample.SampleEvent -= staticLambda;
            eventSample.SampleEvent -= instanceLambda;
            
            eventSample.Execute();
        }
    }

    class Behaviour
    {
        public void SayHello()
        {
            Console.WriteLine("Behaviour.SayHello");
        }
    }
}
