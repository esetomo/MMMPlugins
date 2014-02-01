using MikuMikuPlugin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataViewerPlugin
{
    public class PropertyFrameViewModel : ObjectViewModel
    {
        private IModelPropertyFrameData propertyFrame;

        public PropertyFrameViewModel(IModelPropertyFrameData propertyFrame)
        {
            this.propertyFrame = propertyFrame;
        }

        public override string Label
        {
            get { return "PropertyFrame"; }
        }
    }
}
