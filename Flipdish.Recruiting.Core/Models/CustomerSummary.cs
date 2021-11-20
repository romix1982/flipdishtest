using System;
using System.Text;
using System.Collections.Generic;
using System.Runtime.Serialization;
using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace Flipdish.Recruiting.Core.Models
{
    /// <summary>
    /// Customer summary
    /// </summary>
    [DataContract]
    public partial class CustomerSummary :  IEquatable<CustomerSummary>, IValidatableObject
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CustomerSummary" /> class.
        /// </summary>
        /// <param name="id">Customer identifier.</param>
        /// <param name="name">Customer name.</param>
        /// <param name="emailAddress">Customer email address.</param>
        /// <param name="phoneNumberLocalFormat">Customer local phone number.</param>
        /// <param name="phoneNumber">Customer phone number.</param>
        public CustomerSummary(int? id = default, string name = default, string emailAddress = default, string phoneNumberLocalFormat = default, string phoneNumber = default)
        {
            Id = id;
            Name = name;
            EmailAddress = emailAddress;
            PhoneNumberLocalFormat = phoneNumberLocalFormat;
            PhoneNumber = phoneNumber;
        }

        /// <summary>
        /// Customer identifier
        /// </summary>
        /// <value>Customer identifier</value>
        [DataMember(Name="Id", EmitDefaultValue=false)]
        public int? Id { get; set; }

        /// <summary>
        /// Customer name
        /// </summary>
        /// <value>Customer name</value>
        [DataMember(Name="Name", EmitDefaultValue=false)]
        public string Name { get; set; }

        /// <summary>
        /// Customer email address
        /// </summary>
        /// <value>Customer email address</value>
        [DataMember(Name="EmailAddress", EmitDefaultValue=false)]
        public string EmailAddress { get; set; }

        /// <summary>
        /// Customer local phone number
        /// </summary>
        /// <value>Customer local phone number</value>
        [DataMember(Name="PhoneNumberLocalFormat", EmitDefaultValue=false)]
        public string PhoneNumberLocalFormat { get; set; }

        /// <summary>
        /// Customer phone number
        /// </summary>
        /// <value>Customer phone number</value>
        [DataMember(Name="PhoneNumber", EmitDefaultValue=false)]
        public string PhoneNumber { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class CustomerSummary {\n");
            sb.Append("  Id: ").Append(Id).Append("\n");
            sb.Append("  Name: ").Append(Name).Append("\n");
            sb.Append("  EmailAddress: ").Append(EmailAddress).Append("\n");
            sb.Append("  PhoneNumberLocalFormat: ").Append(PhoneNumberLocalFormat).Append("\n");
            sb.Append("  PhoneNumber: ").Append(PhoneNumber).Append("\n");
            sb.Append("}\n");
            return sb.ToString();
        }

        /// <summary>
        /// Returns the JSON string presentation of the object
        /// </summary>
        /// <returns>JSON string presentation of the object</returns>
        public virtual string ToJson() => JsonConvert.SerializeObject(this, Formatting.Indented);

        /// <summary>
        /// Returns true if objects are equal
        /// </summary>
        /// <param name="input">Object to be compared</param>
        /// <returns>Boolean</returns>
        public override bool Equals(object input) => Equals(input as CustomerSummary);

        /// <summary>
        /// Returns true if CustomerSummary instances are equal
        /// </summary>
        /// <param name="input">Instance of CustomerSummary to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(CustomerSummary input)
        {
            if (input == null)
                return false;

            return 
                (
                    Id == input.Id ||
                    (Id != null &&
                    Id.Equals(input.Id))
                ) && 
                (
                    Name == input.Name ||
                    (Name != null &&
                    Name.Equals(input.Name))
                ) && 
                (
                    EmailAddress == input.EmailAddress ||
                    (EmailAddress != null &&
                    EmailAddress.Equals(input.EmailAddress))
                ) && 
                (
                    PhoneNumberLocalFormat == input.PhoneNumberLocalFormat ||
                    (PhoneNumberLocalFormat != null &&
                    PhoneNumberLocalFormat.Equals(input.PhoneNumberLocalFormat))
                ) && 
                (
                    PhoneNumber == input.PhoneNumber ||
                    (PhoneNumber != null &&
                    PhoneNumber.Equals(input.PhoneNumber))
                );
        }

        /// <summary>
        /// Gets the hash code
        /// </summary>
        /// <returns>Hash code</returns>
        public override int GetHashCode()
        {
            unchecked // Overflow is fine, just wrap
            {
                var hashCode = 41;
                if (Id != null)
                    hashCode = hashCode * 59 + Id.GetHashCode();
                if (Name != null)
                    hashCode = hashCode * 59 + Name.GetHashCode();
                if (EmailAddress != null)
                    hashCode = hashCode * 59 + EmailAddress.GetHashCode();
                if (PhoneNumberLocalFormat != null)
                    hashCode = hashCode * 59 + PhoneNumberLocalFormat.GetHashCode();
                if (PhoneNumber != null)
                    hashCode = hashCode * 59 + PhoneNumber.GetHashCode();
                return hashCode;
            }
        }

        /// <summary>
        /// To validate all properties of the instance
        /// </summary>
        /// <param name="validationContext">Validation context</param>
        /// <returns>Validation Result</returns>
        IEnumerable<ValidationResult> IValidatableObject.Validate(ValidationContext validationContext)
        {
            yield break;
        }
    }
}
