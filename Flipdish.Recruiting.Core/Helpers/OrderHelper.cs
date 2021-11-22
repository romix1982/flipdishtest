using System;
using System.Collections.Generic;
using System.Linq;
using Flipdish.Recruiting.Core.Models;

namespace Flipdish.Recruiting.Core.Helpers
{
    public static class OrderHelper
    {
        public static List<MenuSectionGrouped> GetMenuSectionGroupedList(List<OrderItem> orderItems, string barcodeMetadataKey)
        {
            var result = new List<MenuSectionGrouped>();

            var sectionNames = orderItems.Select(a => new { a.MenuSectionName, a.MenuSectionDisplayOrder }).Distinct().ToList();
            var menuSectionDisplayOrder = 0;
            foreach (var sectionName in sectionNames.OrderBy(a => a.MenuSectionDisplayOrder).Select(a => a.MenuSectionName))
            {
                var menuItemsGroupedList = new List<MenuItemsGrouped>();
                var menuItemDisplayOrder = 0;
                foreach (var item in orderItems.Where(a => a.MenuSectionName == sectionName).OrderBy(a => a.MenuItemDisplayOrder))
                {
                    var menuItemUI = new MenuItemUI(item, barcodeMetadataKey);
                    var menuItemsGrouped = menuItemsGroupedList.SingleOrDefault(a => a.MenuItemUI.HashCode == menuItemUI.HashCode);

                    if (menuItemsGrouped != null)
                    {
                        menuItemsGrouped.Count++;
                    }
                    else
                    {
                        menuItemsGrouped = new MenuItemsGrouped
                        {
                            MenuItemUI = menuItemUI,
                            Count = 1,
                            DisplayOrder = menuItemDisplayOrder++
                        };

                        menuItemsGroupedList.Add(menuItemsGrouped);
                    }
                }

                var menuSectionGrouped = new MenuSectionGrouped {
                    Name = sectionName,
                    DisplayOrder = menuSectionDisplayOrder++,
                    MenuItemsGroupedList = menuItemsGroupedList
                };

                result.Add(menuSectionGrouped);
            }

            return result;
        }

        public static string GetTableServiceCategoryLabel(this Order.TableServiceCatagoryEnum tableServiceCatagory)
        {
            var result = tableServiceCatagory switch
            {
                Order.TableServiceCatagoryEnum.Generic => "Generic Service n ",
                Order.TableServiceCatagoryEnum.Villa => "Villa Service n ",
                Order.TableServiceCatagoryEnum.House => "House Service n ",
                Order.TableServiceCatagoryEnum.Room => "Room Service n ",
                Order.TableServiceCatagoryEnum.Area => "Area Service n ",
                Order.TableServiceCatagoryEnum.Table => "Table Service n ",
                Order.TableServiceCatagoryEnum.ParkingBay => ".Parking Bay Service n ",
                Order.TableServiceCatagoryEnum.Gate => "Gate Service n ",
                _ => ">",
            };
            return result;
        }

        public static DateTime UtcToLocalTime(this DateTime utcTime, string timeZoneInfoId)
        {
            try
            {
                var timeZoneInfo = TimeZoneInfo.FindSystemTimeZoneById(timeZoneInfoId);
                return TimeZoneInfo.ConvertTimeFromUtc(utcTime, timeZoneInfo);
            }
            catch (Exception)
            {
                return utcTime;
            }
        }
    }
}