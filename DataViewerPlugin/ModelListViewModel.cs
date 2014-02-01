using MikuMikuPlugin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataViewerPlugin
{
    public class ModelListViewModel : ObjectViewModel
    {
        private readonly Scene scene;

        public ModelListViewModel(MikuMikuPlugin.Scene scene)
        {
            this.scene = scene;
        }

        public override string Label
        {
            get { return "Models"; }
        }

        public override IEnumerable<ObjectViewModel> Children
        {
            get
            {
                return from model in scene.Models
                       select new ModelViewModel(model);
            }
        }
    }
}
