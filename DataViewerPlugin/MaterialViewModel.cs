using MikuMikuPlugin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataViewerPlugin
{
    public class MaterialViewModel : ObjectViewModel
    {
        private Material material;

        public MaterialViewModel(Material material)
        {
            this.material = material;
        }

        public override string Label
        {
            get { return "Material: " + material.DisplayName; }
        }
    }
}
