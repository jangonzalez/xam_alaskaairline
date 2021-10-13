using System;
using AlaskaAir.Core.ViewModels;
using Android.App;
using Android.OS;
using Android.Runtime;
using Android.Views;
using MvvmCross.Platforms.Android.Presenters.Attributes;
using MvvmCross.Binding.BindingContext;
using Google.Android.Material.TextField;
using Google.Android.Material.DatePicker;

namespace AlaskaAir.Droid.Resources.Views
{
    [MvxActivityPresentation]
    [Activity(Theme = "@style/AppTheme",
        WindowSoftInputMode = SoftInput.AdjustPan)]
    public class FlightSearchView : BaseView<FlightSearchViewModel>, IMaterialPickerOnPositiveButtonClickListener
    {
        private MaterialDatePicker _datePicker;
        private TextInputEditText _flightDatePicker;

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            SetContentView(Resource.Layout.flight_search_view);

            long today = MaterialDatePicker.TodayInUtcMilliseconds();
            var calendarConstraint = new CalendarConstraints.Builder();
            calendarConstraint.SetValidator(DateValidatorPointForward.Now());
            _datePicker = MaterialDatePicker.Builder
                            .DatePicker()
                            .SetTitleText("Flight Date")
                            .SetCalendarConstraints(calendarConstraint.Build())
                            .Build();

            _datePicker.AddOnPositiveButtonClickListener(this);

            _flightDatePicker = FindViewById<TextInputEditText>(Resource.Id.fromdate_picker);
            _flightDatePicker.Click += FlightDatePicker_Click;
        }

        protected override void OnDestroy()
        {
            base.OnDestroy();
            if (_flightDatePicker != null)
            {
                _flightDatePicker.Click -= FlightDatePicker_Click;
            }
        }

        private void FlightDatePicker_Click(object sender, EventArgs e)
        {
            _datePicker.Show(this.SupportFragmentManager, _datePicker.ToString());
        }

        public void OnPositiveButtonClick(Java.Lang.Object p0)
        {
            var epocTime = (long)p0;
            ViewModel.DepartureTime = DateTimeOffset.FromUnixTimeMilliseconds(epocTime).DateTime;
            _flightDatePicker.Text = ViewModel.DepartureTime.ToString("MM/dd/yy");
        }

        protected override void CreateBindings()
        {
            var set = this.CreateBindingSet<FlightSearchView, FlightSearchViewModel>();
            set.Bind(SupportActionBar).For(v => v.Title).To(vm => vm.Title);
            set.Apply();
        }
    }
}
