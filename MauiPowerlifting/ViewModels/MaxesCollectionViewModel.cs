using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;

namespace MauiPowerlifting.ViewModels
{
    public class MaxesCollectionViewModel : INotifyPropertyChanged
    {
        MaxesViewModel maxesEdit;
        bool isEditing;

        public event PropertyChangedEventHandler PropertyChanged;

        public MaxesCollectionViewModel()
        {
            NewCommand = new Command(
                execute: () =>
                {
                    MaxesEdit = new MaxesViewModel();
                    MaxesEdit.PropertyChanged += OnMaxesEditPropertyChanged;
                    IsEditing = true;
                    RefreshCanExecutes();
                },
                canExecute: () =>
                {
                    return !IsEditing;
                });

            SubmitCommand = new Command(
                execute: () =>
                {
                    MaxesEdit.PropertyChanged -= OnMaxesEditPropertyChanged;
                    Maxes.Add(MaxesEdit);
                    MaxesEdit = null;
                    IsEditing = false;
                    RefreshCanExecutes();
                },
                canExecute: () =>
                {
                    return MaxesEdit != null &&
                           MaxesEdit.Squat > 1 &&
                           MaxesEdit.Bench > 1 &&
                           MaxesEdit.Deadlift > 1;
                });

            CancelCommand = new Command(
                execute: () =>
                {
                    MaxesEdit.PropertyChanged -= OnMaxesEditPropertyChanged;
                    MaxesEdit = null;
                    IsEditing = false;
                    RefreshCanExecutes();
                },
                canExecute: () =>
                {
                    return IsEditing;
                });
        }

        void OnMaxesEditPropertyChanged(object sender, PropertyChangedEventArgs args)
        {
            (SubmitCommand as Command).ChangeCanExecute();
        }

        void RefreshCanExecutes()
        {
            (NewCommand as Command).ChangeCanExecute();
            (SubmitCommand as Command).ChangeCanExecute();
            (CancelCommand as Command).ChangeCanExecute();
        }

        public bool IsEditing
        {
            private set { SetProperty(ref isEditing, value); }
            get { return isEditing; }
        }

        public MaxesViewModel MaxesEdit
        {
            set { SetProperty(ref maxesEdit, value); }
            get { return maxesEdit; }
        }

        public ICommand NewCommand { private set; get; }

        public ICommand SubmitCommand { private set; get; }

        public ICommand CancelCommand { private set; get; }

        public IList<MaxesViewModel> Maxes { get; } = new ObservableCollection<MaxesViewModel>();

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
