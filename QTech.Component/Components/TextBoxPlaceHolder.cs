using System;
using System.ComponentModel;
using System.Windows.Forms;

namespace QTech.Component
{
    public class PlaceholderTextBox : TextBox
    { 
        private void updateHint()
        {
            if (IsHandleCreated && _placeHolder != null)
            {
                UI.SendMessage(Handle, 0x1501, (IntPtr)1, _placeHolder);
            }
        }
        protected override void OnHandleCreated(EventArgs e)
        {
            base.OnHandleCreated(e);
            updateHint();
        } 
        private string _placeHolder = "";
        [Browsable(true)]
        public string PlaceHolder { get => _placeHolder; set
            {
                _placeHolder = value;
                updateHint();
            }
        } 
    }
}