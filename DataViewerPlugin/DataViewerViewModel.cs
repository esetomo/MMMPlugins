using MikuMikuPlugin;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;

namespace DataViewerPlugin
{
    public class DataViewerViewModel : ModelBase
    {
        private Scene scene;
        private readonly ObservableCollection<ObjectViewModel> rootObjects = new ObservableCollection<ObjectViewModel>();

        internal void SetScene(Scene scene)
        {
            this.scene = scene;

            rootObjects.Clear();
            if (scene != null)
            {
                var models =
                    from model in scene.Models
                    select new ModelViewModel(model);
                foreach (var model in models)
                    rootObjects.Add(model);
            }

            RaisePropertyChanged(() => Root);
            RaisePropertyChanged(() => MarkerPosition);
            RaisePropertyChanged(() => LastFrame);
        }

        public ObservableCollection<ObjectViewModel> Root
        {
            get
            {
                return rootObjects;
            }
        }

        public long MarkerPosition
        {
            get
            {
                if (scene == null)
                    return -1;

                return scene.MarkerPosition;
            }
            set
            {
                if (scene == null)
                    return;

                scene.MarkerPosition = value;

                RaisePropertyChanged(() => MarkerPosition);
                foreach (var item in rootObjects)
                    item.Invalidate();
            }
        }

        public long LastFrame
        {
            get
            {
                if (scene == null)
                    return -1;

                return (from model in scene.Models
                        from bone in model.Bones
                        from layer in bone.Layers
                        from frame in layer.Frames
                        select frame.FrameNumber).Max();
            }
        }
    }
}
