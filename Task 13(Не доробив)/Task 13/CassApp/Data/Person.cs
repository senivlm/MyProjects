using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CassApp.Data
{
    public abstract class Person
    {
        protected string name;
        protected int age;

        public Person(string name, int age) 
        { 
            this.name = name;
            this.age = age;
        }
    }
}
