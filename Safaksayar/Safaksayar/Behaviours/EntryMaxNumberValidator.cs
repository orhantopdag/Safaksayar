using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace Safaksayar.Behaviours
{
    class EntryMaxNumberValidator : Behavior<Entry>
    {
        public int MaxNumber { get; set; }

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
            int a;
            // if Entry text is longer then valid length
            if (entry.Text!="")
            {
                if (Int32.TryParse(entry.Text, out a))
                {


                    if (Convert.ToInt32(entry.Text) > this.MaxNumber)
                    {

                        string entryText = entry.Text;

                        entryText = MaxNumber.ToString(); // remove last char

                        entry.Text = entryText;
                    }
                }
            }
        }
    }
}
