using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_14.Products.Interfaces
{
    public interface IPizza : IFood, IExpirable
    {
        public IFood GetIngridient(int id);
        public ICollection<IFood> GetIngridients { get; }

    }
}
