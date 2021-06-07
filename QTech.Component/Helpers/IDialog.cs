using QTech.Base.Helpers;
using EasyServer.Domain.Models;

namespace QTech.Component.Helpers
{
    public interface IDialog
    {
        //object Model { get; set; }
        GeneralProcess Flag { set; get; }
        void Read();
        void InitEvent();
        void Write();
        void Bind();
        bool InValid();
        void Save();
        void ViewChangeLog();
    }

    public interface IDialog<T> : IDialog 
        where T : BaseModel  
    {  
        T Model { get; set; }
    }
    public interface IGuidDialog<T> : IDialog
        where T : GuidBaseModel
    {
        T Model { get; set; }
    }

    public interface ILongDialog<T> : IDialog
      where T : LongBaseModel
    {
        T Model { get; set; }
    }
}
