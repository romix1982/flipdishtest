using System;
using System.Text;
using System.Collections.Generic;
using System.Runtime.Serialization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System.ComponentModel.DataAnnotations;

namespace Flipdish.Recruiting.Core.Models
{
    /// <summary>
    /// Voucher summary
    /// </summary>
    [DataContract]
    public partial class OrderVoucherSummary : IEquatable<OrderVoucherSummary>, IValidatableObject
    {
        /// <summary>
        /// Voucher type
        /// </summary>
        /// <value>Voucher type</value>
        [JsonConverter(typeof(StringEnumConverter))]
        public enum TypeEnum
        {
            
            /// <summary>
            /// Enum PercentageDiscount for value: PercentageDiscount
            /// </summary>
            [EnumMember(Value = "PercentageDiscount")]
            PercentageDiscount = 1,
            
            /// <summary>
            /// Enum LumpDiscount for value: LumpDiscount
            /// </summary>
            [EnumMember(Value = "LumpDiscount")]
            LumpDiscount = 2,
            
            /// <summary>
            /// Enum AddItem for value: AddItem
            /// </summary>
            [EnumMember(Value = "AddItem")]
            AddItem = 3,
            
            /// <summary>
            /// Enum CreditNote for value: CreditNote
            /// </summary>
            [EnumMember(Value = "CreditNote")]
            CreditNote = 4
        }

        /// <summary>
        /// Voucher type
        /// </summary>
        /// <value>Voucher type</value>
        [DataMember(Name="Type", EmitDefaultValue=false)]
        public TypeEnum? Type { get; set; }

        /// <summary>
        /// Voucher sub type
        /// </summary>
        /// <value>Voucher sub type</value>
        [JsonConverter(typeof(StringEnumConverter))]
        public enum SubTypeEnum
        {
            /// <summary>
            /// Enum None for value: None
            /// </summary>
            [EnumMember(Value = "None")]
            None = 1,
            
            /// <summary>
            /// Enum SignUp for value: SignUp
            /// </summary>
            [EnumMember(Value = "SignUp")]
            SignUp = 2,
            
            /// <summary>
            /// Enum Loyalty for value: Loyalty
            /// </summary>
            [EnumMember(Value = "Loyalty")]
            Loyalty = 3,
            
            /// <summary>
            /// Enum Loyalty25 for value: Loyalty25
            /// </summary>
            [EnumMember(Value = "Loyalty25")]
            Loyalty25 = 4,
            
            /// <summary>
            /// Enum Retention for value: Retention
            /// </summary>
            [EnumMember(Value = "Retention")]
            Retention = 5,
            
            /// <summary>
            /// Enum SecondaryRetention for value: SecondaryRetention
            /// </summary>
            [EnumMember(Value = "SecondaryRetention")]
            SecondaryRetention = 6,
            
            /// <summary>
            /// Enum Custom for value: Custom
            /// </summary>
            [EnumMember(Value = "Custom")]
            Custom = 7
        }

        /// <summary>
        /// Voucher sub type
        /// </summary>
        /// <value>Voucher sub type</value>
        [DataMember(Name="SubType", EmitDefaultValue=false)]
        public SubTypeEnum? SubType { get; set; }
        /// <summary>
        /// Initializes a new instance of the <see cref="OrderVoucherSummary" /> class.
        /// </summary>
        /// <param name="name">Voucher name.</param>
        /// <param name="description">Voucher description.</param>
        /// <param name="code">Voucher code.</param>
        /// <param name="amount">Voucher amount.</param>
        /// <param name="type">Voucher type.</param>
        /// <param name="subType">Voucher sub type.</param>
        public OrderVoucherSummary(string name = default, string description = default, string code = default, double? amount = default, TypeEnum? type = default, SubTypeEnum? subType = default)
        {
            Name = name;
            Description = description;
            Code = code;
            Amount = amount;
            Type = type;
            SubType = subType;
        }
        
        /// <summary>
        /// Voucher name
        /// </summary>
        /// <value>Voucher name</value>
        [DataMember(Name="Name", EmitDefaultValue=false)]
        public string Name { get; set; }

        /// <summary>
        /// Voucher description
        /// </summary>
        /// <value>Voucher description</value>
        [DataMember(Name="Description", EmitDefaultValue=false)]
        public string Description { get; set; }

        /// <summary>
        /// Voucher code
        /// </summary>
        /// <value>Voucher code</value>
        [DataMember(Name="Code", EmitDefaultValue=false)]
        public string Code { get; set; }

        /// <summary>
        /// Voucher amount
        /// </summary>
        /// <value>Voucher amount</value>
        [DataMember(Name="Amount", EmitDefaultValue=false)]
        public double? Amount { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class OrderVoucherSummary {\n");
            sb.Append("  Name: ").Append(Name).Append("\n");
            sb.Append("  Description: ").Append(Description).Append("\n");
            sb.Append("  Code: ").Append(Code).Append("\n");
            sb.Append("  Amount: ").Append(Amount).Append("\n");
            sb.Append("  Type: ").Append(Type).Append("\n");
            sb.Append("  SubType: ").Append(SubType).Append("\n");
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
        public override bool Equals(object input) => Equals(input as OrderVoucherSummary);

        /// <summary>
        /// Returns true if OrderVoucherSummary instances are equal
        /// </summary>
        /// <param name="input">Instance of OrderVoucherSummary to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(OrderVoucherSummary input)
        {
            if (input == null)
                return false;

            return 
                (
                    Name == input.Name ||
                    (Name != null &&
                    Name.Equals(input.Name))
                ) && 
                (
                    Description == input.Description ||
                    (Description != null &&
                    Description.Equals(input.Description))
                ) && 
                (
                    Code == input.Code ||
                    (Code != null &&
                    Code.Equals(input.Code))
                ) && 
                (
                    Amount == input.Amount ||
                    (Amount != null &&
                    Amount.Equals(input.Amount))
                ) && 
                (
                    Type == input.Type ||
                    (Type != null &&
                    Type.Equals(input.Type))
                ) && 
                (
                    SubType == input.SubType ||
                    (SubType != null &&
                    SubType.Equals(input.SubType))
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
                if (Name != null)
                    hashCode = hashCode * 59 + Name.GetHashCode();
                if (Description != null)
                    hashCode = hashCode * 59 + Description.GetHashCode();
                if (Code != null)
                    hashCode = hashCode * 59 + Code.GetHashCode();
                if (Amount != null)
                    hashCode = hashCode * 59 + Amount.GetHashCode();
                if (Type != null)
                    hashCode = hashCode * 59 + Type.GetHashCode();
                if (SubType != null)
                    hashCode = hashCode * 59 + SubType.GetHashCode();
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
