using System;
using System.Text;
using System.Collections.Generic;
using System.Runtime.Serialization;
using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace Flipdish.Recruiting.Core.Models
{
    /// <summary>
    /// Delivery location
    /// </summary>
    [DataContract]
    public partial class DeliveryLocation :  IEquatable<DeliveryLocation>, IValidatableObject
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DeliveryLocation" /> class.
        /// </summary>
        /// <param name="coordinates">Geo cordinate.</param>
        /// <param name="building">Building.</param>
        /// <param name="street">Street.</param>
        /// <param name="town">Town.</param>
        /// <param name="postCode">Post code.</param>
        /// <param name="deliveryInstructions">Delivery instructions.</param>
        /// <param name="prettyAddressString">Formatted, pretty address string.</param>
        public DeliveryLocation(Coordinates coordinates = default(Coordinates), string building = default(string), string street = default(string), string town = default(string), string postCode = default(string), string deliveryInstructions = default(string), string prettyAddressString = default(string))
        {
            Coordinates = coordinates;
            Building = building;
            Street = street;
            Town = town;
            PostCode = postCode;
            DeliveryInstructions = deliveryInstructions;
            PrettyAddressString = prettyAddressString;
        }

        /// <summary>
        /// Geo cordinate
        /// </summary>
        /// <value>Geo cordinate</value>
        [DataMember(Name="Coordinates", EmitDefaultValue=false)]
        public Coordinates Coordinates { get; set; }

        /// <summary>
        /// Building
        /// </summary>
        /// <value>Building</value>
        [DataMember(Name="Building", EmitDefaultValue=false)]
        public string Building { get; set; }

        /// <summary>
        /// Street
        /// </summary>
        /// <value>Street</value>
        [DataMember(Name="Street", EmitDefaultValue=false)]
        public string Street { get; set; }

        /// <summary>
        /// Town
        /// </summary>
        /// <value>Town</value>
        [DataMember(Name="Town", EmitDefaultValue=false)]
        public string Town { get; set; }

        /// <summary>
        /// Post code
        /// </summary>
        /// <value>Post code</value>
        [DataMember(Name="PostCode", EmitDefaultValue=false)]
        public string PostCode { get; set; }

        /// <summary>
        /// Delivery instructions
        /// </summary>
        /// <value>Delivery instructions</value>
        [DataMember(Name="DeliveryInstructions", EmitDefaultValue=false)]
        public string DeliveryInstructions { get; set; }

        /// <summary>
        /// Formatted, pretty address string
        /// </summary>
        /// <value>Formatted, pretty address string</value>
        [DataMember(Name="PrettyAddressString", EmitDefaultValue=false)]
        public string PrettyAddressString { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class DeliveryLocation {\n");
            sb.Append("  Coordinates: ").Append(Coordinates).Append("\n");
            sb.Append("  Building: ").Append(Building).Append("\n");
            sb.Append("  Street: ").Append(Street).Append("\n");
            sb.Append("  Town: ").Append(Town).Append("\n");
            sb.Append("  PostCode: ").Append(PostCode).Append("\n");
            sb.Append("  DeliveryInstructions: ").Append(DeliveryInstructions).Append("\n");
            sb.Append("  PrettyAddressString: ").Append(PrettyAddressString).Append("\n");
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
        public override bool Equals(object input) => Equals(input as DeliveryLocation);

        /// <summary>
        /// Returns true if DeliveryLocation instances are equal
        /// </summary>
        /// <param name="input">Instance of DeliveryLocation to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(DeliveryLocation input)
        {
            if (input == null)
                return false;

            return 
                (
                    Coordinates == input.Coordinates ||
                    (Coordinates != null &&
                    Coordinates.Equals(input.Coordinates))
                ) && 
                (
                    Building == input.Building ||
                    (Building != null &&
                    Building.Equals(input.Building))
                ) && 
                (
                    Street == input.Street ||
                    (Street != null &&
                    Street.Equals(input.Street))
                ) && 
                (
                    Town == input.Town ||
                    (Town != null &&
                    Town.Equals(input.Town))
                ) && 
                (
                    PostCode == input.PostCode ||
                    (PostCode != null &&
                    PostCode.Equals(input.PostCode))
                ) && 
                (
                    DeliveryInstructions == input.DeliveryInstructions ||
                    (DeliveryInstructions != null &&
                    DeliveryInstructions.Equals(input.DeliveryInstructions))
                ) && 
                (
                    PrettyAddressString == input.PrettyAddressString ||
                    (PrettyAddressString != null &&
                    PrettyAddressString.Equals(input.PrettyAddressString))
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
                if (Coordinates != null)
                    hashCode = hashCode * 59 + Coordinates.GetHashCode();
                if (Building != null)
                    hashCode = hashCode * 59 + Building.GetHashCode();
                if (Street != null)
                    hashCode = hashCode * 59 + Street.GetHashCode();
                if (Town != null)
                    hashCode = hashCode * 59 + Town.GetHashCode();
                if (PostCode != null)
                    hashCode = hashCode * 59 + PostCode.GetHashCode();
                if (DeliveryInstructions != null)
                    hashCode = hashCode * 59 + DeliveryInstructions.GetHashCode();
                if (PrettyAddressString != null)
                    hashCode = hashCode * 59 + PrettyAddressString.GetHashCode();
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
