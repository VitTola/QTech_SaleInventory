using Storm.Domain.Models;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms; 

namespace Storm.Component
{
	//public partial class AddressDropDown : UserControl, IDropDownPanel
 //   {
 //       List<DropDownItemModel> _listObject;
 //       List<AddressModel> _addresses;

 //       public object ItemObject
 //       {
 //           get
 //           {
 //               if (this.dropDownParent.Value == null)
 //               {
 //                   return null;
 //               }
 //               else
 //               {

 //                   return _addresses.FirstOrDefault(x=>x.Id == (int)this.dropDownParent.Value);
 //               }
 //           }
 //       }

	//	public AddressModel ItemModel
	//	{
	//		get
	//		{
	//			if (this.dropDownParent.Value == null)
	//			{
	//				return null;
	//			}
	//			else
	//			{

	//				return _addresses.FirstOrDefault(x => x.Id == (int)this.dropDownParent.Value);
	//			}
	//		}
	//	}

	//	public int DisplayRow { get; set; } = 10;

 //       ExComboBox IDropDownPanel.Parent
 //       {
 //           get { return dropDownParent; }

 //           set { dropDownParent = value; }
 //       }

 //       public Popup Popup = null;
 //       private ExComboBox dropDownParent = null;
 //       private string text = "";

 //       //public AddressDropDown(IEnumerable<DropDownItemModel> list):this(list.ToList())
 //       //{

 //       //}


 //       public AddressDropDown(List<AddressModel> list)
 //       {
 //           InitializeComponent();
 //           dgv.ApplyDefaultStyle();
 //           dgv.ColumnHeadersVisible = false;
 //           dgv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
 //           dgv.AlternatingRowsDefaultCellStyle.BackColor = Color.White;
 //           this.Popup = new Popup(this);
 //           this.Popup.AutoClose = false;

 //           _addresses = list;
 //       }

 //       //public AddressDropDown(List<AddressModel> list, string all):this(list)
 //       //{
 //       //    //_addresses.Insert(0, new AddressModel() { Id = 0, Name = all, Name = all, ItemObject = null });
 //       //}

 //       public void ShowDropDown()
 //       {
 //           var h = (this.dgv.Rows.Count > this.DisplayRow ? this.DisplayRow : this.dgv.Rows.Count)
 //                   * this.dgv.RowTemplate.Height;
 //           if (h > 0) h = h + 2;
 //           this.Popup.Height = h;
 //           this.Popup.Show(this.dropDownParent);
 //           this.Popup.Visible = true;
 //       }

 //       public void HideDropDown()
 //       {
 //           this.Popup.Visible = false;
 //           this.Popup.Close();
 //       }

 //       public void Search(string search)
 //       {
 //           search = search ?? "";
 //           this.text = search.ToLower();
 //           if (_addresses==null)
 //           {
 //               this.HideDropDown();
 //               return;
 //           }

 //           var lst = (from address in _addresses.Where(x => x.LocalSearch(search.ToLower().Trim()))
 //                      select new
 //                      {
 //                          address.Id,
 //                          Name = new string(' ', (address.GetDisplayLevel() - 1) * 4) + address,
 //                      }).Take(DisplayRow).ToList();

 //           this.dgv.DataSource = lst;
 //           this.ShowDropDown();
 //       }


 //       public string GetDisplayText(object value)
 //       {
 //           if (value == null)
 //           {
 //               return "";
 //           }
 //           var obj = _addresses.FirstOrDefault(x => x.Id.Equals(value));
 //           return obj == null ? "" : obj.Name;
 //       }

 //       public object GetSelectedValue()
 //       {
 //           return this.dgv.SelectedRows.Count > 0 ? this.dgv.SelectedRows[0].Cells[Id.Name].Value : null;
 //       }

 //       public void SetDropDownParent(ExComboBox parent)
 //       {
 //           var width = parent.Width;
 //           // in case it's datagridview cell, then get the size from editingcontrol's parent.
 //           if (parent is IDataGridViewEditingControl)
 //           {
 //               width = parent.Width < 260 ? 260 : parent.Width;
 //           }
 //           this.dropDownParent = parent;
 //           this.Popup.Size = new Size(width,150);
 //       }

