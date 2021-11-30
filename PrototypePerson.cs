using System;

namespace patronesCSHARP
{
    public class PrototypePerson
    {
        public int edad;
        public DateTime nacimiento;
        public string nombre;
        public IdInfo idInf;

        public PrototypePerson ShallowCopy() {return (PrototypePerson)this.MemberwiseClone();}

        public PrototypePerson DeepCopy()
        {
            PrototypePerson clone = (PrototypePerson)this.MemberwiseClone();
            clone.idInf = new IdInfo(idInf.idNumber);
            clone.nombre = String.Copy(nombre);
            return clone;
        }

        public class IdInfo
        {
            public int idNumber;
            public IdInfo(int idNumber){this.idNumber = idNumber;}
        }
    }
}
