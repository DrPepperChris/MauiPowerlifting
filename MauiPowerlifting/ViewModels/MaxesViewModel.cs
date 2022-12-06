using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace MauiPowerlifting.ViewModels
{
    public class MaxesViewModel : INotifyPropertyChanged
    {
        int squat;
        int bench;
        int deadlift;
        int press;
        int total;

        public event PropertyChangedEventHandler PropertyChanged;

        public int Bench
        {
            set { SetProperty(ref bench, value); }
            get { return bench; }
        }

        public int Squat
        {
            set { SetProperty(ref squat, value); }
            get { return squat; }
        }

        public int Deadlift
        {
            set { SetProperty(ref deadlift, value); }
            get { return deadlift; }
        }
        public int Press
        {
            set { SetProperty(ref press, value); }
            get { return press; }
        }

        bool SetProperty<T>(ref T storage, T value, [CallerMemberName] string propertyName = null)
        {
            if (Object.Equals(storage, value))
                return false;

            storage = value;
            OnPropertyChanged(propertyName);
            return true;
        }

        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}

