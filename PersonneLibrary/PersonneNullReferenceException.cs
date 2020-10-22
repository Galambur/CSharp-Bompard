using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonneLibrary
{
    public class PersonneNullReferenceException : Exception
    {
        #region Constructeurs
        public PersonneNullReferenceException() : base() { }

        public PersonneNullReferenceException(string libelle): base(libelle) { }
        #endregion
    }
}
