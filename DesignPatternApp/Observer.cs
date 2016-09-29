using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatternApp
{
    /// <summary>
    /// This is an interface which attached and detached observers and
    /// notify it's observers when state changes.
    /// </summary>
    public interface Isubject
    {
        void Attach(IObserver observer);
        void Dettach(IObserver observer);
        void Notify();
    }

    public interface IObserver
    {
        void NotifyPartPurchased();
    }

    /// <summary>
    /// This class Implement ISubject interface and provide implementation to attach/dettach observers
    /// When inventory state value updated notify this change to all its registered observers.
    /// </summary>
    public class PartSubject : Isubject
    {
        List<IObserver> observers = new List<IObserver>();
        private int _partStock;
        public int PartStock
        {
            get { return _partStock; } 
            set
            {
                if(value > _partStock)
                {
                    Notify();
                }
                _partStock = value;
            }
        }
        public void Attach(IObserver observer)
        {
            observers.Add(observer);
        }

        public void Dettach(IObserver observer)
        {
            observers.Remove(observer);
        }

        public void Notify()
        {
            //Notify to observers that value of part stock has been changed.
            observers.ForEach(p => p.NotifyPartPurchased());
        }
    }

    /// <summary>
    /// This class get notified when part stock has been updated
    /// </summary>
    public class PartObserver : IObserver
    {
        public string Name = string.Empty;

        public PartObserver(string name)
        {
            Name = name;
        }
        public void NotifyPartPurchased()
        {
            Console.WriteLine("Hey {0}, New Part has been purchased", Name);
        }
    }
}
