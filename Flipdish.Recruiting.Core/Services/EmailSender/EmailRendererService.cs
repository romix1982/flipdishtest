using DotLiquid;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;
using Flipdish.Recruiting.Core.Models;
using Flipdish.Recruiting.Core.Helpers;
using System.Linq;
using NetBarcode;

namespace Flipdish.Recruiting.Core.Services.EmailSender
{
    public interface IEmailRendererService 
    {
        string RenderEmailOrder(Order order, string appNameId, string barcodeMetadataKey, string appDirectory, Currency currency);
        public Dictionary<string, Stream> ImagesWithNames { get; }
    }

    public class EmailRendererService : IEmailRendererService, IDisposable
    {
        private Order _order;
        private string _appNameId;
        private string _appDirectory;
        private Currency _currency;
        private string _barcodeMetadataKey;
        private Dictionary<string, Stream> _imagesWithNames;

        public Dictionary<string, Stream> ImagesWithNames => _imagesWithNames;

        public EmailRendererService()
        {}

        public string RenderEmailOrder(Order order, string appNameId, string barcodeMetadataKey, string appDirectory, Currency currency)
        {
            SetFields(order, appNameId, barcodeMetadataKey, appDirectory, currency);

            var preorder_partial = _order.IsPreOrder == true ? GetPreorderPartial() : null;
            var order_status_partial = GetOrderStatusPartial();
            var order_items_partial = GetOrderItemsPartial();
            var customer_details_partial = GetCustomerDetailsPartial();

            var templateStr = GetLiquidFileAsString("RestaurantOrderDetail.liquid");
            Template template = Template.Parse(templateStr);

            var domain = SettingsService.Flipdish_DomainWithScheme;
            var orderId = _order.OrderId.Value;
            var mapUrl = string.Empty;
            var staticMapUrl = string.Empty;
            double? airDistance = null;
            var supportNumber = SettingsService.RestaurantSupportNumber;
            var physicalRestaurantName = _order.Store.Name;
            var paymentAccountDescription = _order.PaymentAccountDescription;
            var deliveryTypeNum = (int)_order.DeliveryType;
            var orderPlacedLocal = _order.PlacedTime.Value.UtcToLocalTime(_order.Store.StoreTimezone);
            var tsOrderPlaced = EtaResponseMethods.GetClocksToFormattedString(orderPlacedLocal);
            var tsOrderPlacedDayMonth = EtaResponseMethods.GetDateToFormattedString(orderPlacedLocal);
            var paid_unpaid = _order.PaymentAccountType != Order.PaymentAccountTypeEnum.Cash ? "PAID" : "UNPAID";
            var foodAmount = _order.OrderItemsAmount.Value.ToRawHtmlCurrencyString(_currency);
            var onlineProcessingFee = _order.ProcessingFee.Value.ToRawHtmlCurrencyString(_currency);
            var deliveryAmount = _order.DeliveryAmount.Value.ToRawHtmlCurrencyString(_currency);
            var tipAmount = _order.TipAmount.Value.ToRawHtmlCurrencyString(_currency);
            var totalRestaurantAmount = _order.Amount.Value.ToRawHtmlCurrencyString(_currency);
            var voucherAmount = _order.Voucher != null ? _order.Voucher.Amount.Value.ToRawHtmlCurrencyString(_currency) : "0";

            if (_order.Store.Coordinates != null && _order.Store.Coordinates.Latitude != null && _order.Store.Coordinates.Longitude != null)
            {
                if (_order.DeliveryType == Order.DeliveryTypeEnum.Delivery &&
                    _order.DeliveryLocation.Coordinates != null)
                {
                    mapUrl =
                        GeoUtils.GetDynamicMapUrl(
                            _order.DeliveryLocation.Coordinates.Latitude.Value,
                            _order.DeliveryLocation.Coordinates.Longitude.Value, 18);
                    staticMapUrl = GeoUtils.GetStaticMapUrl(
                        _order.DeliveryLocation.Coordinates.Latitude.Value,
                        _order.DeliveryLocation.Coordinates.Longitude.Value,
                        18,
                        _order.DeliveryLocation.Coordinates.Latitude.Value,
                        _order.DeliveryLocation.Coordinates.Longitude.Value
                        );
                    var deliveryLocation = new Coordinates(
                        _order.DeliveryLocation.Coordinates.Latitude.Value,
                        _order.DeliveryLocation.Coordinates.Longitude.Value);
                    var storeCoordinates = new Coordinates(
                        _order.Store.Coordinates.Latitude.Value,
                        _order.Store.Coordinates.Longitude.Value);
                    airDistance = GeoUtils.GetAirDistance(deliveryLocation, storeCoordinates);
                }
                else if (_order.DeliveryType == Order.DeliveryTypeEnum.Pickup &&
                         _order.CustomerLocation != null)
                {
                    Coordinates userLocation =
                         new Coordinates(
                            _order.CustomerLocation.Latitude.Value,
                            _order.CustomerLocation.Longitude.Value);
                    var storeCoordinates = new Coordinates(
                        _order.Store.Coordinates.Latitude.Value,
                        _order.Store.Coordinates.Longitude.Value);
                    airDistance = GeoUtils.GetAirDistance(userLocation, storeCoordinates);
                }
            }

            if (airDistance.HasValue)
            {
                airDistance = Math.Round(airDistance.Value, 1);
            }

            var airDistanceStr = airDistance.HasValue ? airDistance.Value.ToString() : "?";
            var currentYear = DateTime.UtcNow.Year.ToString();

            string orderMsg;
            if (_order.DeliveryType == Order.DeliveryTypeEnum.Delivery)
            {
                orderMsg = "NEW DELIVERY ORDER";
            }
            else if (_order.DeliveryType == Order.DeliveryTypeEnum.Pickup)
            {
                switch (_order.PickupLocationType)
                {
                    case Order.PickupLocationTypeEnum.TakeOut:
                        orderMsg = "NEW COLLECTION ORDER ";
                        break;
                    case Order.PickupLocationTypeEnum.TableService:
                        orderMsg = "NEW TABLE SERVICE ORDER ";
                        break;
                    case Order.PickupLocationTypeEnum.DineIn:
                        orderMsg = "NEW DINE IN ORDER ";
                        break;
                    default:
                        var orderMsgLower = $"NEW {_order.PickupLocationType} ORDER";
                        orderMsg = orderMsgLower.ToUpper();
                        break;
                }
            }
            else
            {
                throw new Exception("Unknown DeliveryType.");
            }
            const string openingTag1 = "<span style=\"color: #222; background: #ffc; font-weight: bold; \">";
            const string closingTag1 = "</span>";
            orderMsg = Regex.Replace(orderMsg, @"[ ]", "&nbsp;");
            var resNew_DeliveryType_Order = string.Format(orderMsg, openingTag1, closingTag1);

            var resPAID = "PAID";
            var resUNPAID = "UNPAID";
            var resDistance = string.Format("{0} km from restaurant", airDistanceStr);

            const string openingTag2 = "<span style=\"font-weight: bold; font-size: inherit; line-height: 24px;color: rgb(208, 93, 104); \">";
            const string closingTag2 = "</span>";

            string taxAmount = null;

            var resCall_the_Flipdish_ = string.Format("Call the Flipdish Hotline at {0}", openingTag2 + supportNumber + closingTag2);

            var resRestaurant_New_Order_Mail = "Restaurant New Order Mail";
            var resVIEW_ONLINE = "VIEW ONLINE";
            var resFood_Total = "Food Total";
            var resVoucher = "Voucher";
            var resProcessing_Fee = "Processing Fee";
            var resDelivery_Fee = "Delivery Fee";
            var resTip_Amount = "Tip Amount";
            var resTotal = "Total";
            var resCustomer_Location = "Customer Location";
            var resTax = "Tax";

            var paramaters = new RenderParameters(CultureInfo.CurrentCulture)
            {
                LocalVariables = Hash.FromAnonymousObject(new
                {
                    order_status_partial,
                    order_items_partial,
                    customer_details_partial,
                    preorder_partial,
                    physicalRestaurantName,
                    mapUrl,
                    staticMapUrl,
                    resCall_the_Flipdish_,
                    airDistanceStr,
                    paymentAccountDescription,
                    deliveryTypeNum,
                    tsOrderPlaced,
                    tsOrderPlacedDayMonth,
                    paid_unpaid,
                    domain,
                    orderId,
                    foodAmount,
                    onlineProcessingFee,
                    deliveryAmount,
                    tipAmount,
                    totalRestaurantAmount,
                    currentYear,
                    voucherAmount,
                    resNew_DeliveryType_Order,
                    resPAID,
                    resUNPAID,
                    resRestaurant_New_Order_Mail,
                    resVIEW_ONLINE,
                    resFood_Total,
                    resVoucher,
                    resProcessing_Fee,
                    resDelivery_Fee,
                    resTip_Amount,
                    resTotal,
                    resCustomer_Location,
                    resDistance,
                    appNameId = _appNameId,
                    taxAmount,
                    resTax
                }),
                Filters = new[] { typeof(CurrencyFilter) }
            };

            return template.Render(paramaters);
        }

