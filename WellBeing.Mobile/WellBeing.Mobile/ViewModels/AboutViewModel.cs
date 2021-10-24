using Common.Dto;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Input;
using WellBeing.Mobile.Services;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace WellBeing.Mobile.ViewModels
{
    public class AboutViewModel : BaseViewModel
    {
        public AboutViewModel()
        {
            Title = "Steps";
            OpenWebCommand = new Command(async () => await runcmd());


            //Shell.Current.GoToAsync("//LoginPage").Wait();

            Device.StartTimer(TimeSpan.FromSeconds(3), () =>
            {
                // Do something
                Random rdm = new Random();
                
                Steps = steps + rdm.Next(3, 9);

                return true; // True = Repeat again, False = Stop the timer
            });

        }

        public async Task runcmd()
        {
            Accelerometer.Stop();
            Accelerometer.Start(SensorSpeed.Default);
            Accelerometer.ShakeDetected += Accelerometer_ShakeDetected;
            Accelerometer.ReadingChanged += Accelerometer_ReadingChanged;


            ApiClientService api = new ApiClientService();
            IList<UserDto> users = await api.GetUsers();
            IList<UserStepsDto> userSteps = await api.GetAllUserSteps();

            UserStepsDto user1 = userSteps[0];
            UserStepsDto user2 = userSteps[1];
            UserStepsDto user3 = userSteps[2];

            NameOne = users.Where(x => x.PHONENumber.Equals(user1.PhoneNumber)).FirstOrDefault().Name;
            StepsOne = user1.steps;

            NameTwo = users.Where(x => x.PHONENumber == user2.PhoneNumber).FirstOrDefault().Name;
            StepsTwo = user2.steps;

            NameThree = users.Where(x => x.PHONENumber == user3.PhoneNumber).FirstOrDefault().Name;
            StepsThree = user3.steps;

            int i = 0;
            foreach(UserStepsDto userStep in userSteps)
            {
                i++;
                if(userStep.PhoneNumber == "9032541266")
                {
                    break;
                }
                
            }
            Rank = Convert.ToString(i);
        }

        private bool inStep = false;

        private void Accelerometer_ReadingChanged(object sender, AccelerometerChangedEventArgs e)
        {
            
            float x = e.Reading.Acceleration.X;
            float y = e.Reading.Acceleration.Y;
            float z = e.Reading.Acceleration.Z;

            float currentvectorSum = x * x + y * y + z * z;

            if(currentvectorSum > 0.5 && inStep==true){
                inStep = false;
                Steps = steps++;
            }
        }

        private void Accelerometer_ShakeDetected(object sender, EventArgs e)
        {
            Steps++;

        }

        private int steps;

        public int Steps
        {
            get { return steps; }
            set 
            { 
                steps = value;
                OnPropertyChanged(nameof(Steps));
            }
        }


        private String nameOne;

        public String NameOne
        {
            get { return nameOne; }
            set 
            { 
                nameOne = value;
                OnPropertyChanged(nameof(NameOne));
            }
        }

        private string nameTwo;

        public string NameTwo
        {
            get { return nameTwo; }
            set 
            { 
                nameTwo = value;
                OnPropertyChanged(nameof(NameTwo));
            }
        }

        private string nameThree;

        public string NameThree
        {
            get { return nameThree; }
            set 
            { 
                nameThree = value;
                OnPropertyChanged(nameof(NameThree));
            }
        }

        private String stepsOne;

        public String StepsOne
        {
            get { return stepsOne; }
            set 
            { 
                stepsOne = value;
                OnPropertyChanged(nameof(StepsOne));
            }
        }

        private String stepsTwo;

        public String StepsTwo
        {
            get { return stepsTwo; }
            set 
            { 
                stepsTwo = value;
                OnPropertyChanged(nameof(StepsTwo));
            }
        }

        private String stepsThree;

        public String StepsThree
        {
            get { return stepsThree; }
            set 
            { 
                stepsThree = value;
                OnPropertyChanged(nameof(StepsThree));
            }
        }


        public ICommand OpenWebCommand { get; }

        private string rank;

        public string Rank { get => rank;
            set
            {
                rank = value;
                OnPropertyChanged(nameof(Rank));
            }
        }
    }
}