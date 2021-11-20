using System;
using System.Linq;
using System.Text;
using System.Collections.Generic;
using System.Runtime.Serialization;
using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace Flipdish.Recruiting.Core.Models
{
    /// <summary>
    /// Order item option
    /// </summary>
    [DataContract]
    public partial class OrderItemOption :  IEquatable<OrderItemOption>, IValidatableObject
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="OrderItemOption" /> class.
        /// </summary>
        /// <param name="metadata">Metadata.</param>
        /// <param name="menuItemOptionPublicId">Public id of the Menu Item Option.</param>
        /// <param name="menuItemOptionId">Menu item option identifier.</param>
        /// <param name="isMasterOptionSetItem">Is master option set item.</param>
        /// <param name="name">Name.</param>
        /// <param name="price">Price.</param>
        /// <param name="menuItemOptionDisplayOrder">Menu item option display order.</param>
        /// <param name="menuItemOptionSetDisplayOrder">Menu item option set display order.</param>
        public OrderItemOption(Dictionary<string, string> metadata = default(Dictionary<string, string>), Guid? menuItemOptionPublicId = default(Guid?), int? menuItemOptionId = default(int?), bool? isMasterOptionSetItem = default(bool?), string name = default(string), double? price = default(double?), int? menuItemOptionDisplayOrder = default(int?), int? menuItemOptionSetDisplayOrder = default(int?))
        {
            Metadata = metadata;
            MenuItemOptionPublicId = menuItemOptionPublicId;
            MenuItemOptionId = menuItemOptionId;
            IsMasterOptionSetItem = isMasterOptionSetItem;
            Name = name;
            Price = price;
            MenuItemOptionDisplayOrder = menuItemOptionDisplayOrder;
            MenuItemOptionSetDisplayOrder = menuItemOptionSetDisplayOrder;
        }

        /// <summary>
        /// Metadata
        /// </summary>
        /// <value>Metadata</value>
        [DataMember(Name="Metadata", EmitDefaultValue=false)]
        public Dictionary<string, string> Metadata { get; set; }

        /// <summary>
        /// Public id of the Menu Item Option
        /// </summary>
        /// <value>Public id of the Menu Item Option</value>
        [DataMember(Name="MenuItemOptionPublicId", EmitDefaultValue=false)]
        public Guid? MenuItemOptionPublicId { get; set; }

        /// <summary>
        /// Menu item option identifier
        /// </summary>
        /// <value>Menu item option identifier</value>
        [DataMember(Name="MenuItemOptionId", EmitDefaultValue=false)]
        public int? MenuItemOptionId { get; set; }

        /// <summary>
        /// Is master option set item
        /// </summary>
        /// <value>Is master option set item</value>
        [DataMember(Name="IsMasterOptionSetItem", EmitDefaultValue=false)]
        public bool? IsMasterOptionSetItem { get; set; }

        /// <summary>
        /// Name
        /// </summary>
        /// <value>Name</value>
        [DataMember(Name="Name", EmitDefaultValue=false)]
        public string Name { get; set; }

        /// <summary>
        /// Price
        /// </summary>
        /// <value>Price</value>
        [DataMember(Name="Price", EmitDefaultValue=false)]
        public double? Price { get; set; }

        /// <summary>
        /// Menu item option display order
        /// </summary>
        /// <value>Menu item option display order</value>
        [DataMember(Name="MenuItemOptionDisplayOrder", EmitDefaultValue=false)]
        public int? MenuItemOptionDisplayOrder { get; set; }

        /// <summary>
        /// Menu item option set display order
        /// </summary>
        /// <value>Menu item option set display order</value>
        [DataMember(Name="MenuItemOptionSetDisplayOrder", EmitDefaultValue=false)]
        public int? MenuItemOptionSetDisplayOrder { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class OrderItemOption {\n");
            sb.Append("  Metadata: ").Append(Metadata).Append("\n");
            sb.Append("  MenuItemOptionPublicId: ").Append(MenuItemOptionPublicId).Append("\n");
            sb.Append("  MenuItemOptionId: ").Append(MenuItemOptionId).Append("\n");
            sb.Append("  IsMasterOptionSetItem: ").Append(IsMasterOptionSetItem).Append("\n");
            sb.Append("  Name: ").Append(Name).Append("\n");
            sb.Append("  Price: ").Append(Price).Append("\n");
            sb.Append("  MenuItemOptionDisplayOrder: ").Append(MenuItemOptionDisplayOrder).Append("\n");
            sb.Append("  MenuItemOptionSetDisplayOrder: ").Append(MenuItemOptionSetDisplayOrder).Append("\n");
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
        public override bool Equals(object input) => Equals(input as OrderItemOption);

        /// <summary>
        /// Returns true if OrderItemOption instances are equal
        /// </summary>
        /// <param name="input">Instance of OrderItemOption to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(OrderItemOption input)
        {
            if (input == null)
                return false;

            return 
                (
                    Metadata == input.Metadata ||
                    Metadata != null &&
                    Metadata.SequenceEqual(input.Metadata)
                ) && 
                (
                    MenuItemOptionPublicId == input.MenuItemOptionPublicId ||
                    (MenuItemOptionPublicId != null &&
                    MenuItemOptionPublicId.Equals(input.MenuItemOptionPublicId))
                ) && 
                (
                    MenuItemOptionId == input.MenuItemOptionId ||
                    (MenuItemOptionId != null &&
                    MenuItemOptionId.Equals(input.MenuItemOptionId))
                ) && 
                (
                    IsMasterOptionSetItem == input.IsMasterOptionSetItem ||
                    (IsMasterOptionSetItem != null &&
                    IsMasterOptionSetItem.Equals(input.IsMasterOptionSetItem))
                ) && 
                (
                    Name == input.Name ||
                    (Name != null &&
                    Name.Equals(input.Name))
                ) && 
                (
                    Price == input.Price ||
                    (Price != null &&
                    Price.Equals(input.Price))
                ) && 
                (
                    MenuItemOptionDisplayOrder == input.MenuItemOptionDisplayOrder ||
                    (MenuItemOptionDisplayOrder != null &&
                    MenuItemOptionDisplayOrder.Equals(input.MenuItemOptionDisplayOrder))
                ) && 
                (
                    MenuItemOptionSetDisplayOrder == input.MenuItemOptionSetDisplayOrder ||
                    (MenuItemOptionSetDisplayOrder != null &&
                    MenuItemOptionSetDisplayOrder.Equals(input.MenuItemOptionSetDisplayOrder))
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
                if (Metadata != null)
                    hashCode = hashCode * 59 + Metadata.GetHashCode();
                if (MenuItemOptionPublicId != null)
                    hashCode = hashCode * 59 + MenuItemOptionPublicId.GetHashCode();
                if (MenuItemOptionId != null)
                    hashCode = hashCode * 59 + MenuItemOptionId.GetHashCode();
                if (IsMasterOptionSetItem != null)
                    hashCode = hashCode * 59 + IsMasterOptionSetItem.GetHashCode();
                if (Name != null)
                    hashCode = hashCode * 59 + Name.GetHashCode();
                if (Price != null)
                    hashCode = hashCode * 59 + Price.GetHashCode();
                if (MenuItemOptionDisplayOrder != null)
                    hashCode = hashCode * 59 + MenuItemOptionDisplayOrder.GetHashCode();
                if (MenuItemOptionSetDisplayOrder != null)
                    hashCode = hashCode * 59 + MenuItemOptionSetDisplayOrder.GetHashCode();
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