        public void Dispose()
        {
            if (_imagesWithNames == null)
                return;

            foreach (var kvp in _imagesWithNames)
            {
                kvp.Value.Dispose();
            }

            _imagesWithNames = null;
        }

        private void SetFields(Order order, string appNameId, string barcodeMetadataKey, string appDirectory, Currency currency)
        {
            _order = order;
            _appNameId = appNameId;
            _barcodeMetadataKey = barcodeMetadataKey;
            _appDirectory = appDirectory;
            _currency = currency;
            _imagesWithNames = new Dictionary<string, Stream>();
        }

        private string GetPreorderPartial()
        {
            var templateStr = GetLiquidFileAsString("PreorderPartial.liquid");
            Template template = Template.Parse(templateStr);

            var reqForLocal = _order.RequestedForTime.Value.UtcToLocalTime(_order.Store.StoreTimezone);

            var reqestedForDateStr = EtaResponseMethods.GetDateToFormattedString(reqForLocal);
            var reqestedForTimeStr = EtaResponseMethods.GetClocksToFormattedString(reqForLocal);

            var resPREORDER_FOR = "PREORDER FOR";

            var paramaters = new RenderParameters(CultureInfo.CurrentCulture)
            {
                LocalVariables = Hash.FromAnonymousObject(new
                {
                    reqestedForDateStr,
                    reqestedForTimeStr,
                    resPREORDER_FOR
                })
            };

            return template.Render(paramaters);
        }

