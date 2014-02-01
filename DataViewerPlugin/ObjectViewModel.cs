using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataViewerPlugin
{
    public abstract class ObjectViewModel : ModelBase
    {
        public abstract string Label { get; }

        public virtual IEnumerable<ObjectViewModel> Children
        {
            get
            {
                return new ObjectViewModel[] { };
            }
        }

        internal static IEnumerable<ObjectViewModel> Concat(params IEnumerable<ObjectViewModel>[] lists)
        {
            var result = Enumerable.Empty<ObjectViewModel>();

            foreach (var list in lists)
                result = result.Concat(list);

            return result;
        }
    }
}
