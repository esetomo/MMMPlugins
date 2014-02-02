using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;

namespace DataViewerPlugin
{
    public abstract class ObjectViewModel : ModelBase
    {
        public abstract string Label { get; }

        private readonly ObservableCollection<ObjectViewModel> children = new ObservableCollection<ObjectViewModel>();

        public IEnumerable<ObjectViewModel> Children
        {
            get
            {
                return children;
            }
            protected set
            {
                children.Clear();
                foreach(var item in value)
                    children.Add(item);
            }
        }

        internal void Invalidate()
        {
            RaisePropertyChanged(() => Label);
            foreach (var child in children)
                child.Invalidate();
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