        private string GetLiquidFileAsString(string fileName)
        {
            var templateFilePath = Path.Combine(_appDirectory, "LiquidTemplates", fileName);
            return new StreamReader(templateFilePath).ReadToEnd();
        }

        private string GetOrderStatusPartial()
        {
            var orderId = _order.OrderId.Value;
            var webLink = string.Format(SettingsService.EmailServiceOrderUrl, _appNameId, orderId);

            var resOrder = "Order";
            var resView_Order = "View Order";

            var templateStr = GetLiquidFileAsString("OrderStatusPartial.liquid");
            Template template = Template.Parse(templateStr);
            var paramaters = new RenderParameters(CultureInfo.CurrentCulture)
            {
                LocalVariables = Hash.FromAnonymousObject(new
                {
                    webLink,
                    orderId,
                    resOrder,
                    resView_Order
                })
            };

            return template.Render(paramaters); ;
        }

        private string GetOrderItemsPartial()
        {
            var templateStr = GetLiquidFileAsString("OrderItemsPartial.liquid");
            Template template = Template.Parse(templateStr);

            var chefNote = _order.ChefNote;
            var itemsPart = GetItemsPart();

            var resSection = "Section";
            var resItems = "Items";
            var resOptions = "Options";
            var resPrice = "Price";
            var resChefNotes = "Chef Notes";

            var customerLocationLabel = "Customer Location";

            var customerPickupLocation = GetCustomerPickupLocationMessage();

            var paramaters = new RenderParameters(CultureInfo.CurrentCulture)
            {
                LocalVariables = Hash.FromAnonymousObject(new
                {
                    chefNote,
                    itemsPart,
                    resSection,
                    resItems,
                    resOptions,
                    resPrice,
                    resChefNotes,
                    customerLocationLabel,
                    customerPickupLocation
                })
            };

            return template.Render(paramaters);
        }