 //       public new void Focus()
 //       {
 //           this.dgv.Focus();
 //       }

 //       private void dgv_CellClick(object sender, DataGridViewCellEventArgs e)
 //       {
 //           if (this.dgv.SelectedRows.Count > 0)
 //           {
 //               this.dropDownParent.Value = this.dgv.SelectedRows[0].Cells[Id.Name].Value;
 //               this.dropDownParent.Focus();
 //           }
 //       }

 //       private void dgv_KeyDown(object sender, KeyEventArgs e)
 //       {
 //           if (e.KeyCode == Keys.Return)
 //           {
 //               e.Handled = true;
 //               if (this.dgv.SelectedRows.Count > 0)
 //               {
 //                   this.HideDropDown();
 //                   this.dropDownParent.Value = this.GetSelectedValue();
 //                   this.dropDownParent.Focus();
 //               }
 //           }
 //           else if (e.KeyCode == Keys.Up)
 //           {
 //               if (dgv.SelectedRows.Count>0&& this.dgv.SelectedRows[0].Index == 0)
 //               {
 //                   this.dropDownParent.Focus();
 //                   this.HideDropDown();
 //               }
 //           }
 //           else if (e.KeyCode == Keys.Escape)
 //           {
 //               this.HideDropDown();
 //           }
 //       }

 //       bool IDropDownPanel.Visible()
 //       {
 //           return this.Popup.Visible;
 //       }
 //   }

    ///// <summary>
    ///// Address Model
    ///// </summary>
    //public class AddressModel
    //{
    //    public int Id { get; set; }
    //    public string Name { get; set; }
    //    public int ParentId { get; set; }
    //    public string Path { get; set; }
    //    public AddressType AddressType { get; set; }
    //    public List<AddressModel> Children { get; set; }
    //    public AddressModel Parent { get; set; }
    //    public int GetDisplayLevel()
    //    {
    //        var levels = this.Path.Split('/');
    //        return levels.Count() - 1;
    //    }

    //    public string LocalPath => (this.Parent?.LocalPath ?? "") + "/" + this.ToString();

    //    public string LocalChild
    //    {
    //        get
    //        {
    //            return this.Children == null || !this.Children.Any()
    //                ? ""
    //                : string.Join(";", this.Children.Select(x => x.ToString()/* + x.LocalChild*/).ToArray());
    //        }
    //    }

    //    public bool LocalSearch(string search)
    //    {
    //        return (LocalPath + ";" + LocalChild).ToLower().Contains(search.ToLower());
    //    }

    //    public override string ToString()
    //    {
    //        return this.Name;
    //    }
    //}

    /// <summary>
    /// Address Class to Init Sample Datas
    /// </summary>
    //public class Address
    //{
    //    public enum AddressType
    //    {
    //        Country = 1,
    //        State,
    //        City,
    //        Province,
    //        District,
    //        Commune,
    //        Village
    //    }

    //    private List<AddressModel> Addresses = new List<AddressModel>();

