using MikuMikuPlugin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataViewerPlugin
{
    public class BoneViewModel : ObjectViewModel
    {
        private Model model;
        private Bone bone;

        public BoneViewModel(Model model, Bone bone)
        {
            this.model = model;
            this.bone = bone;
        }

        public override string Label
        {
            get { return bone.Name; }
        }

        public override IEnumerable<ObjectViewModel> Children
        {
            get {
                return from child in model.Bones
                       where bone.BoneID == child.ParentBoneID
                       select new BoneViewModel(model, child);
            }
        }

        public DxMath.Vector3 Move
        {
            get { return bone.CurrentLocalMotion.Move; }
        }

        public DxMath.Quaternion Rotation
        {
            get { return bone.CurrentLocalMotion.Rotation; }
        }
    }
}
