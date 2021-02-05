using System;
using System.Collections.Generic;
using System.Text;

namespace Safaksayar.Models
{
    public enum MenuItemType
    {
        Browse,
        Updater,
        fikra
    }
    public class HomeMenuItem
    {
        public MenuItemType Id { get; set; }

        public string Title { get; set; }
    }
}
