
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AlaskaAir.Core.ViewModels;
using Android.App;
using Android.OS;
using Android.Views;
using MvvmCross.Platforms.Android.Presenters.Attributes;
using MvvmCross.Binding.BindingContext;

namespace AlaskaAir.Droid.Resources.Views
{
    [MvxActivityPresentation]
    [Activity(Theme = "@style/AppTheme")]
    public class FlightsView : BaseView<FlightsViewModel>
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.flights_view);
            SupportActionBar?.SetDisplayHomeAsUpEnabled(true);
            SupportActionBar?.SetDisplayShowHomeEnabled(true);
        }

        public override bool OnOptionsItemSelected(IMenuItem item)
        {
            switch (item.ItemId)
            {
                case Android.Resource.Id.Home:
                    ViewModel.BackAsyncCommand.Execute();
                    return true;
                default:
                    return base.OnOptionsItemSelected(item);
            }
        }

        protected override void CreateBindings()
        {
            var set = this.CreateBindingSet<FlightsView, FlightsViewModel>();
            set.Bind(SupportActionBar).For(v => v.Title).To(vm => vm.Title);
            set.Apply();
        }
    }
}
