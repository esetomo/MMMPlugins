using MikuMikuPlugin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataViewerPlugin
{
    class MorphFrameViewModel : ObjectViewModel
    {
        private IMorphFrameData frame;

        public MorphFrameViewModel(IMorphFrameData frame)
        {
            this.frame = frame;
        }

        public override string Label
        {
            get {
                return string.Format("Frame:{0} Weight:{1} ({2},{3})-({4},{5})",
                    frame.FrameNumber,
                    frame.Weight,
                    frame.InterpolA.X,
                    frame.InterpolA.Y,
                    frame.InterpolB.X,
                    frame.InterpolB.Y);
            }
        }
    }
}