        private string GetCustomerPickupLocationMessage()
        {
            if (!_order.DropOffLocationId.HasValue || _order.PickupLocationType != Order.PickupLocationTypeEnum.TableService)
                return null;

            var tableServiceCategoryMessage = _order.TableServiceCatagory.Value.GetTableServiceCategoryLabel();
            return $"{tableServiceCategoryMessage}: {_order.DropOffLocation}";
        }

        private string GetCustomerDetailsPartial()
        {
            var templateStr = GetLiquidFileAsString("CustomerDetailsPartial.liquid");
            Template template = Template.Parse(templateStr);

            var domain = SettingsService.Flipdish_DomainWithScheme;
            var customerName = _order.Customer.Name;
            var deliveryInstructions = _order?.DeliveryLocation?.DeliveryInstructions;
            var deliveryLocationAddressString = _order?.DeliveryLocation?.PrettyAddressString;

            var phoneNumber = _order.Customer.PhoneNumberLocalFormat;
            var isDelivery = _order.DeliveryType == Order.DeliveryTypeEnum.Delivery;

            var resDelivery_Instructions = "Delivery Instructions";

            var paramaters = new RenderParameters(CultureInfo.CurrentCulture)
            {
                LocalVariables = Hash.FromAnonymousObject(new
                {
                    domain,
                    customerName,
                    deliveryInstructions,
                    deliveryLocationAddressString,
                    phoneNumber,
                    isDelivery,
                    resDelivery_Instructions
                })
            };

            return template.Render(paramaters);
        }

        private string GetItemsPart()
        {
            StringBuilder itemsPart = new StringBuilder();

            itemsPart.AppendLine("<tr>");
            itemsPart.AppendLine($"<td cellpadding=\"2px\" valign=\"top\" style=\"font-weight: bold;\">Order items</td>");
            itemsPart.AppendLine($"<td cellpadding=\"2px\" valign=\"top\"></td>");
            itemsPart.AppendLine("</tr>");
            itemsPart.AppendLine(GetSpaceDivider());
            var sectionsGrouped = OrderHelper.GetMenuSectionGroupedList(_order.OrderItems, _barcodeMetadataKey);
            var last = sectionsGrouped.Last();
            foreach (var section in sectionsGrouped)
            {
                itemsPart.AppendLine("<tr>");
                itemsPart.AppendLine($"<td cellpadding=\"2px\" valign=\"top\" style=\"font-size: 14px;\">{section.Name.ToUpper()}</td>");
                itemsPart.AppendLine($"<td cellpadding=\"2px\" valign=\"top\" style=\"font-size: 14px;\"></td>");
                itemsPart.AppendLine("</tr>");
                itemsPart.AppendLine(GetLineDivider());
                itemsPart.AppendLine(GetSpaceDivider());
                foreach (var item in section.MenuItemsGroupedList)
                {
                    itemsPart.AppendLine("<tr>");
                    var countStr = item.Count > 1 ? $"{item.Count} x " : string.Empty;
                    itemsPart.AppendLine($"<td cellpadding=\"2px\" valign=\"middle\" style=\"padding-left: 40px;\">{countStr}{item.MenuItemUI.Name}</td>");
                    var itemPriceStr = item.MenuItemUI.Price.HasValue ? (item.MenuItemUI.Price.Value * item.Count).ToRawHtmlCurrencyString(_currency) : string.Empty;
                    itemsPart.AppendLine($"<td cellpadding=\"2px\" valign=\"middle\">{itemPriceStr}</td>");

                    if (!string.IsNullOrEmpty(item.MenuItemUI.Barcode))
                    {
                        Stream barcodeStream;

                        if (_imagesWithNames.ContainsKey(item.MenuItemUI.Barcode + ".png"))
                        {
                            barcodeStream = _imagesWithNames[item.MenuItemUI.Barcode + ".png"];
                        }
                        else
                        {
                            barcodeStream = GetBase64EAN13Barcode(item.MenuItemUI.Barcode);
                        }

                        if (barcodeStream != null)
                        {
                            if (!_imagesWithNames.ContainsKey(item.MenuItemUI.Barcode + ".png"))
                                _imagesWithNames.Add(item.MenuItemUI.Barcode + ".png", barcodeStream);

                            itemsPart.AppendLine($"<td cellpadding=\"2px\" valign=\"middle\"><img style=\"margin-left: 14px;margin-left: 9px;padding-top: 10px; padding-bottom:10px\" src=\"cid:{item.MenuItemUI.Barcode}.png\"/></td>");
                            if (item.Count > 1)
                            {
                                itemsPart.AppendLine($"<td cellpadding=\"2px\" valign=\"middle\" style=\"font-size:40px\">x</td>");
                                itemsPart.AppendLine($"<td cellpadding=\"2px\" valign=\"middle\" style=\"font-size:50px\">{item.Count}</td>");
                            }
                        }
                    }

                    itemsPart.AppendLine("</tr>");

                    foreach (var option in item.MenuItemUI.MenuOptions)
                    {
                        CreateMenuOptions(itemsPart, item, option);
                    }
                }

                if (!section.Equals(last))
                {
                    itemsPart.AppendLine(GetSpaceDivider());
                }
            }

            return itemsPart.ToString();
        }

