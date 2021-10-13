using System;
using Acr.UserDialogs;
using AlaskaAir.Core;
using Android.App;
using Android.Runtime;
using MvvmCross.Platforms.Android.Views;

namespace AlaskaAir.Droid
{
    [Application]
    public class MainApplication : MvxAndroidApplication<Setup, App>
    {
        public MainApplication(IntPtr javaReference, JniHandleOwnership transfer) : base(javaReference, transfer)
        {
        }

        public override void OnCreate()
        {
            base.OnCreate();
            UserDialogs.Init(this);
        }
    }
}
