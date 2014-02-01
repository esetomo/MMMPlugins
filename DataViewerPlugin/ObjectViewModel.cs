using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataViewerPlugin
{
    public abstract class ObjectViewModel : ModelBase
    {
        public abstract string Label { get; }
        public abstract IEnumerable<ObjectViewModel> Children { get; }
    }
}
