using MikuMikuPlugin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataViewerPlugin
{
    public class DataViewerViewModel : ModelBase
    {
        private Scene scene;

        internal void SetScene(Scene scene)
        {
            this.scene = scene;

            RaisePropertyChanged(() => Root);
        }

        public IEnumerable<ObjectViewModel> Root
        {
            get
            {
                return new ObjectViewModel[]{new SceneViewModel(scene)};
            }
        }
    }
}
