using System.Collections.Generic;

namespace TestAssignment.AddressBook.Dtos
{

    /// <summary>
    /// Model used for responses to invalid data validation
    /// </summary>
    public class ModelErrorDto
    {

        /// <summary>
        /// Model type
        /// </summary>
        public string ModelType { get; set; }

        /// <summary>
        /// Errors map
        /// </summary>
        public Dictionary<string,string[]> Errors { get; set; }
    }
}
