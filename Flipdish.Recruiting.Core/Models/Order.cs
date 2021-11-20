using System;
using System.Linq;
using System.Text;
using System.Collections.Generic;
using System.Runtime.Serialization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System.ComponentModel.DataAnnotations;

namespace Flipdish.Recruiting.Core.Models
{
    /// <summary>
    /// Order
    /// </summary>
    [DataContract]
    public partial class Order :  IEquatable<Order>, IValidatableObject
    {
        /// <summary>
        /// Delivery type
        /// </summary>
        /// <value>Delivery type</value>
        [JsonConverter(typeof(StringEnumConverter))]
        public enum DeliveryTypeEnum
        {
            
            /// <summary>
            /// Enum Delivery for value: Delivery
            /// </summary>
            [EnumMember(Value = "Delivery")]
            Delivery = 1,
            
            /// <summary>
            /// Enum Pickup for value: Pickup
            /// </summary>
            [EnumMember(Value = "Pickup")]
            Pickup = 2
        }

        /// <summary>
        /// Delivery type
        /// </summary>
        /// <value>Delivery type</value>
        [DataMember(Name="DeliveryType", EmitDefaultValue=false)]
        public DeliveryTypeEnum? DeliveryType { get; set; }

        /// <summary>
        /// Pickup location type
        /// </summary>
        /// <value>Pickup location type</value>
        [JsonConverter(typeof(StringEnumConverter))]
        public enum PickupLocationTypeEnum
        {
            
            /// <summary>
            /// Enum TakeOut for value: TakeOut
            /// </summary>
            [EnumMember(Value = "TakeOut")]
            TakeOut = 1,
            
            /// <summary>
            /// Enum TableService for value: TableService
            /// </summary>
            [EnumMember(Value = "TableService")]
            TableService = 2,
            
            /// <summary>
            /// Enum DineIn for value: DineIn
            /// </summary>
            [EnumMember(Value = "DineIn")]
            DineIn = 3
        }

        /// <summary>
        /// Pickup location type
        /// </summary>
        /// <value>Pickup location type</value>
        [DataMember(Name="PickupLocationType", EmitDefaultValue=false)]
        public PickupLocationTypeEnum? PickupLocationType { get; set; }

        /// <summary>
        /// Pickup location type
        /// </summary>
        /// <value>Pickup location type</value>
        [JsonConverter(typeof(StringEnumConverter))]
        public enum TableServiceCatagoryEnum
        {
            
            /// <summary>
            /// Enum Generic for value: Generic
            /// </summary>
            [EnumMember(Value = "Generic")]
            Generic = 1,
            
            /// <summary>
            /// Enum Villa for value: Villa
            /// </summary>
            [EnumMember(Value = "Villa")]
            Villa = 2,
            
            /// <summary>
            /// Enum House for value: House
            /// </summary>
            [EnumMember(Value = "House")]
            House = 3,
            
            /// <summary>
            /// Enum Room for value: Room
            /// </summary>
            [EnumMember(Value = "Room")]
            Room = 4,
            
            /// <summary>
            /// Enum Area for value: Area
            /// </summary>
            [EnumMember(Value = "Area")]
            Area = 5,
            
            /// <summary>
            /// Enum Table for value: Table
            /// </summary>
            [EnumMember(Value = "Table")]
            Table = 6,
            
            /// <summary>
            /// Enum ParkingBay for value: ParkingBay
            /// </summary>
            [EnumMember(Value = "ParkingBay")]
            ParkingBay = 7,
            
            /// <summary>
            /// Enum Gate for value: Gate
            /// </summary>
            [EnumMember(Value = "Gate")]
            Gate = 8
        }

        /// <summary>
        /// Pickup location type
        /// </summary>
        /// <value>Pickup location type</value>
        [DataMember(Name="TableServiceCatagory", EmitDefaultValue=false)]
        public TableServiceCatagoryEnum? TableServiceCatagory { get; set; }

        /// <summary>
        /// Payment account type
        /// </summary>
        /// <value>Payment account type</value>
        [JsonConverter(typeof(StringEnumConverter))]
        public enum PaymentAccountTypeEnum
        {
            
            /// <summary>
            /// Enum Card for value: Card
            /// </summary>
            [EnumMember(Value = "Card")]
            Card = 1,
            
            /// <summary>
            /// Enum Cash for value: Cash
            /// </summary>
            [EnumMember(Value = "Cash")]
            Cash = 2,
            
            /// <summary>
            /// Enum Ideal for value: Ideal
            /// </summary>
            [EnumMember(Value = "Ideal")]
            Ideal = 3,
            
            /// <summary>
            /// Enum Bancontact for value: Bancontact
            /// </summary>
            [EnumMember(Value = "Bancontact")]
            Bancontact = 4,
            
            /// <summary>
            /// Enum Giropay for value: Giropay
            /// </summary>
            [EnumMember(Value = "Giropay")]
            Giropay = 5,
            
            /// <summary>
            /// Enum Eps for value: Eps
            /// </summary>
            [EnumMember(Value = "Eps")]
            Eps = 6,
            
            /// <summary>
            /// Enum Emv for value: Emv
            /// </summary>
            [EnumMember(Value = "Emv")]
            Emv = 7,
            
            /// <summary>
            /// Enum PayPal for value: PayPal
            /// </summary>
            [EnumMember(Value = "PayPal")]
            PayPal = 8
        }

        /// <summary>
        /// Payment account type
        /// </summary>
        /// <value>Payment account type</value>
        [DataMember(Name="PaymentAccountType", EmitDefaultValue=false)]
        public PaymentAccountTypeEnum? PaymentAccountType { get; set; }

        /// <summary>
        /// Order state
        /// </summary>
        /// <value>Order state</value>
        [JsonConverter(typeof(StringEnumConverter))]
        public enum OrderStateEnum
        {
            
