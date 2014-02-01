using MikuMikuPlugin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataViewerPlugin
{
    public class BoneListViewModel : ObjectViewModel
    {
        private Model model;

        public BoneListViewModel(Model model)
        {
            this.model = model;
        }

        public override string Label
        {
            get { return "Bones"; }
        }

        public override IEnumerable<ObjectViewModel> Children
        {
            get {
                return from bone in model.Bones
                       where bone.ParentBoneID < 0
                       select new BoneViewModel(model, bone);
            }
        }
    }
}
