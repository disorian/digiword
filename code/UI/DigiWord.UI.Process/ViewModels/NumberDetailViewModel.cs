using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace DigiWord.UI.Process.ViewModels
{
    /// <summary>
    /// NumberDetail View Model
    /// </summary>
    [DataContract]
    public class NumberDetailViewModel
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
        [Range(0, ulong.MaxValue, ErrorMessage = "The number should be possitive and less than 18446744073709551615")]
        public decimal Number { get; set; }
    }
}
