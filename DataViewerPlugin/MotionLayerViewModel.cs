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

            Children = 
                from frame in layer.Frames
                   select new MotionFrameViewModel(frame);
        }

        public override string Label
        {
            get { return "Layer: " + layer.Name; }
        }
    }
}