            /// <summary>
            /// Enum Created for value: Created
            /// </summary>
            [EnumMember(Value = "Created")]
            Created = 1,
            
            /// <summary>
            /// Enum PlacedCanBeCancelled for value: PlacedCanBeCancelled
            /// </summary>
            [EnumMember(Value = "PlacedCanBeCancelled")]
            PlacedCanBeCancelled = 2,
            
            /// <summary>
            /// Enum ReadyToProcess for value: ReadyToProcess
            /// </summary>
            [EnumMember(Value = "ReadyToProcess")]
            ReadyToProcess = 3,
            
            /// <summary>
            /// Enum AcceptedByRestaurant for value: AcceptedByRestaurant
            /// </summary>
            [EnumMember(Value = "AcceptedByRestaurant")]
            AcceptedByRestaurant = 4,
            
            /// <summary>
            /// Enum Dispatched for value: Dispatched
            /// </summary>
            [EnumMember(Value = "Dispatched")]
            Dispatched = 5,
            
            /// <summary>
            /// Enum Delivered for value: Delivered
            /// </summary>
            [EnumMember(Value = "Delivered")]
            Delivered = 6,
            
            /// <summary>
            /// Enum Cancelled for value: Cancelled
            /// </summary>
            [EnumMember(Value = "Cancelled")]
            Cancelled = 7,
            
            /// <summary>
            /// Enum ManualReview for value: ManualReview
            /// </summary>
            [EnumMember(Value = "ManualReview")]
            ManualReview = 8,
            
            /// <summary>
            /// Enum RejectedByStore for value: RejectedByStore
            /// </summary>
            [EnumMember(Value = "RejectedByStore")]
            RejectedByStore = 9,
            
            /// <summary>
            /// Enum RejectedByFlipdish for value: RejectedByFlipdish
            /// </summary>
            [EnumMember(Value = "RejectedByFlipdish")]
            RejectedByFlipdish = 10,
            
            /// <summary>
            /// Enum RejectedAutomatically for value: RejectedAutomatically
            /// </summary>
            [EnumMember(Value = "RejectedAutomatically")]
            RejectedAutomatically = 11,
            
            /// <summary>
            /// Enum RejectedAfterBeingAccepted for value: RejectedAfterBeingAccepted
            /// </summary>
            [EnumMember(Value = "RejectedAfterBeingAccepted")]
            RejectedAfterBeingAccepted = 12,
            
            /// <summary>
            /// Enum AcceptedAndRefunded for value: AcceptedAndRefunded
            /// </summary>
            [EnumMember(Value = "AcceptedAndRefunded")]
            AcceptedAndRefunded = 13
        }

        /// <summary>
        /// Order state
        /// </summary>
        /// <value>Order state</value>
        [DataMember(Name="OrderState", EmitDefaultValue=false)]
        public OrderStateEnum? OrderState { get; set; }

        /// <summary>
        /// Used app type
        /// </summary>
        /// <value>Used app type</value>
        [JsonConverter(typeof(StringEnumConverter))]
        public enum AppTypeEnum
        {
            
            /// <summary>
            /// Enum Unknown for value: Unknown
            /// </summary>
            [EnumMember(Value = "Unknown")]
            Unknown = 1,
            
            /// <summary>
            /// Enum Ios for value: Ios
            /// </summary>
            [EnumMember(Value = "Ios")]
            Ios = 2,
            
            /// <summary>
            /// Enum Android for value: Android
            /// </summary>
            [EnumMember(Value = "Android")]
            Android = 3,
            
            /// <summary>
            /// Enum Web for value: Web
            /// </summary>
            [EnumMember(Value = "Web")]
            Web = 4,
            
            /// <summary>
            /// Enum Kiosk for value: Kiosk
            /// </summary>
            [EnumMember(Value = "Kiosk")]
            Kiosk = 5,
            
            /// <summary>
            /// Enum Pos for value: Pos
            /// </summary>
            [EnumMember(Value = "Pos")]
            Pos = 6,
            
            /// <summary>
            /// Enum TelephoneCall for value: TelephoneCall
            /// </summary>
            [EnumMember(Value = "TelephoneCall")]
            TelephoneCall = 7,
            
            /// <summary>
            /// Enum Sms for value: Sms
            /// </summary>
            [EnumMember(Value = "Sms")]
            Sms = 8,
            
            /// <summary>
            /// Enum PwaAndroid for value: PwaAndroid
            /// </summary>
            [EnumMember(Value = "PwaAndroid")]
            PwaAndroid = 9,
            
            /// <summary>
            /// Enum PwaIos for value: PwaIos
            /// </summary>
            [EnumMember(Value = "PwaIos")]
            PwaIos = 10
        }

        /// <summary>
        /// Used app type
        /// </summary>
        /// <value>Used app type</value>
        [DataMember(Name="AppType", EmitDefaultValue=false)]
        public AppTypeEnum? AppType { get; set; }

        /// <summary>
        /// Status of the payment
        /// </summary>
        /// <value>Status of the payment</value>
        [JsonConverter(typeof(StringEnumConverter))]
        public enum PaymentStatusEnum
        {
            
            /// <summary>
            /// Enum Paid for value: Paid
            /// </summary>
            [EnumMember(Value = "Paid")]
            Paid = 1,
            
            /// <summary>
            /// Enum Unpaid for value: Unpaid
            /// </summary>
            [EnumMember(Value = "Unpaid")]
            Unpaid = 2,
            
            /// <summary>
            /// Enum Refunded for value: Refunded
            /// </summary>
            [EnumMember(Value = "Refunded")]
            Refunded = 3,
            
