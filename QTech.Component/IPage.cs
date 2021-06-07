using System.Threading.Tasks;

namespace QTech.Component
{
    public interface IPage
    {
        void AddNew();
        void Remove();
        void View();
        void Edit();
        Task Search();
        void Reload();
    }
    public interface IPageReport
    {
        void View();
        void Find();
        void Reload();
        void DownloadCsv();
    }
}
