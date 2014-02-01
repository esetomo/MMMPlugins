using MikuMikuPlugin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataViewerPlugin
{
    public class MotionLayerViewModel : ObjectViewModel
    {
        private MotionLayer layer;

        public MotionLayerViewModel(MotionLayer layer)
        {
            this.layer = layer;
        }

        public override string Label
        {
            get { return "Layer: " + layer.Name; }
        }

        public override IEnumerable<ObjectViewModel> Children
        {
            get
            {
                return from frame in layer.Frames
                       select new MotionFrameViewModel(frame);
            }
        }
    }
}
