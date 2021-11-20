using System;
using System.Text;
using System.Collections.Generic;
using System.Runtime.Serialization;
using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace Flipdish.Recruiting.Core.Models
{
    /// <summary>
    /// Represents a masked phone number
    /// </summary>
    [DataContract]
    public partial class MaskedPhoneNumber :  IEquatable<MaskedPhoneNumber>, IValidatableObject
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="MaskedPhoneNumber" /> class.
        /// </summary>
        /// <param name="isEnabled">Defines if the feature is enabled.</param>
        /// <param name="phoneNumber">Defines the phone number to call.</param>
        /// <param name="code">Defines the code to enter.</param>
        public MaskedPhoneNumber(bool? isEnabled = default(bool?), string phoneNumber = default(string), string code = default(string))
        {
            IsEnabled = isEnabled;
            PhoneNumber = phoneNumber;
            Code = code;
        }
        
        /// <summary>
        /// Defines if the feature is enabled
        /// </summary>
        /// <value>Defines if the feature is enabled</value>
        [DataMember(Name="IsEnabled", EmitDefaultValue=false)]
        public bool? IsEnabled { get; set; }

        /// <summary>
        /// Defines the phone number to call
        /// </summary>
        /// <value>Defines the phone number to call</value>
        [DataMember(Name="PhoneNumber", EmitDefaultValue=false)]
        public string PhoneNumber { get; set; }

        /// <summary>
        /// Defines the code to enter
        /// </summary>
        /// <value>Defines the code to enter</value>
        [DataMember(Name="Code", EmitDefaultValue=false)]
        public string Code { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class MaskedPhoneNumber {\n");
            sb.Append("  IsEnabled: ").Append(IsEnabled).Append("\n");
            sb.Append("  PhoneNumber: ").Append(PhoneNumber).Append("\n");
            sb.Append("  Code: ").Append(Code).Append("\n");
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
        public override bool Equals(object input) => Equals(input as MaskedPhoneNumber);

        /// <summary>
        /// Returns true if MaskedPhoneNumber instances are equal
        /// </summary>
        /// <param name="input">Instance of MaskedPhoneNumber to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(MaskedPhoneNumber input)
        {
            if (input == null)
                return false;

            return 
                (
                    IsEnabled == input.IsEnabled ||
                    (IsEnabled != null &&
                    IsEnabled.Equals(input.IsEnabled))
                ) && 
                (
                    PhoneNumber == input.PhoneNumber ||
                    (PhoneNumber != null &&
                    PhoneNumber.Equals(input.PhoneNumber))
                ) && 
                (
                    Code == input.Code ||
                    (Code != null &&
                    Code.Equals(input.Code))
                );
        }

        /// <summary>
        /// Gets the hash code
        /// </summary>
        /// <returns>Hash code</returns>
        public override int GetHashCode()
        {
            unchecked
            {
                var hashCode = 41;
                if (IsEnabled != null)
                    hashCode = hashCode * 59 + IsEnabled.GetHashCode();
                if (PhoneNumber != null)
                    hashCode = hashCode * 59 + PhoneNumber.GetHashCode();
                if (Code != null)
                    hashCode = hashCode * 59 + Code.GetHashCode();
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
