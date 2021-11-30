using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AplicacionReal
{
  public  interface IRepository
    {
        IList<Customer> GetAll();
        void Save(Customer customer);

    }
}