            /// <summary>
            /// Enum PartiallyRefunded for value: PartiallyRefunded
            /// </summary>
            [EnumMember(Value = "PartiallyRefunded")]
            PartiallyRefunded = 4,
            
            /// <summary>
            /// Enum Disputed for value: Disputed
            /// </summary>
            [EnumMember(Value = "Disputed")]
            Disputed = 5
        }

        /// <summary>
        /// Status of the payment
        /// </summary>
        /// <value>Status of the payment</value>
        [DataMember(Name="PaymentStatus", EmitDefaultValue=false)]
        public PaymentStatusEnum? PaymentStatus { get; set; }

        /// <summary>
        /// Rejection reason. Can have value if the order is rejected.
        /// </summary>
        /// <value>Rejection reason. Can have value if the order is rejected.</value>
        [JsonConverter(typeof(StringEnumConverter))]
        public enum RejectionReasonEnum
        {
            
            /// <summary>
            /// Enum TooBusy for value: TooBusy
            /// </summary>
            [EnumMember(Value = "TooBusy")]
            TooBusy = 1,
            
            /// <summary>
            /// Enum FoodUnavailable for value: FoodUnavailable
            /// </summary>
            [EnumMember(Value = "FoodUnavailable")]
            FoodUnavailable = 2,
            
            /// <summary>
            /// Enum UnableToDeliver for value: UnableToDeliver
            /// </summary>
            [EnumMember(Value = "UnableToDeliver")]
            UnableToDeliver = 3,
            
            /// <summary>
            /// Enum UnknownAddress for value: UnknownAddress
            /// </summary>
            [EnumMember(Value = "UnknownAddress")]
            UnknownAddress = 4,
            
            /// <summary>
            /// Enum UnknownReason for value: UnknownReason
            /// </summary>
            [EnumMember(Value = "UnknownReason")]
            UnknownReason = 5,
            
            /// <summary>
            /// Enum TooSoon for value: TooSoon
            /// </summary>
            [EnumMember(Value = "TooSoon")]
            TooSoon = 6,
            
            /// <summary>
            /// Enum TimeUnavailable for value: TimeUnavailable
            /// </summary>
            [EnumMember(Value = "TimeUnavailable")]
            TimeUnavailable = 7,
            
            /// <summary>
            /// Enum DontDeliverToArea for value: DontDeliverToArea
            /// </summary>
            [EnumMember(Value = "DontDeliverToArea")]
            DontDeliverToArea = 8,
            
            /// <summary>
            /// Enum StoreUncontactable for value: StoreUncontactable
            /// </summary>
            [EnumMember(Value = "StoreUncontactable")]
            StoreUncontactable = 9
        }

        /// <summary>
        /// Rejection reason. Can have value if the order is rejected.
        /// </summary>
        /// <value>Rejection reason. Can have value if the order is rejected.</value>
        [DataMember(Name="RejectionReason", EmitDefaultValue=false)]
        public RejectionReasonEnum? RejectionReason { get; set; }

        /// <summary>
        /// Delivery tracking status
        /// </summary>
        /// <value>Delivery tracking status</value>
        [JsonConverter(typeof(StringEnumConverter))]
        public enum DeliveryTrackingStatusEnum
        {
            
            /// <summary>
            /// Enum Unassigned for value: Unassigned
            /// </summary>
            [EnumMember(Value = "Unassigned")]
            Unassigned = 1,
            
            /// <summary>
            /// Enum Unaccepted for value: Unaccepted
            /// </summary>
            [EnumMember(Value = "Unaccepted")]
            Unaccepted = 2,
            
            /// <summary>
            /// Enum Accepted for value: Accepted
            /// </summary>
            [EnumMember(Value = "Accepted")]
            Accepted = 3,
            
            /// <summary>
            /// Enum Carrying for value: Carrying
            /// </summary>
            [EnumMember(Value = "Carrying")]
            Carrying = 4,
            
            /// <summary>
            /// Enum OnTheWay for value: OnTheWay
            /// </summary>
            [EnumMember(Value = "OnTheWay")]
            OnTheWay = 5,
            
            /// <summary>
            /// Enum ArrivedAtLocation for value: ArrivedAtLocation
            /// </summary>
            [EnumMember(Value = "ArrivedAtLocation")]
            ArrivedAtLocation = 6,
            
            /// <summary>
            /// Enum Delivered for value: Delivered
            /// </summary>
            [EnumMember(Value = "Delivered")]
            Delivered = 7,
            
            /// <summary>
            /// Enum CannotDeliver for value: CannotDeliver
            /// </summary>
            [EnumMember(Value = "CannotDeliver")]
            CannotDeliver = 8
        }

