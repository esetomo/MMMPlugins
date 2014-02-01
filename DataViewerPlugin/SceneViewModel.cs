using MikuMikuPlugin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataViewerPlugin
{
    public class SceneViewModel : ObjectViewModel
    {
        private readonly Scene scene;

        public SceneViewModel(Scene scene)
        {
            this.scene = scene;
        }

        public override string Label
        {
            get { return "Scene"; }
        }

        public override IEnumerable<ObjectViewModel> Children
        {
            get
            {
                return new ObjectViewModel[] {
                    new ModelListViewModel(scene),
                };
            }
        }
    }
}
