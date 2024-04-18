using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ObserverDesignPatternExample2
{
    public class Subject : ISubject
    {
        public int State { get; set; }

        private List<IObserver> _observers = new List<IObserver>();
        public void Attach(IObserver observer)
        {
            Console.WriteLine("Subject : Attached an observer");
            _observers.Add(observer);
        }

        public void Detach(IObserver observer)
        {
            Console.WriteLine("Subject : Detached an observer");
            _observers.Remove(observer);
        }

        public void Notify()
        {
            Console.WriteLine("Notifying Observers...");

            foreach (var item in _observers)
            {
                item.Update(this);
            }
        }
        public void SomeBusinessLogic()
        {
            this.State = new Random().Next(0, 10);

            Thread.Sleep(15);

            Console.WriteLine("State is changed");

            this.Notify();
        }
    }
}