        /// <summary>
        /// Delivery tracking status
        /// </summary>
        /// <value>Delivery tracking status</value>
        [DataMember(Name="DeliveryTrackingStatus", EmitDefaultValue=false)]
        public DeliveryTrackingStatusEnum? DeliveryTrackingStatus { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="Order" /> class.
        /// </summary>
        /// <param name="store">Store summary.</param>
        /// <param name="customer">Customer summary.</param>
        /// <param name="voucher">Voucher summary.</param>
        /// <param name="fees">Fee summary.</param>
        /// <param name="orderItems">Ordered items.</param>
        /// <param name="deliveryLocation">Delivery location for delivery orders.</param>
        /// <param name="customerLocation">Customer location.</param>
        /// <param name="maskedPhoneNumber">Represents customers masked phone number.</param>
        /// <param name="dropOffLocationId">Represents table service drop off location.</param>
        /// <param name="dropOffLocation">Represents table service drop off location.</param>
        /// <param name="acceptedFor">Time store has accepted the order for.</param>
        /// <param name="inFraudZone">Was order made within a fraud zone.</param>
        /// <param name="unusualHighValueOrder">Is order of unusually high value.</param>
        /// <param name="rejectedByUserId">Id of user who rejected order, if available.</param>
        /// <param name="orderId">Order identifier.</param>
        /// <param name="localOrderId">Local order Id. This is used for displaying a \&quot;shorter\&quot; order ID for customers (eg. Kiosk orders).</param>
        /// <param name="deliveryType">Delivery type.</param>
        /// <param name="pickupLocationType">Pickup location type.</param>
        /// <param name="tableServiceCatagory">Pickup location type.</param>
        /// <param name="tipAmount">Tip amount.</param>
        /// <param name="deliveryAmount">Delivery amount.</param>
        /// <param name="orderItemsAmount">Ordered items amount.</param>
        /// <param name="amount">This is the sum of the OrderItemsAmount, DeliveryAmount, TipAmount and Voucher.Amount (which is usually negative) and OnlineOrderingFee for cash orders.  It does not include the OnlineOrderingFee in the case of card orders as this fee is charged by Flipdish directly to the customer..</param>
        /// <param name="processingFee">This contains the online ordering processing fee. For card payments this is charged directly to the customer and for cash orders it is paid by the customer to the store. It is tax inclusive..</param>
        /// <param name="paymentAccountType">Payment account type.</param>
        /// <param name="paymentAccountDescription">Payment account description (like Visa ****2371 or Apple Pay. or Cash).</param>
        /// <param name="orderState">Order state.</param>
        /// <param name="isPreOrder">Is pre-order.</param>
        /// <param name="placedTime">Order placed time.</param>
        /// <param name="requestedForTime">Order requested for.</param>
        /// <param name="chefNote">Chef note.</param>
        /// <param name="appType">Used app type.</param>
        /// <param name="userRating">User rating.</param>
        /// <param name="paymentStatus">Status of the payment.</param>
        /// <param name="rejectionReason">Rejection reason. Can have value if the order is rejected..</param>
        /// <param name="refundedAmount">Amount refunded to customer..</param>
        /// <param name="deliveryTrackingStatus">Delivery tracking status.</param>
        /// <param name="driverId">Assigned driver identifier.</param>
        /// <param name="totalTax">Total tax applied to order.</param>
        /// <param name="orderTrackingCode">Unique, 6 character long alpha numeric code for tracking..</param>
        public Order(StoreSummary store = default, CustomerSummary customer = default, OrderVoucherSummary voucher = default, FeeSummary fees = default, List<OrderItem> orderItems = default, DeliveryLocation deliveryLocation = default, Coordinates customerLocation = default, MaskedPhoneNumber maskedPhoneNumber = default, int? dropOffLocationId = default, string dropOffLocation = default, DateTime? acceptedFor = default, bool? inFraudZone = default, bool? unusualHighValueOrder = default, int? rejectedByUserId = default, int? orderId = default, string localOrderId = default, DeliveryTypeEnum? deliveryType = default, PickupLocationTypeEnum? pickupLocationType = default, TableServiceCatagoryEnum? tableServiceCatagory = default, double? tipAmount = default, double? deliveryAmount = default, double? orderItemsAmount = default, double? amount = default, double? processingFee = default, PaymentAccountTypeEnum? paymentAccountType = default, string paymentAccountDescription = default, OrderStateEnum? orderState = default, bool? isPreOrder = default, DateTime? placedTime = default, DateTime? requestedForTime = default, string chefNote = default, AppTypeEnum? appType = default, int? userRating = default, PaymentStatusEnum? paymentStatus = default, RejectionReasonEnum? rejectionReason = default, double? refundedAmount = default, DeliveryTrackingStatusEnum? deliveryTrackingStatus = default, int? driverId = default, double? totalTax = default, string orderTrackingCode = default)
        {
            Store = store;
            Customer = customer;
            Voucher = voucher;
            Fees = fees;
            OrderItems = orderItems;
            DeliveryLocation = deliveryLocation;
            CustomerLocation = customerLocation;
            MaskedPhoneNumber = maskedPhoneNumber;
            DropOffLocationId = dropOffLocationId;
            DropOffLocation = dropOffLocation;
            AcceptedFor = acceptedFor;
            InFraudZone = inFraudZone;
            UnusualHighValueOrder = unusualHighValueOrder;
            RejectedByUserId = rejectedByUserId;
            OrderId = orderId;
            LocalOrderId = localOrderId;
            DeliveryType = deliveryType;
            PickupLocationType = pickupLocationType;
            TableServiceCatagory = tableServiceCatagory;
            TipAmount = tipAmount;
            DeliveryAmount = deliveryAmount;
            OrderItemsAmount = orderItemsAmount;
            Amount = amount;
            ProcessingFee = processingFee;
            PaymentAccountType = paymentAccountType;
            PaymentAccountDescription = paymentAccountDescription;
            OrderState = orderState;
            IsPreOrder = isPreOrder;
            PlacedTime = placedTime;
            RequestedForTime = requestedForTime;
            ChefNote = chefNote;
            AppType = appType;
            UserRating = userRating;
            PaymentStatus = paymentStatus;
            RejectionReason = rejectionReason;
            RefundedAmount = refundedAmount;
            DeliveryTrackingStatus = deliveryTrackingStatus;
            DriverId = driverId;
            TotalTax = totalTax;
            OrderTrackingCode = orderTrackingCode;
        }
        
        /// <summary>
        /// Store summary
        /// </summary>
        /// <value>Store summary</value>
        [DataMember(Name="Store", EmitDefaultValue=false)]
        public StoreSummary Store { get; set; }

        /// <summary>
        /// Customer summary
        /// </summary>
        /// <value>Customer summary</value>
        [DataMember(Name="Customer", EmitDefaultValue=false)]
        public CustomerSummary Customer { get; set; }

        /// <summary>
        /// Voucher summary
        /// </summary>
        /// <value>Voucher summary</value>
        [DataMember(Name="Voucher", EmitDefaultValue=false)]
        public OrderVoucherSummary Voucher { get; set; }

        /// <summary>
        /// Fee summary
        /// </summary>
        /// <value>Fee summary</value>
        [DataMember(Name="Fees", EmitDefaultValue=false)]
        public FeeSummary Fees { get; set; }

        /// <summary>
        /// Ordered items
        /// </summary>
        /// <value>Ordered items</value>
        [DataMember(Name="OrderItems", EmitDefaultValue=false)]
        public List<OrderItem> OrderItems { get; set; }

        /// <summary>
        /// Delivery location for delivery orders
        /// </summary>
        /// <value>Delivery location for delivery orders</value>
        [DataMember(Name="DeliveryLocation", EmitDefaultValue=false)]
        public DeliveryLocation DeliveryLocation { get; set; }

        /// <summary>
        /// Customer location
        /// </summary>
        /// <value>Customer location</value>
        [DataMember(Name="CustomerLocation", EmitDefaultValue=false)]
        public Coordinates CustomerLocation { get; set; }

        /// <summary>
        /// Represents customers masked phone number
        /// </summary>
        /// <value>Represents customers masked phone number</value>
        [DataMember(Name="MaskedPhoneNumber", EmitDefaultValue=false)]
        public MaskedPhoneNumber MaskedPhoneNumber { get; set; }

        /// <summary>
        /// Represents table service drop off location
        /// </summary>
        /// <value>Represents table service drop off location</value>
        [DataMember(Name="DropOffLocationId", EmitDefaultValue=false)]
        public int? DropOffLocationId { get; set; }

        /// <summary>
        /// Represents table service drop off location
        /// </summary>
        /// <value>Represents table service drop off location</value>
        [DataMember(Name="DropOffLocation", EmitDefaultValue=false)]
        public string DropOffLocation { get; set; }

        /// <summary>
        /// Time store has accepted the order for
        /// </summary>
        /// <value>Time store has accepted the order for</value>
        [DataMember(Name="AcceptedFor", EmitDefaultValue=false)]
        public DateTime? AcceptedFor { get; set; }

        /// <summary>
        /// Was order made within a fraud zone
        /// </summary>
        /// <value>Was order made within a fraud zone</value>
        [DataMember(Name="InFraudZone", EmitDefaultValue=false)]
        public bool? InFraudZone { get; set; }

        /// <summary>
        /// Is order of unusually high value
        /// </summary>
        /// <value>Is order of unusually high value</value>
        [DataMember(Name="UnusualHighValueOrder", EmitDefaultValue=false)]
        public bool? UnusualHighValueOrder { get; set; }

        /// <summary>
        /// Id of user who rejected order, if available
        /// </summary>
        /// <value>Id of user who rejected order, if available</value>
        [DataMember(Name="RejectedByUserId", EmitDefaultValue=false)]
        public int? RejectedByUserId { get; set; }

        /// <summary>
        /// Order identifier
        /// </summary>
        /// <value>Order identifier</value>
        [DataMember(Name="OrderId", EmitDefaultValue=false)]
        public int? OrderId { get; set; }

        /// <summary>
        /// Local order Id. This is used for displaying a \&quot;shorter\&quot; order ID for customers (eg. Kiosk orders)
        /// </summary>
        /// <value>Local order Id. This is used for displaying a \&quot;shorter\&quot; order ID for customers (eg. Kiosk orders)</value>
        [DataMember(Name="LocalOrderId", EmitDefaultValue=false)]
        public string LocalOrderId { get; set; }

        /// <summary>
        /// Tip amount
        /// </summary>
        /// <value>Tip amount</value>
        [DataMember(Name="TipAmount", EmitDefaultValue=false)]
        public double? TipAmount { get; set; }

        /// <summary>
        /// Delivery amount
        /// </summary>
        /// <value>Delivery amount</value>
        [DataMember(Name="DeliveryAmount", EmitDefaultValue=false)]
        public double? DeliveryAmount { get; set; }

        /// <summary>
        /// Ordered items amount
        /// </summary>
        /// <value>Ordered items amount</value>
        [DataMember(Name="OrderItemsAmount", EmitDefaultValue=false)]
        public double? OrderItemsAmount { get; set; }

        /// <summary>
        /// This is the sum of the OrderItemsAmount, DeliveryAmount, TipAmount and Voucher.Amount (which is usually negative) and OnlineOrderingFee for cash orders.  It does not include the OnlineOrderingFee in the case of card orders as this fee is charged by Flipdish directly to the customer.
        /// </summary>
        /// <value>This is the sum of the OrderItemsAmount, DeliveryAmount, TipAmount and Voucher.Amount (which is usually negative) and OnlineOrderingFee for cash orders.  It does not include the OnlineOrderingFee in the case of card orders as this fee is charged by Flipdish directly to the customer.</value>
        [DataMember(Name="Amount", EmitDefaultValue=false)]
        public double? Amount { get; set; }

        /// <summary>
        /// This contains the online ordering processing fee. For card payments this is charged directly to the customer and for cash orders it is paid by the customer to the store. It is tax inclusive.
        /// </summary>
        /// <value>This contains the online ordering processing fee. For card payments this is charged directly to the customer and for cash orders it is paid by the customer to the store. It is tax inclusive.</value>
        [DataMember(Name="ProcessingFee", EmitDefaultValue=false)]
        public double? ProcessingFee { get; set; }


        /// <summary>
        /// Payment account description (like Visa ****2371 or Apple Pay. or Cash)
        /// </summary>
        /// <value>Payment account description (like Visa ****2371 or Apple Pay. or Cash)</value>
        [DataMember(Name="PaymentAccountDescription", EmitDefaultValue=false)]
        public string PaymentAccountDescription { get; set; }


        /// <summary>
        /// Is pre-order
        /// </summary>
        /// <value>Is pre-order</value>
        [DataMember(Name="IsPreOrder", EmitDefaultValue=false)]
        public bool? IsPreOrder { get; set; }

        /// <summary>
        /// Order placed time
        /// </summary>
        /// <value>Order placed time</value>
        [DataMember(Name="PlacedTime", EmitDefaultValue=false)]
        public DateTime? PlacedTime { get; set; }

        /// <summary>
        /// Order requested for
        /// </summary>
        /// <value>Order requested for</value>
        [DataMember(Name="RequestedForTime", EmitDefaultValue=false)]
        public DateTime? RequestedForTime { get; set; }

        /// <summary>
        /// Chef note
        /// </summary>
        /// <value>Chef note</value>
        [DataMember(Name="ChefNote", EmitDefaultValue=false)]
        public string ChefNote { get; set; }

        /// <summary>
        /// User rating
        /// </summary>
        /// <value>User rating</value>
        [DataMember(Name="UserRating", EmitDefaultValue=false)]
        public int? UserRating { get; set; }

        /// <summary>
        /// Amount refunded to customer.
        /// </summary>
        /// <value>Amount refunded to customer.</value>
        [DataMember(Name="RefundedAmount", EmitDefaultValue=false)]
        public double? RefundedAmount { get; set; }

        /// <summary>
        /// Assigned driver identifier
        /// </summary>
        /// <value>Assigned driver identifier</value>
        [DataMember(Name="DriverId", EmitDefaultValue=false)]
        public int? DriverId { get; set; }

        /// <summary>
        /// Total tax applied to order
        /// </summary>
        /// <value>Total tax applied to order</value>
        [DataMember(Name="TotalTax", EmitDefaultValue=false)]
        public double? TotalTax { get; set; }

        /// <summary>
        /// Unique, 6 character long alpha numeric code for tracking.
        /// </summary>
        /// <value>Unique, 6 character long alpha numeric code for tracking.</value>
        [DataMember(Name="OrderTrackingCode", EmitDefaultValue=false)]
        public string OrderTrackingCode { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class Order {\n");
            sb.Append("  Store: ").Append(Store).Append("\n");
            sb.Append("  Customer: ").Append(Customer).Append("\n");
            sb.Append("  Voucher: ").Append(Voucher).Append("\n");
            sb.Append("  Fees: ").Append(Fees).Append("\n");
            sb.Append("  OrderItems: ").Append(OrderItems).Append("\n");
            sb.Append("  DeliveryLocation: ").Append(DeliveryLocation).Append("\n");
            sb.Append("  CustomerLocation: ").Append(CustomerLocation).Append("\n");
            sb.Append("  MaskedPhoneNumber: ").Append(MaskedPhoneNumber).Append("\n");
            sb.Append("  DropOffLocationId: ").Append(DropOffLocationId).Append("\n");
            sb.Append("  DropOffLocation: ").Append(DropOffLocation).Append("\n");
            sb.Append("  AcceptedFor: ").Append(AcceptedFor).Append("\n");
            sb.Append("  InFraudZone: ").Append(InFraudZone).Append("\n");
            sb.Append("  UnusualHighValueOrder: ").Append(UnusualHighValueOrder).Append("\n");
            sb.Append("  RejectedByUserId: ").Append(RejectedByUserId).Append("\n");
            sb.Append("  OrderId: ").Append(OrderId).Append("\n");
            sb.Append("  LocalOrderId: ").Append(LocalOrderId).Append("\n");
            sb.Append("  DeliveryType: ").Append(DeliveryType).Append("\n");
            sb.Append("  PickupLocationType: ").Append(PickupLocationType).Append("\n");
            sb.Append("  TableServiceCatagory: ").Append(TableServiceCatagory).Append("\n");
            sb.Append("  TipAmount: ").Append(TipAmount).Append("\n");
            sb.Append("  DeliveryAmount: ").Append(DeliveryAmount).Append("\n");
            sb.Append("  OrderItemsAmount: ").Append(OrderItemsAmount).Append("\n");
            sb.Append("  Amount: ").Append(Amount).Append("\n");
            sb.Append("  ProcessingFee: ").Append(ProcessingFee).Append("\n");
            sb.Append("  PaymentAccountType: ").Append(PaymentAccountType).Append("\n");
            sb.Append("  PaymentAccountDescription: ").Append(PaymentAccountDescription).Append("\n");
            sb.Append("  OrderState: ").Append(OrderState).Append("\n");
            sb.Append("  IsPreOrder: ").Append(IsPreOrder).Append("\n");
            sb.Append("  PlacedTime: ").Append(PlacedTime).Append("\n");
            sb.Append("  RequestedForTime: ").Append(RequestedForTime).Append("\n");
            sb.Append("  ChefNote: ").Append(ChefNote).Append("\n");
            sb.Append("  AppType: ").Append(AppType).Append("\n");
            sb.Append("  UserRating: ").Append(UserRating).Append("\n");
            sb.Append("  PaymentStatus: ").Append(PaymentStatus).Append("\n");
            sb.Append("  RejectionReason: ").Append(RejectionReason).Append("\n");
            sb.Append("  RefundedAmount: ").Append(RefundedAmount).Append("\n");
            sb.Append("  DeliveryTrackingStatus: ").Append(DeliveryTrackingStatus).Append("\n");
            sb.Append("  DriverId: ").Append(DriverId).Append("\n");
            sb.Append("  TotalTax: ").Append(TotalTax).Append("\n");
            sb.Append("  OrderTrackingCode: ").Append(OrderTrackingCode).Append("\n");
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
        public override bool Equals(object input) => Equals(input as Order);

        /// <summary>
        /// Returns true if Order instances are equal
        /// </summary>
        /// <param name="input">Instance of Order to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(Order input)
        {
            if (input == null)
                return false;

            return 
                (
                    Store == input.Store ||
                    (Store != null &&
                    Store.Equals(input.Store))
                ) && 
                (
                    Customer == input.Customer ||
                    (Customer != null &&
                    Customer.Equals(input.Customer))
                ) && 
                (
                    Voucher == input.Voucher ||
                    (Voucher != null &&
                    Voucher.Equals(input.Voucher))
                ) && 
                (
                    Fees == input.Fees ||
                    (Fees != null &&
                    Fees.Equals(input.Fees))
                ) && 
                (
                    OrderItems == input.OrderItems ||
                    OrderItems != null &&
                    OrderItems.SequenceEqual(input.OrderItems)
                ) && 
                (
                    DeliveryLocation == input.DeliveryLocation ||
                    (DeliveryLocation != null &&
                    DeliveryLocation.Equals(input.DeliveryLocation))
                ) && 
                (
                    CustomerLocation == input.CustomerLocation ||
                    (CustomerLocation != null &&
                    CustomerLocation.Equals(input.CustomerLocation))
                ) && 
                (
                    MaskedPhoneNumber == input.MaskedPhoneNumber ||
                    (MaskedPhoneNumber != null &&
                    MaskedPhoneNumber.Equals(input.MaskedPhoneNumber))
                ) && 
                (
                    DropOffLocationId == input.DropOffLocationId ||
                    (DropOffLocationId != null &&
                    DropOffLocationId.Equals(input.DropOffLocationId))
                ) && 
                (
                    DropOffLocation == input.DropOffLocation ||
                    (DropOffLocation != null &&
                    DropOffLocation.Equals(input.DropOffLocation))
                ) && 
                (
                    AcceptedFor == input.AcceptedFor ||
                    (AcceptedFor != null &&
                    AcceptedFor.Equals(input.AcceptedFor))
                ) && 
                (
                    InFraudZone == input.InFraudZone ||
                    (InFraudZone != null &&
                    InFraudZone.Equals(input.InFraudZone))
                ) && 
                (
                    UnusualHighValueOrder == input.UnusualHighValueOrder ||
                    (UnusualHighValueOrder != null &&
                    UnusualHighValueOrder.Equals(input.UnusualHighValueOrder))
                ) && 
                (
                    RejectedByUserId == input.RejectedByUserId ||
                    (RejectedByUserId != null &&
                    RejectedByUserId.Equals(input.RejectedByUserId))
                ) && 
                (
                    OrderId == input.OrderId ||
                    (OrderId != null &&
                    OrderId.Equals(input.OrderId))
                ) && 
                (
                    LocalOrderId == input.LocalOrderId ||
                    (LocalOrderId != null &&
                    LocalOrderId.Equals(input.LocalOrderId))
                ) && 
                (
                    DeliveryType == input.DeliveryType ||
                    (DeliveryType != null &&
                    DeliveryType.Equals(input.DeliveryType))
                ) && 
                (
                    PickupLocationType == input.PickupLocationType ||
                    (PickupLocationType != null &&
                    PickupLocationType.Equals(input.PickupLocationType))
                ) && 
                (
                    TableServiceCatagory == input.TableServiceCatagory ||
                    (TableServiceCatagory != null &&
                    TableServiceCatagory.Equals(input.TableServiceCatagory))
                ) && 
                (
                    TipAmount == input.TipAmount ||
                    (TipAmount != null &&
                    TipAmount.Equals(input.TipAmount))
                ) && 
                (
                    DeliveryAmount == input.DeliveryAmount ||
                    (DeliveryAmount != null &&
                    DeliveryAmount.Equals(input.DeliveryAmount))
                ) && 
                (
                    OrderItemsAmount == input.OrderItemsAmount ||
                    (OrderItemsAmount != null &&
                    OrderItemsAmount.Equals(input.OrderItemsAmount))
                ) && 
                (
                    Amount == input.Amount ||
                    (Amount != null &&
                    Amount.Equals(input.Amount))
                ) && 
                (
                    ProcessingFee == input.ProcessingFee ||
                    (ProcessingFee != null &&
                    ProcessingFee.Equals(input.ProcessingFee))
                ) && 
                (
                    PaymentAccountType == input.PaymentAccountType ||
                    (PaymentAccountType != null &&
                    PaymentAccountType.Equals(input.PaymentAccountType))
                ) && 
                (
                    PaymentAccountDescription == input.PaymentAccountDescription ||
                    (PaymentAccountDescription != null &&
                    PaymentAccountDescription.Equals(input.PaymentAccountDescription))
                ) && 
                (
                    OrderState == input.OrderState ||
                    (OrderState != null &&
                    OrderState.Equals(input.OrderState))
                ) && 
                (
                    IsPreOrder == input.IsPreOrder ||
                    (IsPreOrder != null &&
                    IsPreOrder.Equals(input.IsPreOrder))
                ) && 
                (
                    PlacedTime == input.PlacedTime ||
                    (PlacedTime != null &&
                    PlacedTime.Equals(input.PlacedTime))
                ) && 
                (
                    RequestedForTime == input.RequestedForTime ||
                    (RequestedForTime != null &&
                    RequestedForTime.Equals(input.RequestedForTime))
                ) && 
                (
                    ChefNote == input.ChefNote ||
                    (ChefNote != null &&
                    ChefNote.Equals(input.ChefNote))
                ) && 
                (
                    AppType == input.AppType ||
                    (AppType != null &&
                    AppType.Equals(input.AppType))
                ) && 
                (
                    UserRating == input.UserRating ||
                    (UserRating != null &&
                    UserRating.Equals(input.UserRating))
                ) && 
                (
                    PaymentStatus == input.PaymentStatus ||
                    (PaymentStatus != null &&
                    PaymentStatus.Equals(input.PaymentStatus))
                ) && 
                (
                    RejectionReason == input.RejectionReason ||
                    (RejectionReason != null &&
                    RejectionReason.Equals(input.RejectionReason))
                ) && 
                (
                    RefundedAmount == input.RefundedAmount ||
                    (RefundedAmount != null &&
                    RefundedAmount.Equals(input.RefundedAmount))
                ) && 
                (
                    DeliveryTrackingStatus == input.DeliveryTrackingStatus ||
                    (DeliveryTrackingStatus != null &&
                    DeliveryTrackingStatus.Equals(input.DeliveryTrackingStatus))
                ) && 
                (
                    DriverId == input.DriverId ||
                    (DriverId != null &&
                    DriverId.Equals(input.DriverId))
                ) && 
                (
                    TotalTax == input.TotalTax ||
                    (TotalTax != null &&
                    TotalTax.Equals(input.TotalTax))
                ) && 
                (
                    OrderTrackingCode == input.OrderTrackingCode ||
                    (OrderTrackingCode != null &&
                    OrderTrackingCode.Equals(input.OrderTrackingCode))
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
                if (Store != null)
                    hashCode = hashCode * 59 + Store.GetHashCode();
                if (Customer != null)
                    hashCode = hashCode * 59 + Customer.GetHashCode();
                if (Voucher != null)
                    hashCode = hashCode * 59 + Voucher.GetHashCode();
                if (Fees != null)
                    hashCode = hashCode * 59 + Fees.GetHashCode();
                if (OrderItems != null)
                    hashCode = hashCode * 59 + OrderItems.GetHashCode();
                if (DeliveryLocation != null)
                    hashCode = hashCode * 59 + DeliveryLocation.GetHashCode();
                if (CustomerLocation != null)
                    hashCode = hashCode * 59 + CustomerLocation.GetHashCode();
                if (MaskedPhoneNumber != null)
                    hashCode = hashCode * 59 + MaskedPhoneNumber.GetHashCode();
                if (DropOffLocationId != null)
                    hashCode = hashCode * 59 + DropOffLocationId.GetHashCode();
                if (DropOffLocation != null)
                    hashCode = hashCode * 59 + DropOffLocation.GetHashCode();
                if (AcceptedFor != null)
                    hashCode = hashCode * 59 + AcceptedFor.GetHashCode();
                if (InFraudZone != null)
                    hashCode = hashCode * 59 + InFraudZone.GetHashCode();
                if (UnusualHighValueOrder != null)
                    hashCode = hashCode * 59 + UnusualHighValueOrder.GetHashCode();
                if (RejectedByUserId != null)
                    hashCode = hashCode * 59 + RejectedByUserId.GetHashCode();
                if (OrderId != null)
                    hashCode = hashCode * 59 + OrderId.GetHashCode();
                if (LocalOrderId != null)
                    hashCode = hashCode * 59 + LocalOrderId.GetHashCode();
                if (DeliveryType != null)
                    hashCode = hashCode * 59 + DeliveryType.GetHashCode();
                if (PickupLocationType != null)
                    hashCode = hashCode * 59 + PickupLocationType.GetHashCode();
                if (TableServiceCatagory != null)
                    hashCode = hashCode * 59 + TableServiceCatagory.GetHashCode();
                if (TipAmount != null)
                    hashCode = hashCode * 59 + TipAmount.GetHashCode();
                if (DeliveryAmount != null)
                    hashCode = hashCode * 59 + DeliveryAmount.GetHashCode();
                if (OrderItemsAmount != null)
                    hashCode = hashCode * 59 + OrderItemsAmount.GetHashCode();
                if (Amount != null)
                    hashCode = hashCode * 59 + Amount.GetHashCode();
                if (ProcessingFee != null)
                    hashCode = hashCode * 59 + ProcessingFee.GetHashCode();
                if (PaymentAccountType != null)
                    hashCode = hashCode * 59 + PaymentAccountType.GetHashCode();
                if (PaymentAccountDescription != null)
                    hashCode = hashCode * 59 + PaymentAccountDescription.GetHashCode();
                if (OrderState != null)
                    hashCode = hashCode * 59 + OrderState.GetHashCode();
                if (IsPreOrder != null)
                    hashCode = hashCode * 59 + IsPreOrder.GetHashCode();
                if (PlacedTime != null)
                    hashCode = hashCode * 59 + PlacedTime.GetHashCode();
                if (RequestedForTime != null)
                    hashCode = hashCode * 59 + RequestedForTime.GetHashCode();
                if (ChefNote != null)
                    hashCode = hashCode * 59 + ChefNote.GetHashCode();
                if (AppType != null)
                    hashCode = hashCode * 59 + AppType.GetHashCode();
                if (UserRating != null)
                    hashCode = hashCode * 59 + UserRating.GetHashCode();
                if (PaymentStatus != null)
                    hashCode = hashCode * 59 + PaymentStatus.GetHashCode();
                if (RejectionReason != null)
                    hashCode = hashCode * 59 + RejectionReason.GetHashCode();
                if (RefundedAmount != null)
                    hashCode = hashCode * 59 + RefundedAmount.GetHashCode();
                if (DeliveryTrackingStatus != null)
                    hashCode = hashCode * 59 + DeliveryTrackingStatus.GetHashCode();
                if (DriverId != null)
                    hashCode = hashCode * 59 + DriverId.GetHashCode();
                if (TotalTax != null)
                    hashCode = hashCode * 59 + TotalTax.GetHashCode();
                if (OrderTrackingCode != null)
                    hashCode = hashCode * 59 + OrderTrackingCode.GetHashCode();
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
