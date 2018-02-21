using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace DigiWord.Entities
{
    /// <summary>
    /// Represents a number detail
    /// </summary>
    [DataContract]
    public class NumberDetail
    {
        /// <summary>
        /// A guid holds the Id
        /// </summary>
        public Guid Id { get; } = Guid.NewGuid();

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

        /// <summary>
        /// Holds the textual representation if the number.
        /// </summary>
        [DataMember]
        [DisplayName("Converted Number")]
        public string ConvertedNumber { get; set; }

        /// <summary>
        /// A Date-time when the record has been created
        /// </summary>
        [DataMember]
        [DisplayName("Created on")]
        public DateTime DateCreated { get; } = DateTime.UtcNow;

        public override string ToString() =>
            $"{this.Number}: {this.ConvertedNumber}";
    }
}
