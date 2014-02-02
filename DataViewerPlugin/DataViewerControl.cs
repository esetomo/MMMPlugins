using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MikuMikuPlugin;

namespace DataViewerPlugin
{
    public partial class DataViewerControl : UserControl
    {
        public DataViewerControl()
        {
            InitializeComponent();

            this.Dock = DockStyle.Fill;           
        }

        public void SetScene(Scene scene)
        {
            var vm = dataViewerView1.DataContext as DataViewerViewModel;
            if (vm == null)
                return;

            this.Visible = scene != null;

            vm.Dispatcher = dataViewerView1.Dispatcher;
            vm.SetScene(scene);
        }
    }
}