        private void CreateMenuOptions(StringBuilder itemsPart, MenuItemsGrouped item, MenuOption option)
        {
            itemsPart.AppendLine("<tr>");
            itemsPart.AppendLine($"<td cellpadding=\"2px\" valign=\"middle\" style=\"padding-left: 40px;padding-top: 10px; padding-bottom:10px\">+ {option.Name}</td>");
            itemsPart.AppendLine($"<td cellpadding=\"2px\" valign=\"middle\">{(option.Price * item.Count).ToRawHtmlCurrencyString(_currency)}</td>");

            if (!string.IsNullOrEmpty(option.Barcode))
            {
                Stream barcodeStream;

                if (_imagesWithNames.ContainsKey(option.Barcode + ".png"))
                {
                    barcodeStream = _imagesWithNames[option.Barcode + ".png"];
                }
                else
                {
                    barcodeStream = GetBase64EAN13Barcode(option.Barcode);
                }
                if (barcodeStream != null)
                {
                    if (!_imagesWithNames.ContainsKey(option.Barcode + ".png"))
                    {
                        _imagesWithNames.Add(option.Barcode + ".png", barcodeStream);
                    }
                    itemsPart.AppendLine($"<td cellpadding=\"2px\" valign=\"middle\"><img style=\"margin-left: 14px;margin-left: 9px;padding-top: 10px; padding-bottom:10px\" src=\"cid:{option.Barcode}.png\"/></td>");
                }
            }

            itemsPart.AppendLine("</tr>");
        }

        private Stream GetBase64EAN13Barcode(string barcodeNumbers)
        {
            try
            {
                var barcode = new Barcode(barcodeNumbers, showLabel: true, width: 130, height: 110, labelPosition: LabelPosition.BottomCenter);

                var bytes = barcode.GetByteArray();
                return new MemoryStream(bytes);
            }
            catch (Exception ex)
            {
                throw new Exception($"{barcodeNumbers} is not a valid barcode for order #{_order.OrderId}", ex);
            }
        }

        private string GetLineDivider()
        {
            StringBuilder result = new StringBuilder();

            result.AppendLine("<tr>");
            result.AppendLine("<td colspan=\"2\" align =\"center\" valign=\"top\">");
            result.AppendLine("<table width=\"100%\" border=\"0\" cellspacing=\"0\" cellpadding=\"0\" align=\"center\" style=\"height: 1px; background-color: rgb(186, 186, 186);\">");
            result.AppendLine("</table>");
            result.AppendLine("</td>");
            result.AppendLine("</tr>");

            return result.ToString();
        }

        private string GetSpaceDivider()
        {
            StringBuilder result = new StringBuilder();

            result.AppendLine("<tr>");
            result.AppendLine("<td colspan=\"2\" align =\"center\" valign=\"top\">");
            result.AppendLine("<table width=\"100%\" border=\"0\" cellspacing=\"0\" cellpadding=\"0\" align=\"center\" style=\"height: 22px;\">");
            result.AppendLine("</table>");
            result.AppendLine("</td>");
            result.AppendLine("</tr>");

            return result.ToString();
        }
    }
}
