using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Storm.Base.Properties;

namespace Storm.Base
{
    public  class  SupperProgram
    {
        public static SupperProgram Instance = GetInstance();
        private  List<MenuBar> _menuBar = new List<MenuBar>();
        private int _id = 1;
        private SupperProgram(){}

        private static SupperProgram GetInstance()
        {
            return Instance ?? (Instance = new SupperProgram());
        }
        public void RegisterLevel1Menu(string  displayname, string formname,int index, Image icon,string key)
        {
            this.RegisterMenu(displayname,formname,1,index,icon,key);
        }
        public void RegisterLevel2Menu(string displayname, string formname, int index, Image icon,string key ,int parentId)
        {
            this.RegisterMenu(displayname, formname, 2, index, icon, key,parentId);
        }
        public void RegisterLevel3Menu(string displayname, string formname, int index, Image icon,int parentid)
        {
            this.RegisterMenu(displayname, formname, 3, index, icon,"",parentid);
        }
        public int GetParentIdByKey(string key)
        {
            var currentparentId =   this.MenuBars.FirstOrDefault(x => x.Key == key)?.Id??0;
            return currentparentId;
        }
        public void RegisterMenu(string displayname, string formname, int level, int index, Image icon, string key = "", int parentId = 0)
        {
            var menubar = new MenuBar()
            {
                Id = _id,
                DisplayName = displayname,
                FormName = formname,
                Index = index,
                Level = 1,
                icon = icon,
                Key = key,
                ParentId =  parentId
            };
            this.MenuBars.Add(menubar);
            this._id += 1;
        }
        public List<MenuBar> MenuBars { get; set; }
    }
    public class MenuBar
    {
        public int Id { get; set; } 
        public string DisplayName { get; set; }
        public string FormName { get; set; }
        public int Index { get; set; }
        public int ParentId { get; set; }
        public string Key { get; set; }
        public int Level { get; set; }
        public List<MenuBar> Childs { get; set; }
        public Image icon { get; set; }
    }
}
