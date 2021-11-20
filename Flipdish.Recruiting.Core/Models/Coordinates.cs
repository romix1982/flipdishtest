using System;
using System.Text;
using System.Collections.Generic;
using System.Runtime.Serialization;
using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace Flipdish.Recruiting.Core.Models
{
    /// <summary>
    /// Coordinates
    /// </summary>
    [DataContract]
    public partial class Coordinates :  IEquatable<Coordinates>, IValidatableObject
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Coordinates" /> class.
        /// </summary>
        /// <param name="latitude">Latitude.</param>
        /// <param name="longitude">Longitude.</param>
        public Coordinates(double? latitude = default(double?), double? longitude = default(double?))
        {
           Latitude = latitude;
           Longitude = longitude;
        }

        /// <summary>
        /// Latitude
        /// </summary>
        /// <value>Latitude</value>
        [DataMember(Name="Latitude", EmitDefaultValue=false)]
        public double? Latitude { get; set; }

        /// <summary>
        /// Longitude
        /// </summary>
        /// <value>Longitude</value>
        [DataMember(Name="Longitude", EmitDefaultValue=false)]
        public double? Longitude { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class Coordinates {\n");
            sb.Append("  Latitude: ").Append(Latitude).Append("\n");
            sb.Append("  Longitude: ").Append(Longitude).Append("\n");
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
        public override bool Equals(object input) => Equals(input as Coordinates);

        /// <summary>
        /// Returns true if Coordinates instances are equal
        /// </summary>
        /// <param name="input">Instance of Coordinates to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(Coordinates input)
        {
            if (input == null)
                return false;

            return 
                (
                    Latitude == input.Latitude ||
                    (Latitude != null &&
                    Latitude.Equals(input.Latitude))
                ) && 
                (
                    Longitude == input.Longitude ||
                    (Longitude != null &&
                    Longitude.Equals(input.Longitude))
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
                if (Latitude != null)
                    hashCode = hashCode * 59 + Latitude.GetHashCode();
                if (Longitude != null)
                    hashCode = hashCode * 59 + Longitude.GetHashCode();
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
