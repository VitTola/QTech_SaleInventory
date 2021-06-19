using EasyServer.Domain.ListModels;
using EasyServer.Domain.Models;
using Storm.Domain.ListModels;
using System.Collections.Generic;
using System.Linq;

namespace QTech.Component
{
    public static class DropDownExtensions
    {
        public static DropDownItemModel ToDropDownItemModel(this ItemAction action)
        { 
            var display = action.ItemText;
            if (!string.IsNullOrEmpty(action.Keyword))
            {
                display = $"{display}{{{action.Keyword}}}";
            }

            return new DropDownItemModel()
            {
                Id = 0,
                Name = display,
                DisplayText = string.Empty,
                Code = display,
                ItemObject = action
            };
        }

        public static DropDownItemModel ToDropDownItemModel(this BaseListModel entity)
        {
            string code = getDisplayValue(entity);

            return new DropDownItemModel()
            {
                Id = entity.Id,
                Name = entity.ToString(),
                DisplayText = string.Empty,
                Code =  code,
                ItemObject = entity
            };
        }

        private static string getDisplayValue(object entity)
        {
            //var code = entity.GetType().GetProperty("Code");
            //var name = entity.GetType().GetProperty("Name");
            //var pro = code ?? (name ?? null);
            //var display = pro != null ? pro.GetValue(entity).ToString() : entity.ToString();
            return entity.ToString();
        }

        public static DropDownItemModel ToDropDownItemModel(this QTech.Base.BaseModel entity)
        {
            var code = getDisplayValue(entity);
            return new DropDownItemModel()
            {
                Id = entity.Id,
                Name = entity.ToString(),
                DisplayText = string.Empty, 
                Code = code,
                ItemObject = entity
            };
        } 

        public static DropDownItemModel ToDropDownItemModel(this GuidBaseModel entity)
        {
            var code = getDisplayValue(entity);
            return new DropDownItemModel()
            {
                Id = entity.Id,
                Name = entity.ToString(),
                DisplayText = string.Empty, 
                Code = code,
                ItemObject = entity
            };
        }

        public static DropDownItemModel ToDropDownItemModel(this LongBaseModel entity)
        {
            var code = getDisplayValue(entity);
            return new DropDownItemModel()
            {
                Id = entity.Id,
                Name = entity.ToString(),
                DisplayText = string.Empty,
                Code = code,
                ItemObject = entity
            };
        }

        public static DropDownItemModel ToDropDownItemModel(this Lookup entity)
        {
            return new DropDownItemModel()
            {
                Id = entity.ValueInt,
                Name = entity.ToString(),
                DisplayText = string.Empty, 
                Code = entity.ToString(),
                ItemObject = entity
            };
        }

        //public static DropDownItemModel ToDropDownItemModel(this Location entity)
        //{
        //    return new DropDownItemModel()
        //    {
        //        Id = entity.Code,
        //        Name = entity.ToString(),
        //        DisplayText = string.Empty,
        //        Code = entity.ToString(),
        //        ItemObject = entity
        //    };
        //} 
        //public static List<DropDownItemModel> ToDropDownItemModelList(this IEnumerable<Location> list)
        //{
        //    return list.Select(x => x.ToDropDownItemModel()).ToList();
        //}
        public static List<DropDownItemModel> ToDropDownItemModelList(this IEnumerable<Lookup> list)
        {
            return list.Select(x => x.ToDropDownItemModel()).ToList();
        }

        public static List<DropDownItemModel> ToDropDownItemBaseListModel<T>(this IEnumerable<T> list) where T : BaseListModel
        {
            return list.Select(x => x.ToDropDownItemModel()).ToList();
        }

        public static List<DropDownItemModel> ToDropDownItemModelList<T>(this IEnumerable<T> list) where T : QTech.Base.BaseModel
        {
            return list.Select(x => x.ToDropDownItemModel()).ToList();
        }


        public static List<DropDownItemModel> ToDropDownItemModelListGui<TGui>(this IEnumerable<TGui> list) where TGui : GuidBaseModel
        {
            return list.Select(x => x.ToDropDownItemModel()).ToList();
        }

        public static List<DropDownItemModel> ToDropDownItemModelListLong<TLong>(this IEnumerable<TLong> list) where TLong : LongBaseModel
        {
            return list.Select(x => x.ToDropDownItemModel()).ToList();
        }
    }
}
