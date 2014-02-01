using MikuMikuPlugin;
using System;
using System.Windows.Forms;

namespace DataViewerPlugin
{
    public class DataViewerPlugin : IBasePlugin, IButtonPlugin, IHaveUserControl
    {
        private DataViewerControl dataViewerControl;

        public IWin32Window ApplicationForm { get; set; }
        public Scene Scene { get; set; }

        public string Description
        {
            get { return "Data Viewer for Plugin Development"; }
        }

        public Guid GUID
        {
            get { return new Guid("A183C93E-5532-4C1A-B6A3-E6D960EA7392"); }
        }

        public void Dispose()
        {
        }

        #region IButtonPlugin (表示されない場合でも実装しておかないとエラーになる)
        public UserControl CreateControl()
        {
            dataViewerControl = new DataViewerControl();
            return dataViewerControl;
        }

        string IButtonPlugin.EnglishText
        {
            get { return null; }
        }

        System.Drawing.Image IButtonPlugin.Image
        {
            get { return null; }
        }

        System.Drawing.Image IButtonPlugin.SmallImage
        {
            get { return null; }
        }

        string IButtonPlugin.Text
        {
            get { return ""; }
        }

        void IDisposable.Dispose()
        {
        }
        #endregion
    }
}
