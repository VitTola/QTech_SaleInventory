using EasyServer.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace QTech.Component.Helpers
{
    public static class DropDownExts
    {
        public static List<DropDownItemModel> IntegerToDropDownItem(this List<int> list)
        {
            var dropdownItems = list.Select(x => new DropDownItemModel()
            {
                Id = x,
                Name = x.ToString(),
                DisplayText =string.Empty,
                ItemObject = x
            }).ToList();

            return dropdownItems;
        }

        //public static List<DropDownItemModel> LocationToDropDownItem(this List<Location> list)
        //{
        //    var dropdownItems = list.Select(x => new DropDownItemModel()
        //    {
        //        Id = x.Code,
        //        Name = $"{x.Title}{x.Name}",
        //        DisplayText = string.Empty,
        //        ItemObject = x
        //    }).ToList();

        //    return dropdownItems;
        //}

        public static List<DropDownItemModel> GetDataSource(Type enumType, bool all = false, params Enum[] ignores)
        {
            var enumLists = Enum.GetValues(enumType).Cast<Enum>().Where(x => !ignores.Contains(x));
            var tmp = new List<DropDownItemModel>();
            foreach (var item in enumLists)
            {
                tmp.Add(new DropDownItemModel()
                {
                    Id = item,
                    Name = item.ToString(),
                    DisplayText = string.Empty,
                    ItemObject = item
                });
            }
            if (all)
            {
                var allText = enumType.Name;
                var allOfText = string.Format("ទាំងអស់ {0}", allText);
                tmp.Insert(0, new DropDownItemModel() { Id = null, Name = allOfText, DisplayText = string.Empty, ItemObject = null });
            }
            return tmp;
        }

        //public static void SetEnumSource(this ExComboBox combo, Type enumType, bool optionForAll = false, params Enum[] ignores)
        //{
        //    var lists = GetDataSource(enumType, optionForAll, ignores);
        //    combo.DropDownPanel = new DropDownItem(lists);
        //    // combo.Value = null;
        //    combo.Value = 0;
        //}

        //public static void SetEnumSource(this ComboBox combo, Type enumType, bool optionForAll = false, params Enum[] ignores)
        //{
        //    var source = GetDataSource(enumType, optionForAll, ignores);
        //    combo.DisplayMember = "Name";
        //    combo.ValueMember = "Id";
        //    combo.DataSource = source;
        //}
    }
}
