using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatternApp
{
    public class Context
    {
        public StateBase State { get; set; }

        public Context(StateBase state)
        {
            State = state;
            Console.WriteLine("Create object of context class with initial State.");
        }

        /// <summary>
        /// State change request
        /// </summary>
        public void Request()
        {
            State.Change(this);
        }
    }
    public interface StateBase
    {
        void Change(Context context);
    }

    public class StateA : StateBase
    {
        public void Change(Context context)
        {
            //change state of context from A to B
            context.State = new StateB();
            Console.WriteLine("Change state from A to B.");
        }
    }

    public class StateB : StateBase
    {
        public void Change(Context context)
        {
            //change state of context from B to C
            context.State = new StateC();
            Console.WriteLine("Change state from B to C.");
        }
    }

    public class StateC : StateBase
    {
        public void Change(Context context)
        {
            //change state of context from C to A
            context.State = new StateA();
            Console.WriteLine("Change state from C to A.");
        }
    }
}
