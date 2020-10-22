using System;

namespace PersonneLibrary
{
    public class PersonneInvalidAttributeException : Exception
    {
        #region Constructeurs
        public PersonneInvalidAttributeException() : base() { }

        public PersonneInvalidAttributeException(string libelle) : base(libelle) { }
        #endregion
    }
}
