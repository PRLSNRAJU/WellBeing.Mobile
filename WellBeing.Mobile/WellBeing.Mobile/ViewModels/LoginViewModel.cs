using Common.Dto;
using System;
using System.Collections.Generic;
using System.Text;
using WellBeing.Mobile.Services;
using WellBeing.Mobile.Views;
using Xamarin.Forms;

namespace WellBeing.Mobile.ViewModels
{
    public class LoginViewModel : BaseViewModel
    {
        public Command LoginCommand { get; }

        public LoginViewModel()
        {
            LoginCommand = new Command(OnLoginClicked);
        }

        private string name;

        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        private string phoneNumber;

        public string PhoneNumber
        {
            get { return phoneNumber; }
            set { phoneNumber = value; }
        }

        private bool yes;

        public bool Yes
        {
            get { return yes; }
            set 
            { 
                yes = value;
                OnPropertyChanged(nameof(Yes));
            }
        }

        private string dob;

        public string DOB
        {
            get { return dob; }
            set {
                dob = value;
                OnPropertyChanged(nameof(DOB));
            }
        }



        private async void OnLoginClicked(object obj)
        {
            UserDto user = new UserDto();
            user.PHONENumber = PhoneNumber;
            user.Name = Name;
            user.BDayConsent = Yes.ToString();
            user.BirthDay = Yes == true ? DOB : null;

            ApiClientService api = new ApiClientService();
            await api.AddUser(user);

            // Prefixing with `//` switches to a different navigation stack instead of pushing to the active one
            await Shell.Current.GoToAsync($"//{nameof(AboutPage)}");
        }
    }
}
