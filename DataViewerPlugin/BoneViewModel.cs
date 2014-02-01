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
            get {
                return string.Format("Bone: {0} move:({1},{2},{3}) rot:({4},{5},{6},{7})",
                    bone.Name,
                    bone.CurrentLocalMotion.Move.X,
                    bone.CurrentLocalMotion.Move.Y,
                    bone.CurrentLocalMotion.Move.Z,
                    bone.CurrentLocalMotion.Rotation.X,
                    bone.CurrentLocalMotion.Rotation.Y,
                    bone.CurrentLocalMotion.Rotation.Z,
                    bone.CurrentLocalMotion.Rotation.W);
            }
        }

        public override IEnumerable<ObjectViewModel> Children
        {
            get {
                var children =
                    from child in model.Bones
                       where bone.BoneID == child.ParentBoneID
                       select new BoneViewModel(model, child);
                
                var layers =
                    from layer in bone.Layers
                        select new MotionLayerViewModel(layer);

                return ObjectViewModel.Concat(children, layers);
            }
        }
    }
}
