using MikuMikuPlugin;
using System;
using System.Windows.Forms;

namespace DataViewerPlugin
{
    // namespaceと同じクラス名のクラスがあるとデザイナ生成コードでnamespaceを指している個所が
    // クラスを参照してしまい、エラーとなる事があるので、namespaceとは異なるクラス名とした。
    public class DataViewerPluginMain : IResidentPlugin, IHaveUserControl
    {
        private DataViewerControl dataViewerControl;

        public IWin32Window ApplicationForm { get; set; }

        private Scene scene;
        public Scene Scene
        {
            get
            {
                return scene;
            }
            set
            {
                scene = value;
                if (dataViewerControl != null)
                    dataViewerControl.SetScene(scene);
            }
        }

        public string Description
        {
            get { return "Data Viewer for Plugin Development"; }
        }

        public Guid GUID
        {
            get { return new Guid("A183C93E-5532-4C1A-B6A3-E6D960EA7392"); }
        }

        public UserControl CreateControl()
        {
            dataViewerControl = new DataViewerControl();
            dataViewerControl.SetScene(null);
            return dataViewerControl;
        }

        public string EnglishText
        {
            get { return "Data Viewer"; }
        }

        public System.Drawing.Image Image
        {
            get { return null; }
        }

        public System.Drawing.Image SmallImage
        {
            get { return null; }
        }

        public string Text
        {
            get { return EnglishText; }
        }

        public void Initialize()
        {
        }

        public void Enabled()
        {
            dataViewerControl.SetScene(Scene);
        }

        public void Disabled()
        {
            dataViewerControl.SetScene(null);
        }

        public void Update(float Frame, float ElapsedTime)
        {
        }

        public void Dispose()
        {
            dataViewerControl.SetScene(null);
        }
    }
}
