using MikuMikuPlugin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataViewerPlugin
{
    class ModelViewModel : ObjectViewModel
    {
        private Model model;

        public ModelViewModel(Model model)
        {
            this.model = model;
        }

        public override string Label
        {
            get { return "Model: " + model.Name; }
        }

        public override IEnumerable<ObjectViewModel> Children
        {
            get
            {
                var bones =
                    from bone in model.Bones
                        where bone.ParentBoneID < 0
                        select new BoneViewModel(model, bone);

                var morphs =
                    from morph in model.Morphs
                    select new MorphViewModel(morph);

                var materials =
                    from material in model.Materials
                    select new MaterialViewModel(material);

                var propertyFrames =
                    from propertyFrame in model.PropertyFrames
                    select new PropertyFrameViewModel(propertyFrame);

                return ObjectViewModel.Concat(bones, morphs, materials, propertyFrames);
            }
        }
    }
}
