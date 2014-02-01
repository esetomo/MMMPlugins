using MikuMikuPlugin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataViewerPlugin
{
    public class MotionFrameViewModel : ObjectViewModel
    {
        private IMotionFrameData frame;

        public MotionFrameViewModel(IMotionFrameData frame)
        {
            this.frame = frame;
        }

        public override string Label
        {
            get
            {
                return string.Format("Frame:{0} pos:({1},{2},{3}) rot:({4},{5},{6},{7})",
                    frame.FrameNumber,
                    frame.Position.X,
                    frame.Position.Y,
                    frame.Position.Z,
                    frame.Quaternion.X,
                    frame.Quaternion.Y,
                    frame.Quaternion.Z,
                    frame.Quaternion.W);
            }
        }
    }
}
