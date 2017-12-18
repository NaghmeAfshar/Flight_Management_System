using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Media.Animation;

namespace FlightsManagementProject
{
    public static class WindowUtilties
    {
        public static void AnimateWindowSize(this Window target, double newWidth)
        {
            var sb = new Storyboard { Duration = new Duration(new TimeSpan(0, 0, 0, 0, 200)) };

            var aniWidth = new DoubleAnimationUsingKeyFrames();
            var aniHeight = new DoubleAnimationUsingKeyFrames();

            aniWidth.Duration = new Duration(new TimeSpan(0, 0, 0, 0, 200));
            aniHeight.Duration = new Duration(new TimeSpan(0, 0, 0, 0, 200));

          /*  aniHeight.KeyFrames.Add(new EasingDoubleKeyFrame(target.ActualHeight, KeyTime.FromTimeSpan(new TimeSpan(0, 0, 0, 0, 00))));
            aniHeight.KeyFrames.Add(new EasingDoubleKeyFrame(newHeight, KeyTime.FromTimeSpan(new TimeSpan(0, 0, 0, 0, 200))));*/
            aniWidth.KeyFrames.Add(new EasingDoubleKeyFrame(target.ActualWidth, KeyTime.FromTimeSpan(new TimeSpan(0, 0, 0, 0, 00))));
            aniWidth.KeyFrames.Add(new EasingDoubleKeyFrame(newWidth, KeyTime.FromTimeSpan(new TimeSpan(0, 0, 0, 0, 200))));

            Storyboard.SetTarget(aniWidth, target);
            Storyboard.SetTargetProperty(aniWidth, new PropertyPath(Window.WidthProperty));

            Storyboard.SetTarget(aniHeight, target);
            Storyboard.SetTargetProperty(aniHeight, new PropertyPath(Window.HeightProperty));

            sb.Children.Add(aniWidth);
            sb.Children.Add(aniHeight);

            sb.Begin();
        }
    }
}
