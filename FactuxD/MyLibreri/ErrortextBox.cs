using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MyLibreri
{
    //herreda los comportamientos de un textbox
    public partial class ErrortextBox : TextBox
    {
        public ErrortextBox()
        {
            InitializeComponent();

        }
        public Boolean validar
        {
            set;
            get;
        }
        public Boolean SoloNumeros
        {
            set;
            get;
        }
    }
}
