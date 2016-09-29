using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DesignPatternApp;

namespace DesignPatternApp
{
    class Program
    {
        static void Main(string[] args)
        {
            #region Factory

            Console.WriteLine("Factory Pattern Demo Start");
            Console.WriteLine("--------------------------------");
            PartFactory factory = new PartFactory();

            #region Simple Call
            //Create Manufactured Part
            //IPart manPart = factory.GetPart(PartType.Manufactured);
            //Console.WriteLine(manPart.PartNumber);
            //manPart.PartInfo();

            ////Create Purchased Part
            //IPart purPart = factory.GetPart(PartType.Purchased);
            //Console.WriteLine(purPart.PartNumber);
            //purPart.PartInfo();

            #endregion

            #region Reflection Call
            PartFactory fact = new PartFactory();
            IPart part = fact.CreateInstance(PartType.Manufactured);
            Console.WriteLine(part.PartNumber);
            part.PartInfo();

            #endregion

            Console.WriteLine("--------------------------------");
            Console.WriteLine("Factory Pattern Demo End");

            #endregion

            #region Repository

            Console.WriteLine("Repository Pattern Demo Start");
            Console.WriteLine("--------------------------------");

            //using (var dbContext = new PartDBContext())
            //{
            //    var partRepo = new Repository<PartModels>(dbContext);
            //    //var allParts = partRepo.GetById(10);
                
            //}

            Console.WriteLine("--------------------------------");
            Console.WriteLine("Repository Pattern Demo End");

            #endregion

            #region State

            Console.WriteLine("State Pattern Demo Start");
            Console.WriteLine("--------------------------------");

            // create Context object and suplied current state or initial state (state A).
            Context context = new Context(new StateA());

            //Change state request from A to B.
            context.Request();

            //Change state request from B to C.
            context.Request();

            //Change state request from C to A.
            context.Request();

            Console.WriteLine("State Pattern Demo End");
            Console.WriteLine("--------------------------------");

            #endregion

            #region Observer
            Console.WriteLine("Observer Pattern Demo Start");
            Console.WriteLine("--------------------------------");

            PartSubject partSubject = new PartSubject();
             
            //Register observer 1
            IObserver observer1 = new PartObserver("Observer 1");
            partSubject.Attach(observer1);
            //Register observer 2
            IObserver observer2 = new PartObserver("Observer 2");
            partSubject.Attach(observer2);

            //Register observer 3
            IObserver observer3 = new PartObserver("Observer 3");
            partSubject.Attach(observer3);

            partSubject.PartStock += 1;

            //Now remove one observer
            partSubject.Dettach(observer2);

            partSubject.PartStock += 1;

            Console.WriteLine("Observer Pattern Demo Start");
            Console.WriteLine("--------------------------------");

            #endregion

            Console.ReadKey();
        }
    }
}
