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
    /// Order item
    /// </summary>
    [DataContract]
    public partial class OrderItem :  IEquatable<OrderItem>, IValidatableObject
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="OrderItem" /> class.
        /// </summary>
        /// <param name="orderItemOptions">Option list.</param>
        /// <param name="metadata">Metadata.</param>
        /// <param name="menuItemPublicId">Public id of the Menu Item.</param>
        /// <param name="menuSectionName">Menu section name.</param>
        /// <param name="menuSectionDisplayOrder">Menu section display order.</param>
        /// <param name="name">Name.</param>
        /// <param name="description">Description.</param>
        /// <param name="price">Price.</param>
        /// <param name="priceIncludingOptionSetItems">Price including option set items.</param>
        /// <param name="menuItemId">Menu item identifier.</param>
        /// <param name="menuItemDisplayOrder">Menu item display order.</param>
        /// <param name="isAvailable">Is available.</param>
        public OrderItem(List<OrderItemOption> orderItemOptions = default, Dictionary<string, string> metadata = default, Guid? menuItemPublicId = default, string menuSectionName = default, int? menuSectionDisplayOrder = default, string name = default, string description = default, double? price = default, double? priceIncludingOptionSetItems = default, int? menuItemId = default, int? menuItemDisplayOrder = default, bool? isAvailable = default)
        {
            OrderItemOptions = orderItemOptions;
            Metadata = metadata;
            MenuItemPublicId = menuItemPublicId;
            MenuSectionName = menuSectionName;
            MenuSectionDisplayOrder = menuSectionDisplayOrder;
            Name = name;
            Description = description;
            Price = price;
            PriceIncludingOptionSetItems = priceIncludingOptionSetItems;
            MenuItemId = menuItemId;
            MenuItemDisplayOrder = menuItemDisplayOrder;
            IsAvailable = isAvailable;
        }

        /// <summary>
        /// Option list
        /// </summary>
        /// <value>Option list</value>
        [DataMember(Name="OrderItemOptions", EmitDefaultValue=false)]
        public List<OrderItemOption> OrderItemOptions { get; set; }

        /// <summary>
        /// Metadata
        /// </summary>
        /// <value>Metadata</value>
        [DataMember(Name="Metadata", EmitDefaultValue=false)]
        public Dictionary<string, string> Metadata { get; set; }

        /// <summary>
        /// Public id of the Menu Item
        /// </summary>
        /// <value>Public id of the Menu Item</value>
        [DataMember(Name="MenuItemPublicId", EmitDefaultValue=false)]
        public Guid? MenuItemPublicId { get; set; }

        /// <summary>
        /// Menu section name
        /// </summary>
        /// <value>Menu section name</value>
        [DataMember(Name="MenuSectionName", EmitDefaultValue=false)]
        public string MenuSectionName { get; set; }

        /// <summary>
        /// Menu section display order
        /// </summary>
        /// <value>Menu section display order</value>
        [DataMember(Name="MenuSectionDisplayOrder", EmitDefaultValue=false)]
        public int? MenuSectionDisplayOrder { get; set; }

        /// <summary>
        /// Name
        /// </summary>
        /// <value>Name</value>
        [DataMember(Name="Name", EmitDefaultValue=false)]
        public string Name { get; set; }

        /// <summary>
        /// Description
        /// </summary>
        /// <value>Description</value>
        [DataMember(Name="Description", EmitDefaultValue=false)]
        public string Description { get; set; }

        /// <summary>
        /// Price
        /// </summary>
        /// <value>Price</value>
        [DataMember(Name="Price", EmitDefaultValue=false)]
        public double? Price { get; set; }

        /// <summary>
        /// Price including option set items
        /// </summary>
        /// <value>Price including option set items</value>
        [DataMember(Name="PriceIncludingOptionSetItems", EmitDefaultValue=false)]
        public double? PriceIncludingOptionSetItems { get; set; }

        /// <summary>
        /// Menu item identifier
        /// </summary>
        /// <value>Menu item identifier</value>
        [DataMember(Name="MenuItemId", EmitDefaultValue=false)]
        public int? MenuItemId { get; set; }

        /// <summary>
        /// Menu item display order
        /// </summary>
        /// <value>Menu item display order</value>
        [DataMember(Name="MenuItemDisplayOrder", EmitDefaultValue=false)]
        public int? MenuItemDisplayOrder { get; set; }

        /// <summary>
        /// Is available
        /// </summary>
        /// <value>Is available</value>
        [DataMember(Name="IsAvailable", EmitDefaultValue=false)]
        public bool? IsAvailable { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class OrderItem {\n");
            sb.Append("  OrderItemOptions: ").Append(OrderItemOptions).Append("\n");
            sb.Append("  Metadata: ").Append(Metadata).Append("\n");
            sb.Append("  MenuItemPublicId: ").Append(MenuItemPublicId).Append("\n");
            sb.Append("  MenuSectionName: ").Append(MenuSectionName).Append("\n");
            sb.Append("  MenuSectionDisplayOrder: ").Append(MenuSectionDisplayOrder).Append("\n");
            sb.Append("  Name: ").Append(Name).Append("\n");
            sb.Append("  Description: ").Append(Description).Append("\n");
            sb.Append("  Price: ").Append(Price).Append("\n");
            sb.Append("  PriceIncludingOptionSetItems: ").Append(PriceIncludingOptionSetItems).Append("\n");
            sb.Append("  MenuItemId: ").Append(MenuItemId).Append("\n");
            sb.Append("  MenuItemDisplayOrder: ").Append(MenuItemDisplayOrder).Append("\n");
            sb.Append("  IsAvailable: ").Append(IsAvailable).Append("\n");
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
        public override bool Equals(object input) => Equals(input as OrderItem);

        /// <summary>
        /// Returns true if OrderItem instances are equal
        /// </summary>
        /// <param name="input">Instance of OrderItem to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(OrderItem input)
        {
            if (input == null)
                return false;

            return 
                (
                    OrderItemOptions == input.OrderItemOptions ||
                    OrderItemOptions != null &&
                    OrderItemOptions.SequenceEqual(input.OrderItemOptions)
                ) && 
                (
                    Metadata == input.Metadata ||
                    Metadata != null &&
                    Metadata.SequenceEqual(input.Metadata)
                ) && 
                (
                    MenuItemPublicId == input.MenuItemPublicId ||
                    (MenuItemPublicId != null &&
                    MenuItemPublicId.Equals(input.MenuItemPublicId))
                ) && 
                (
                    MenuSectionName == input.MenuSectionName ||
                    (MenuSectionName != null &&
                    MenuSectionName.Equals(input.MenuSectionName))
                ) && 
                (
                    MenuSectionDisplayOrder == input.MenuSectionDisplayOrder ||
                    (MenuSectionDisplayOrder != null &&
                    MenuSectionDisplayOrder.Equals(input.MenuSectionDisplayOrder))
                ) && 
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
                    Price == input.Price ||
                    (Price != null &&
                    Price.Equals(input.Price))
                ) && 
                (
                    PriceIncludingOptionSetItems == input.PriceIncludingOptionSetItems ||
                    (PriceIncludingOptionSetItems != null &&
                    PriceIncludingOptionSetItems.Equals(input.PriceIncludingOptionSetItems))
                ) && 
                (
                    MenuItemId == input.MenuItemId ||
                    (MenuItemId != null &&
                    MenuItemId.Equals(input.MenuItemId))
                ) && 
                (
                    MenuItemDisplayOrder == input.MenuItemDisplayOrder ||
                    (MenuItemDisplayOrder != null &&
                    MenuItemDisplayOrder.Equals(input.MenuItemDisplayOrder))
                ) && 
                (
                    IsAvailable == input.IsAvailable ||
                    (IsAvailable != null &&
                    IsAvailable.Equals(input.IsAvailable))
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
                if (OrderItemOptions != null)
                    hashCode = hashCode * 59 + OrderItemOptions.GetHashCode();
                if (Metadata != null)
                    hashCode = hashCode * 59 + Metadata.GetHashCode();
                if (MenuItemPublicId != null)
                    hashCode = hashCode * 59 + MenuItemPublicId.GetHashCode();
                if (MenuSectionName != null)
                    hashCode = hashCode * 59 + MenuSectionName.GetHashCode();
                if (MenuSectionDisplayOrder != null)
                    hashCode = hashCode * 59 + MenuSectionDisplayOrder.GetHashCode();
                if (Name != null)
                    hashCode = hashCode * 59 + Name.GetHashCode();
                if (Description != null)
                    hashCode = hashCode * 59 + Description.GetHashCode();
                if (Price != null)
                    hashCode = hashCode * 59 + Price.GetHashCode();
                if (PriceIncludingOptionSetItems != null)
                    hashCode = hashCode * 59 + PriceIncludingOptionSetItems.GetHashCode();
                if (MenuItemId != null)
                    hashCode = hashCode * 59 + MenuItemId.GetHashCode();
                if (MenuItemDisplayOrder != null)
                    hashCode = hashCode * 59 + MenuItemDisplayOrder.GetHashCode();
                if (IsAvailable != null)
                    hashCode = hashCode * 59 + IsAvailable.GetHashCode();
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
