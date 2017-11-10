﻿using BisolCRM.DAL;
using BisolCRM.DAL.DataContracts.Filters;
using BisolCRM.DAL.Repository.Core;
using BisolUITest.v1.Helpers;
using FirstFloor.ModernUI.Presentation;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Threading;

namespace BisolUITest.v1.Pages.Residents
{
    class ResidentViewModel : NotifyPropertyChanged
    {
        public ObservableCollection<fnRESIDENTCONTRACT> _residentsList;
        public FilterRESIDENTCONTRACT filter = new FilterRESIDENTCONTRACT();
        //private BackgroundWorker backgroundWorker = new BackgroundWorker();

        private bool _progresBarFlag;
        public bool ProgresBarFlag
        {
            get { return _progresBarFlag; }
            set
            {
                _progresBarFlag = value;
                OnPropertyChanged("ProgresBarFlag");
            }
        }


        public ResidentViewModel()
        {
            using (var BDal = new BaseDal())
            {
                filter.MaxRows = 1000;
                //ResidentsList = new ObservableCollection<fnRESIDENTCONTRACT>(GetResidentTestList());
                //ResidentsList = new ObservableCollection<fnRESIDENTCONTRACT>(BDal.RESIDENTCONTRACTDal.GetRESIDENTCONTRACTs(filter));

            }
            //backgroundWorker.DoWork += DoWork;
            // not required for this question, but is a helpful event to handle

        }


        //private void DoWork(object sender, DoWorkEventArgs e)
        //{
            
        //}

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


        private List<fnRESIDENTCONTRACT> GetResidentTestList()
        {
            var list = new List<fnRESIDENTCONTRACT>();

            for (int i = 0; i < 1000; i++)
            {
                var resident = new fnRESIDENTCONTRACT() { ID = i, BRANCH = i, CITY = 1111, FAMILY = "fffff", FATHERNAME = "gggg", STREET = "yyyy", HOUSE = "tttt", NAME = "nnnn" };
                list.Add(resident);
                //Thread.Sleep(10);
            }
            return list;
        }

        private async Task<List<fnRESIDENTCONTRACT>> LoadReport()
        {
            var invoices = await Task.Run(() => GetResidentTestList());
            return invoices;
        }

        #region Commands
        private ICommand _convertToXlsCommand;

        public ICommand ConvertToXlsCommand
        {
            get
            {
                return _convertToXlsCommand ?? (_convertToXlsCommand = new RelayCommand(ConvertToXlsExecute));
            }
        }

        private async void ConvertToXlsExecute(object obj)
        {
            Converters.CreateExcelDoc(GetResidentTestList());
            //ProgresBarFlag = true;
            //ResidentsList = new ObservableCollection<fnRESIDENTCONTRACT>(await LoadReport());
            //ProgresBarFlag = false;
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

        private ObservableCollection<Man> _animals = new ObservableCollection<Man>
        { new Man() {Id = 1, Name = "name1" }, new Man() {Id = 2, Name = "name2" } };

        public ObservableCollection<Man> Animals
        {
            get { return _animals; }
        }

        private Man _selectedAnimal;
        public Man SelectedAnimal
        {
            get { return _selectedAnimal; }
            set
            {
                _selectedAnimal = value;
                OnPropertyChanged("SelectedAnimal");
            }
        }

        private ObservableCollection<Man> _selectedAnimals;
        public ObservableCollection<Man> SelectedAnimals
        {
            get
            {
                if (_selectedAnimals == null)
                {
                    _selectedAnimals = new ObservableCollection<Man>();
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


        private static string WriteSelectedAnimalsString(IList<Man> list)
        {
            if (list.Count == 0)
                return String.Empty;

            StringBuilder builder = new StringBuilder(list[0].Name);

            for (int i = 1; i < list.Count; i++)
            {
                builder.Append(", ");
                builder.Append(list[i].Name);
            }

            return builder.ToString();
        }
        #endregion
    }
}
