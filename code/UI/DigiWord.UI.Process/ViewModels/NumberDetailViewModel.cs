using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

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
        public decimal Number { get; set; }
    }
}
