using MikuMikuPlugin;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Threading;

namespace DataViewerPlugin
{
    public class DataViewerViewModel : ModelBase
    {
        private Scene scene;
        private Thread thread;

        private readonly ObservableCollection<ObjectViewModel> rootObjects = new ObservableCollection<ObjectViewModel>();
        public ObservableCollection<ObjectViewModel> Root
        {
            get { return rootObjects; }
        }

        private long markerPosition;
        public long MarkerPosition
        {
            get { return markerPosition; }
        }

        private long lastFrame;
        public long LastFrame
        {
            get { return lastFrame; }
        }

        private BoneViewModel selectedBone;
        public BoneViewModel SelectedBone
        {
            get { return selectedBone; }
        }

        internal void SetScene(Scene scene)
        {
            lock (this)
            {
                this.scene = scene;

                if (scene != null && thread == null)
                {
                    thread = new Thread(Run);
                    thread.Start();
                }
            }

            ReloadData();
        }

        public Dispatcher Dispatcher { get; set; }

        private void Run()
        {
            try
            {
                while (true)
                {
                    lock (this)
                    {
                        if (scene == null)
                        {
                            thread = null;
                            return;
                        }

                        if (IsDataChanged() && Dispatcher != null)
                        {
                            Dispatcher.BeginInvoke(new Action(ReloadData));
                        }
                    }

                    Thread.Sleep(200);
                }
            }
            catch (Exception e)
            {
                if (Dispatcher != null)
                {
                    Dispatcher.BeginInvoke(new Action(() =>
                    {
                        throw e;
                    }));
                }
                else
                {
                    using (var writer = new StreamWriter(@"DataViewPlugin.log"))
                        writer.WriteLine(e);
                }
            }
        }

        private bool IsDataChanged()
        {
            if (scene.MarkerPosition != markerPosition)
                return true;

            if (scene.Models.Count != rootObjects.Count)
                return true;

            if (CalcLastFrame() != lastFrame)
                return true;

            if (CalcSelectedBone() != selectedBone)
                return true;

            return false;
        }

        private void ReloadData()
        {
            if (scene == null)
                return;

            if (markerPosition != scene.MarkerPosition)
            {
                markerPosition = scene.MarkerPosition;
                RaisePropertyChanged(() => MarkerPosition);
            }

            if (scene.Models.Count != rootObjects.Count)
            {
                rootObjects.Clear();
                var models =
                    from model in scene.Models
                    select new ModelViewModel(model);
                foreach (var model in models)
                    rootObjects.Add(model);
            }

            var l = CalcLastFrame();
            if(l != lastFrame)
            {
                lastFrame = l;
                RaisePropertyChanged(() => LastFrame);
            }

            var b = CalcSelectedBone();
            if(b != selectedBone)
            {
                selectedBone = b;
                RaisePropertyChanged(() => SelectedBone);
            }

            foreach (var item in rootObjects)
                item.Invalidate();
        }

        private long CalcLastFrame()
        {
            return
                (from model in scene.Models
                 from bone in model.Bones
                 from layer in bone.Layers
                 from frame in layer.Frames
                 select frame.FrameNumber).Union(new long[]{-1}).Max();
        }

        private BoneViewModel CalcSelectedBone()
        {
            var model = scene.ActiveModel;
            if(model == null)
                return null;

            var bone =
                (from b in model.Bones
                 where b.SelectedLayers.Take(1).Count() > 0
                     select b).FirstOrDefault();
            if (bone == null)
                return null;

            return FindBoneViewModel(bone.DisplayName);
        }

        private BoneViewModel FindBoneViewModel(string boneName)
        {
            foreach(var item in rootObjects)
            {
                var bone = item.FindBoneViewModel(boneName);
                if (bone != null)
                    return bone;
            }

            return null;
        }
    }
}
