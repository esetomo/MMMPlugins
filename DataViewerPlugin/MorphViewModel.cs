using MikuMikuPlugin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataViewerPlugin
{
    public class MorphViewModel : ObjectViewModel
    {
        private Morph morph;

        public MorphViewModel(Morph morph)
        {
            this.morph = morph;

            Children =
                from frame in morph.Frames
                   select new MorphFrameViewModel(frame);
        }

        public override string Label
        {
            get { return "Morph:" + morph.Name; }
        }
    }
}
