using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatternApp
{
    public enum PartType
    {
        Manufactured,
        Purchased
    }

    public interface IPart
    {
        string PartNumber { get; }
        void PartInfo();       
    }

    public class ManufacturedPart : IPart
    {
        public string PartNumber
        {
            get
            {
                return "Manufactured Part 1";
            }          
        }

        public void PartInfo()
        {
            Console.WriteLine("This is Manufactured Part");
        }
    }

    public class PurchasedPart : IPart
    {
        public string PartNumber
        {
            get
            {
                return "Purchased Part 1";
            }
        }

        public void PartInfo()
        {
            Console.WriteLine("This is Purchased Part");
        }
    }

    public class UnknownPart : IPart
    {
        public string PartNumber
        {
            get
            {
                return string.Empty;
            }
        }
        public void PartInfo()
        {            
        }
    }
    /// <summary>
    /// This Fatory class is used to create objects of Parts 
    /// </summary>
    public class PartFactory
    {
        #region Simple
        // But This method violates Open closed principle of SOLID principles.
        //To overcome this we used reflection to create objects.
        public IPart GetPart(PartType pt)
        {
            switch (pt)
            {
                case PartType.Manufactured:
                    return new ManufacturedPart();                                     
                case PartType.Purchased:
                    return new PurchasedPart();
                default:
                    return new UnknownPart();
            }            
        }
        #endregion

        #region Using Reflection
        Dictionary<string, Type> parts;

        public PartFactory()
        {
            LoadReturnTypes();
        }

        public IPart CreateInstance(PartType pt)
        {
            Type t = GetTypeToCreate(pt);

            if (t == null)
                return new UnknownPart();

            return Activator.CreateInstance(t) as IPart;
        }

        private Type GetTypeToCreate(PartType pt)
        {
            foreach (var part in parts)
            {
                if (part.Key.Contains(pt.ToString().ToLower()))
                {
                    return parts[part.Key];
                }
            }

            return null;
        }

        private void LoadReturnTypes()
        {
            parts = new Dictionary<string, Type>();
            //Get types used in executing assembly.

            Type[] typesInThisAssembly = Assembly.GetExecutingAssembly().GetTypes();
            foreach (Type type in typesInThisAssembly)
            {
                if(type.GetInterface(typeof(IPart).ToString()) != null)
                {
                    parts.Add(type.Name.ToLower(), type);
                }
            }
        }
        #endregion

    }
}
