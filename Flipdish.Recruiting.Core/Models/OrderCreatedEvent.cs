using System;
using System.Text;
using System.Collections.Generic;
using System.Runtime.Serialization;
using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace Flipdish.Recruiting.Core.Models
{
    /// <summary>
    /// Order Created Event
    /// </summary>
    [DataContract]
    public partial class OrderCreatedEvent :  IEquatable<OrderCreatedEvent>, IValidatableObject
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="OrderCreatedEvent" /> class.
        /// </summary>
        /// <param name="eventName">The event name.</param>
        /// <param name="description">Description.</param>
        /// <param name="orderCreatedTime">Order Created Time.</param>
        /// <param name="order">Order.</param>
        /// <param name="flipdishEventId">The identitfier of the event.</param>
        /// <param name="createTime">The time of creation of the event.</param>
        /// <param name="position">Position.</param>
        /// <param name="appId">App id.</param>
        public OrderCreatedEvent(string eventName = default(string), string description = default(string), DateTime? orderCreatedTime = default(DateTime?), Order order = default(Order), Guid? flipdishEventId = default(Guid?), DateTime? createTime = default(DateTime?), int? position = default(int?), string appId = default(string))
        {
            EventName = eventName;
            Description = description;
            OrderCreatedTime = orderCreatedTime;
            Order = order;
            FlipdishEventId = flipdishEventId;
            CreateTime = createTime;
            Position = position;
            AppId = appId;
        }

        /// <summary>
        /// The event name
        /// </summary>
        /// <value>The event name</value>
        [DataMember(Name="EventName", EmitDefaultValue=false)]
        public string EventName { get; set; }

        /// <summary>
        /// Description
        /// </summary>
        /// <value>Description</value>
        [DataMember(Name="Description", EmitDefaultValue=false)]
        public string Description { get; set; }

        /// <summary>
        /// Order Created Time
        /// </summary>
        /// <value>Order Created Time</value>
        [DataMember(Name="OrderCreatedTime", EmitDefaultValue=false)]
        public DateTime? OrderCreatedTime { get; set; }

        /// <summary>
        /// Order
        /// </summary>
        /// <value>Order</value>
        [DataMember(Name="Order", EmitDefaultValue=false)]
        public Order Order { get; set; }

        /// <summary>
        /// The identitfier of the event
        /// </summary>
        /// <value>The identitfier of the event</value>
        [DataMember(Name="FlipdishEventId", EmitDefaultValue=false)]
        public Guid? FlipdishEventId { get; set; }

        /// <summary>
        /// The time of creation of the event
        /// </summary>
        /// <value>The time of creation of the event</value>
        [DataMember(Name="CreateTime", EmitDefaultValue=false)]
        public DateTime? CreateTime { get; set; }

        /// <summary>
        /// Position
        /// </summary>
        /// <value>Position</value>
        [DataMember(Name="Position", EmitDefaultValue=false)]
        public int? Position { get; set; }

        /// <summary>
        /// App id
        /// </summary>
        /// <value>App id</value>
        [DataMember(Name="AppId", EmitDefaultValue=false)]
        public string AppId { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class OrderCreatedEvent {\n");
            sb.Append("  EventName: ").Append(EventName).Append("\n");
            sb.Append("  Description: ").Append(Description).Append("\n");
            sb.Append("  OrderCreatedTime: ").Append(OrderCreatedTime).Append("\n");
            sb.Append("  Order: ").Append(Order).Append("\n");
            sb.Append("  FlipdishEventId: ").Append(FlipdishEventId).Append("\n");
            sb.Append("  CreateTime: ").Append(CreateTime).Append("\n");
            sb.Append("  Position: ").Append(Position).Append("\n");
            sb.Append("  AppId: ").Append(AppId).Append("\n");
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
        public override bool Equals(object input) => Equals(input as OrderCreatedEvent);

        /// <summary>
        /// Returns true if OrderCreatedEvent instances are equal
        /// </summary>
        /// <param name="input">Instance of OrderCreatedEvent to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(OrderCreatedEvent input)
        {
            if (input == null)
                return false;

            return 
                (
                    EventName == input.EventName ||
                    (EventName != null &&
                    EventName.Equals(input.EventName))
                ) && 
                (
                    Description == input.Description ||
                    (Description != null &&
                    Description.Equals(input.Description))
                ) && 
                (
                    OrderCreatedTime == input.OrderCreatedTime ||
                    (OrderCreatedTime != null &&
                    OrderCreatedTime.Equals(input.OrderCreatedTime))
                ) && 
                (
                    Order == input.Order ||
                    (Order != null &&
                    Order.Equals(input.Order))
                ) && 
                (
                    FlipdishEventId == input.FlipdishEventId ||
                    (FlipdishEventId != null &&
                    FlipdishEventId.Equals(input.FlipdishEventId))
                ) && 
                (
                    CreateTime == input.CreateTime ||
                    (CreateTime != null &&
                    CreateTime.Equals(input.CreateTime))
                ) && 
                (
                    Position == input.Position ||
                    (Position != null &&
                    Position.Equals(input.Position))
                ) && 
                (
                    AppId == input.AppId ||
                    (AppId != null &&
                    AppId.Equals(input.AppId))
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
                if (EventName != null)
                    hashCode = hashCode * 59 + EventName.GetHashCode();
                if (Description != null)
                    hashCode = hashCode * 59 + Description.GetHashCode();
                if (OrderCreatedTime != null)
                    hashCode = hashCode * 59 + OrderCreatedTime.GetHashCode();
                if (Order != null)
                    hashCode = hashCode * 59 + Order.GetHashCode();
                if (FlipdishEventId != null)
                    hashCode = hashCode * 59 + FlipdishEventId.GetHashCode();
                if (CreateTime != null)
                    hashCode = hashCode * 59 + CreateTime.GetHashCode();
                if (Position != null)
                    hashCode = hashCode * 59 + Position.GetHashCode();
                if (AppId != null)
                    hashCode = hashCode * 59 + AppId.GetHashCode();
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
