using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace patronesCSHARP
{
    public class Visitor
    {
        // The Component interface declares an `accept` method that should take the
        // base visitor interface as an argument.
        public interface IComponent
        {
            void Accept(IVisitor visitor);
        }

        public class ConcreteComponentA : IComponent
        {
            public void Accept(IVisitor visitor)
            {
                visitor.VisitConcreteComponentA(this);
            }

            public string ExclusiveMethodOfConcreteComponentA()
            {
                return "A";
            }
        }

        public class ConcreteComponentB : IComponent
        {
            public void Accept(IVisitor visitor)
            {
                visitor.VisitConcreteComponentB(this);
            }

            public string SpecialMethodOfConcreteComponentB()
            {
                return "B";
            }
        }

        public interface IVisitor
        {
            void VisitConcreteComponentA(ConcreteComponentA element);

            void VisitConcreteComponentB(ConcreteComponentB element);
        }


        public class ConcreteVisitor1 : IVisitor
        {
            public void VisitConcreteComponentA(ConcreteComponentA element)
            {
                Console.WriteLine(element.ExclusiveMethodOfConcreteComponentA() + " + ConcreteVisitor1");
            }

            public void VisitConcreteComponentB(ConcreteComponentB element)
            {
                Console.WriteLine(element.SpecialMethodOfConcreteComponentB() + " + ConcreteVisitor1");
            }
        }

        public class ConcreteVisitor2 : IVisitor
        {
            public void VisitConcreteComponentA(ConcreteComponentA element)
            {
                Console.WriteLine(element.ExclusiveMethodOfConcreteComponentA() + " + ConcreteVisitor2");
            }

            public void VisitConcreteComponentB(ConcreteComponentB element)
            {
                Console.WriteLine(element.SpecialMethodOfConcreteComponentB() + " + ConcreteVisitor2");
            }
        }

        public class Client
        {
            // The client code can run visitor operations over any set of elements
            // without figuring out their concrete classes. The accept operation
            // directs a call to the appropriate operation in the visitor object.
            public static void ClientCode(List<IComponent> components, IVisitor visitor)
            {
                foreach (var component in components)
                {
                    component.Accept(visitor);
                }
            }
        }
    }
}
