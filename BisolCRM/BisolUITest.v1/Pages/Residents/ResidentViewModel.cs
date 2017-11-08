using BisolCRM.DAL;
using BisolCRM.DAL.DataContracts.Filters;
using BisolCRM.DAL.Repository.Core;
using FirstFloor.ModernUI.Presentation;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows.Media;

namespace BisolUITest.v1.Pages.Residents
{
    class ResidentViewModel : NotifyPropertyChanged
    {
        public ObservableCollection<fnRESIDENTCONTRACT> _residentsList;
        public FilterRESIDENTCONTRACT filter = new FilterRESIDENTCONTRACT();



        public ResidentViewModel()
        {
            using (var BDal = new BaseDal())
            {
                filter.MaxRows = 1000;
                //ResidentsList = new ObservableCollection<fnRESIDENTCONTRACT>(GetResidentTestList());
                //ResidentsList = new ObservableCollection<fnRESIDENTCONTRACT>(BDal.RESIDENTCONTRACTDal.GetRESIDENTCONTRACTs(filter));

            }


        }



        public ObservableCollection<fnRESIDENTCONTRACT> ResidentsList
        {
            get { return this._residentsList; }
            set
            {
                if (this._residentsList != value)
                {
                    this._residentsList = value;
                    OnPropertyChanged("ResidentsList");
                }
            }
        }


        //public Link SelectedTheme
        //{
        //    get { return this.selectedTheme; }
        //    set
        //    {
        //        if (this.selectedTheme != value)
        //        {
        //            this.selectedTheme = value;
        //            OnPropertyChanged("SelectedTheme");

        //        }
        //    }
        //}

        private List<fnRESIDENTCONTRACT> GetResidentTestList()
        {
            var list = new List<fnRESIDENTCONTRACT>();

            for (int i = 0; i < 100; i++)
            {
                var resident = new fnRESIDENTCONTRACT() {ID = i, BRANCH = i, CITY = 1111, FAMILY = "fffff", FATHERNAME = "gggg", STREET = "yyyy", HOUSE = "tttt", NAME = "nnnn" };
                list.Add(resident);
            }

            return list;
        }

        #region Commands
        private ICommand _convertToXlsCommand;

        public ICommand ConvertToXlsCommand
        {
            get { return _convertToXlsCommand ?? (_convertToXlsCommand = new RelayCommand(ConvertToXlsExecute)); }
        }

        private void ConvertToXlsExecute(object obj)
        {
            ResidentsList = new ObservableCollection<fnRESIDENTCONTRACT>(GetResidentTestList());

        }


        #endregion

        #region combobox
        #region INotifyPropertyChanged Members

        //public event PropertyChangedEventHandler PropertyChanged;
        //private void OnPropertyChanged(string propertyName)
        //{
        //    if (PropertyChanged != null)
        //        PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        //}

        #endregion

        private ObservableCollection<string> _animals = new ObservableCollection<string>
        { "Cat", "Dog", "Bear", "Lion", "Mouse", "Horse", "Rat", "Elephant", "Kangaroo", "Lizard", "Snake", "Frog", "Fish", "Butterfly", "Human", "Cow", "Bumble Bee" };

        public ObservableCollection<string> Animals
        {
            get { return _animals; }
        }

        private string _selectedAnimal = "Cat";
        public string SelectedAnimal
        {
            get { return _selectedAnimal; }
            set
            {
                _selectedAnimal = value;
                OnPropertyChanged("SelectedAnimal");
            }
        }

        private ObservableCollection<string> _selectedAnimals;
        public ObservableCollection<string> SelectedAnimals
        {
            get
            {
                if (_selectedAnimals == null)
                {
                    _selectedAnimals = new ObservableCollection<string> { "Dog", "Lion", "Lizard" };
                    SelectedAnimalsText = WriteSelectedAnimalsString(_selectedAnimals);
                    _selectedAnimals.CollectionChanged +=
                        (s, e) =>
                        {
                            SelectedAnimalsText = WriteSelectedAnimalsString(_selectedAnimals);
                            OnPropertyChanged("SelectedAnimals");
                        };
                }
                return _selectedAnimals;
            }
            set
            {
                _selectedAnimals = value;
            }
        }

        public string SelectedAnimalsText
        {
            get { return _selectedAnimalsText; }
            set
            {
                _selectedAnimalsText = value;
                OnPropertyChanged("SelectedAnimalsText");
            }
        }
        string _selectedAnimalsText;


        private static string WriteSelectedAnimalsString(IList<string> list)
        {
            if (list.Count == 0)
                return String.Empty;

            StringBuilder builder = new StringBuilder(list[0]);

            for (int i = 1; i < list.Count; i++)
            {
                builder.Append(", ");
                builder.Append(list[i]);
            }

            return builder.ToString();
        }
        #endregion
    }
}
