using System;

namespace PersonneLibrary
{
    public class PersonneException : Exception
    {
        #region Constructeurs
        public PersonneException(): base() { }

        public PersonneException(string libelle): base(libelle) { }
        #endregion
    }
}
