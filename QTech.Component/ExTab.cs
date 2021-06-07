using System.Windows.Forms;

namespace Storm.Component
{
    public partial class ExTab : UserControl
    {
        public ExTab()
        {
            InitializeComponent();
        }
    }

    public class ExTabPage
    {
        public ExTabItem TabItem { get; set; }
        public GRAPanel Panel { get; set; }
    }
}
