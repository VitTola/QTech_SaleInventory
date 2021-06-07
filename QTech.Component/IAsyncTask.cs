using System.Threading;

namespace QTech.Component
{
    public interface IAsyncTask
    {
        bool Executing { get; set; }
        void PreExecute(bool block = false);
        void PostExecute(bool block = false);
    }
}