    //    private void GenerateAddresses()
    //    {
    //        //ភ្នំពេញ
    //        var phnomPenh = new AddressModel()
    //        {
    //            Id = 1,
    //            Name = "ភ្នំពេញ",
    //            ParentId = 0,
    //            Path = "/ភ្នំពេញ",
    //            AddressType = AddressType.City,
    //        };
    //        Addresses.Add(phnomPenh);
    //        var senSok = new AddressModel()
    //        {
    //            Id = 2,
    //            Name = "សែនសុខ",
    //            ParentId = 1,
    //            Path = "/ភ្នំពេញ/សែនសុខ",
    //            AddressType = AddressType.District,
    //        };
    //        Addresses.Add(senSok);
    //        var teukThla = new AddressModel()
    //        {
    //            Id = 4,
    //            Name = "ទឹកថ្លា",
    //            ParentId = 2,
    //            Path = "/ភ្នំពេញ/សែនសុខ/ទឹកថ្លា",
    //            AddressType = AddressType.Commune,
    //        };
    //        Addresses.Add(teukThla);
    //        var khmounch = new AddressModel()
    //        {
    //            Id = 5,
    //            Name = "ឃ្មួញ",
    //            ParentId = 2,
    //            Path = "/ភ្នំពេញ/សែនសុខ/ឃ្មួញ",
    //            AddressType = AddressType.Commune,
    //        };
    //        Addresses.Add(khmounch);
    //        var porSenchey = new AddressModel()
    //        {
    //            Id = 3,
    //            Name = "ពោធសែនជ័យ",
    //            ParentId = 1,
    //            Path = "/ភ្នំពេញ/ពោធសែនជ័យ",
    //            AddressType = AddressType.District,
    //        };
    //        Addresses.Add(porSenchey);
    //        var chomChao = new AddressModel()
    //        {
    //            Id = 6,
    //            Name = "ចោមចៅ",
    //            ParentId = 3,
    //            Path = "/ភ្នំពេញ/ពោធសែនជ័យ/ចោមចៅ",
    //            AddressType = AddressType.Commune,
    //        };
    //        Addresses.Add(chomChao);
    //        var kakap = new AddressModel()
    //        {
    //            Id = 8,
    //            Name = "កាកាប",
    //            ParentId = 3,
    //            Path = "/ភ្នំពេញ/ពោធសែនជ័យ/កាកាប",
    //            AddressType = AddressType.Commune,
    //        };
    //        Addresses.Add(kakap);
    //        //កំពត
    //        var kampot = new AddressModel()
    //        {
    //            Id = 9,
    //            Name = "កំពត",
    //            ParentId = 0,
    //            Path = "/កំពត",
    //            AddressType = AddressType.City,
    //        };
    //        Addresses.Add(kampot);
    //        var angkorChey = new AddressModel()
    //        {
    //            Id = 10,
    //            Name = "អង្គរជ័យ",
    //            ParentId = 9,
    //            Path = "/កំពត/អង្គរជ័យ",
    //            AddressType = AddressType.District,
    //        };
    //        Addresses.Add(angkorChey);
    //        var champei = new AddressModel()
    //        {
    //            Id = 11,
    //            Name = "ចំប៉ី",
    //            ParentId = 10,
    //            Path = "/កំពត/អង្គរជ័យ/ចំប៉ី",
    //            AddressType = AddressType.Commune,
    //        };
    //        Addresses.Add(champei);
    //        var dambokKpous = new AddressModel()
    //        {
    //            Id = 12,
    //            Name = "តំបូកខ្ពស់",
    //            ParentId = 10,
    //            Path = "/កំពត/អង្គរជ័យ/តំបូកខ្ពស់",
    //            AddressType = AddressType.Commune,
    //        };
    //        Addresses.Add(dambokKpous);
    //        var banteayMeas = new AddressModel()
    //        {
    //            Id = 13,
    //            Name = "បន្ទាយមាស",
    //            ParentId = 9,
    //            Path = "/កំពត/បន្ទាយមាស",
    //            AddressType = AddressType.District,
    //        };
    //        Addresses.Add(banteayMeas);
    //        var preyTonle = new AddressModel()
    //        {
    //            Id = 14,
    //            Name = "ព្រៃទន្លេ",
    //            ParentId = 13,
    //            Path = "/កំពត/បន្ទាយមាស/ព្រៃទន្លេ",
    //            AddressType = AddressType.Commune,
    //        };
    //        Addresses.Add(preyTonle);
    //        var samrongKrom = new AddressModel()
    //        {
    //            Id = 15,
    //            Name = "សម្រោងក្រោម",
    //            ParentId = 13,
    //            Path = "/កំពត/បន្ទាយមាស/សម្រោងក្រោម",
    //            AddressType = AddressType.Commune,
    //        };
    //        Addresses.Add(samrongKrom);
    //    }

    //    public List<AddressModel> GetAddresses()
    //    {
    //        GenerateAddresses();
    //        //Add Children
    //        Addresses.OrderBy(x => x.Path).ToList().ForEach(x =>
    //        {
    //            var child = Addresses.Where(y => y.ParentId == x.Id).ToList();
    //            if (child.Any())
    //            {
    //                x.Children = new List<AddressModel>();
    //                child.ForEach(c =>
    //                {
    //                    c.Parent = x;
    //                    x.Children.Add(c);
    //                });
    //            }
    //        });
    //        //
    //        return Addresses;
    //    }
    //}
}
