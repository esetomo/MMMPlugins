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
            get { return model.Name; }
        }

        public override IEnumerable<ObjectViewModel> Children
        {
            get
            {
                return new ObjectViewModel[]{
                    new BoneListViewModel(model),
                };
            }
        }
    }
}
