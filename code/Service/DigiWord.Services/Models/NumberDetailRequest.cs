using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace DigiWord.Services.Models
{
    /// <summary>
    /// NumberDetail request data contract
    /// </summary>
    [DataContract]
    public class NumberDetailRequest
    {
        /// <summary>
        /// A string holds the name
        /// </summary>
        [DataMember]
        [Required]
        public string Name { get; set; }

        /// <summary>
        /// Holds  number to be converted to textual representation
        /// </summary>
        [DataMember]
        [Required]
        public decimal Number { get; set; }
    }
}
