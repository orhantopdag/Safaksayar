using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;

using Xamarin.Forms;

using Safaksayar.Models;


namespace Safaksayar.ViewModels
{
    public class BaseViewModel : INotifyPropertyChanged
    {
        //public IDataStore<Item> DataStore => DependencyService.Get<IDataStore<Item>>();
        public class EntryLengthValidatorBehavior : Behavior<Entry>
        {
            public int MaxLength { get; set; }

            protected override void OnAttachedTo(Entry bindable)
            {
                base.OnAttachedTo(bindable);
                bindable.TextChanged += OnEntryTextChanged;
            }

            protected override void OnDetachingFrom(Entry bindable)
            {
                base.OnDetachingFrom(bindable);
                bindable.TextChanged -= OnEntryTextChanged;
            }

            void OnEntryTextChanged(object sender, TextChangedEventArgs e)
            {
                var entry = (Entry)sender;

                // if Entry text is longer then valid length
                if (entry.Text.Length > this.MaxLength)
                {
                    string entryText = entry.Text;

                    entryText = entryText.Remove(entryText.Length - 1); // remove last char

                    entry.Text = entryText;
                }
            }
        }




        bool isBusy = false;
        public bool IsBusy
        {
            get { return isBusy; }
            set { SetProperty(ref isBusy, value); }
        }

        string title = string.Empty;
        public string Title
        {
            get { return title; }
            set { SetProperty(ref title, value); }
        }

        protected bool SetProperty<T>(ref T backingStore, T value,
            [CallerMemberName] string propertyName = "",
            Action onChanged = null)
        {
            if (EqualityComparer<T>.Default.Equals(backingStore, value))
                return false;

            backingStore = value;
            onChanged?.Invoke();
            OnPropertyChanged(propertyName);
            return true;
        }

        #region INotifyPropertyChanged
        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string propertyName = "")
        {
            var changed = PropertyChanged;
            if (changed == null)
                return;

            changed.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion
    }
}
