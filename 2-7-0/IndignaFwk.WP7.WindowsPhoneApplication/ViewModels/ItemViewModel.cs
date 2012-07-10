using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using Microsoft.Phone.Controls.Maps;
using System.Device.Location;
using Microsoft.Phone.Controls.Maps.Platform;

namespace IndignaFwk_WP7_WindowsPhoneApplication
{
    public class ItemViewModel : INotifyPropertyChanged 
    {
        private string _lineOne;
        /// <summary>
        /// Sample ViewModel property; this property is used in the view to display its value using a Binding.
        /// </summary>
        /// <returns></returns>
        public string LineOne 
        {
            get 
            {
                return _lineOne;
            }
            set 
            {
                _lineOne = value;
                NotifyPropertyChanged("LineOne");
            }
        }
        
        private string _lineTwo;
        /// <summary>
        /// Sample ViewModel property; this property is used in the view to display its value using a Binding.
        /// </summary>
        /// <returns></returns>
        public string LineTwo
        {
            get
            {
                return _lineTwo;
            }
            set
            {
                _lineTwo = value;
                NotifyPropertyChanged("LineTwo");
            }
        }

        private string _lineThree;
        /// <summary>
        /// Sample ViewModel property; this property is used in the view to display its value using a Binding.
        /// </summary>
        /// <returns></returns>
        public string LineThree
        {
            get
            {
                return _lineThree;
            }
            set
            {
                _lineThree = value;
                NotifyPropertyChanged("LineThree");
            }
        }

        private string _lineFour;
        /// <summary>
        /// Sample ViewModel property; this property is used in the view to display its value using a Binding.
        /// </summary>
        /// <returns></returns>
        public string LineFour
        {
            get
            {
                return _lineFour;
            }
            set
            {
                _lineFour = value;
                NotifyPropertyChanged("LineFour");
            }
        }

        private string _lineFive;
        /// <summary>
        /// Sample ViewModel property; this property is used in the view to display its value using a Binding.
        /// </summary>
        /// <returns></returns>
        public string LineFive
        {
            get
            {
                return _lineFive;
            }
            set
            {
                _lineFive = value;
                NotifyPropertyChanged("LineFive");
            }
        }

        private Map _lineSix;

        public Map LineSix
        {
            get
            {
                return _lineSix;
            }
            set
            {
                _lineSix = value;
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        private void NotifyPropertyChanged(String propertyName) 
        {
            if (null != PropertyChanged) 
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}