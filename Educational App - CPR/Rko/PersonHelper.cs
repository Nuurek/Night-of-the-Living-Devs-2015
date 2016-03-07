using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rko
{
    public enum Person
    {
        Adult,
        Child,
        Infant
    }
    public class PersonHelper
    {
        public Person WhichPerson;
        public PersonHelper(Person WhichPerson)
        {
            this.WhichPerson = WhichPerson;
        }
    }
}
