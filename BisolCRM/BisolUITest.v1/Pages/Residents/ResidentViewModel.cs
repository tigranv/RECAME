using BisolCRM.DAL;
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
        private ObservableCollection<fnRESIDENTCONTRACT> _residentsList;
        private FilterRESIDENTCONTRACT _filter;
        private bool _isDataLoading;
        private ObservableCollection<TAWDBBRANCH> _branches;
        private TAWDBBRANCH _selectedBranch;



        #region Properties
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

        public FilterRESIDENTCONTRACT Filter
        {
            get { return _filter; }
            set
            {
                _filter = value;
                OnPropertyChanged("Filter");
            }
        }

        public bool IsDataLoading
        {
            get { return _isDataLoading; }
            set
            {
                _isDataLoading = value;
                OnPropertyChanged("IsDataLoading");
            }
        }

        public ObservableCollection<TAWDBBRANCH> Branches
        {
            get { return _branches; }
            set
            {
                _branches = value;
                OnPropertyChanged("Branches");
            }
        }

        public TAWDBBRANCH SelectedBranch
        {
            get { return _selectedBranch; }
            set
            {
                _selectedBranch = value;
                OnPropertyChanged("SelectedBranch");
            }
        }
        #endregion

        public ResidentViewModel()
        {
            ResidentsList = new ObservableCollection<fnRESIDENTCONTRACT>();
            Filter = new FilterRESIDENTCONTRACT();
            IsDataLoading = false;
            using (var BDal = new BaseDal())
            {
                Branches = new ObservableCollection<TAWDBBRANCH>(BDal.TAWDBBRANCHDal.GetTAWDBBRANCHs());
                
            }
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

        private ICommand _convertToPDFCommand;
        public ICommand ConvertToPDFCommand
        {
            get
            {
                return _convertToPDFCommand ?? (_convertToPDFCommand = new RelayCommand(ConvertToPDFExecute));
            }
        }

        private ICommand _loadDataCommand;
        public ICommand LoadDataCommand
        {
            get
            {
                return _loadDataCommand ?? (_loadDataCommand = new RelayCommand(LoadDataExecute));
            }
        }

        private ICommand _addNewCommand;
        public ICommand AddNewCommand
        {
            get
            {
                return _addNewCommand ?? (_addNewCommand = new RelayCommand(AddNewExecute));
            }
        }

        private ICommand _editCommand;
        public ICommand EditCommand
        {
            get
            {
                return _editCommand ?? (_editCommand = new RelayCommand(EditExecute));
            }
        }

        private ICommand _deleteCommand;
        public ICommand DeleteCommand
        {
            get
            {
                return _deleteCommand ?? (_deleteCommand = new RelayCommand(DeleteExecute));
            }
        }

        private ICommand _onOkCommand;
        public ICommand OnOkCommand
        {
            get
            {
                return _onOkCommand ?? (_onOkCommand = new RelayCommand(OnOkExecute));
            }
        }

        private ICommand _onClearFilterCommand;
        public ICommand OnClearFilterCommand
        {
            get
            {
                return _onClearFilterCommand ?? (_onClearFilterCommand = new RelayCommand(OnClearFilterExecute));
            }
        }
        #endregion

        #region Executions
        private async void ConvertToXlsExecute(object obj)
        {
            //show dialog
            var dlg = new System.Windows.Forms.FolderBrowserDialog();
            System.Windows.Forms.DialogResult result = dlg.ShowDialog();
            if (result != System.Windows.Forms.DialogResult.OK) return;

            IsDataLoading = true;

            var path = dlg.SelectedPath;
            await Task.Run(() => XlsConverters.CreateExcelDoc(ResidentsList.ToList(), path));
            IsDataLoading = false;

        }

        private async void ConvertToPDFExecute(object obj)
        {
            //show dialog
            var dlg = new System.Windows.Forms.FolderBrowserDialog();
            System.Windows.Forms.DialogResult result = dlg.ShowDialog();
            if (result != System.Windows.Forms.DialogResult.OK) return;
            IsDataLoading = true;
            var path = dlg.SelectedPath;
            await Task.Run(() => XlsConverters.CreateExcelDoc(ResidentsList.ToList(), path));
            IsDataLoading = false;

        }

        private async void LoadDataExecute(object obj)
        {
            IsDataLoading = true;
            ResidentsList = new ObservableCollection<fnRESIDENTCONTRACT>(await LoadReport());
            IsDataLoading = false;
        }

        private async void AddNewExecute(object obj)
        {
            
        }

        private async void EditExecute(object obj)
        {
           
        }

        private async void DeleteExecute(object obj)
        {
        }

        private async void OnOkExecute(object obj)
        {
            ConfigureFilter();

            IsDataLoading = true;
            ResidentsList = new ObservableCollection<fnRESIDENTCONTRACT>(await LoadReport());
            IsDataLoading = false;
        }

        private void OnClearFilterExecute(object obj)
        {
            Filter = new FilterRESIDENTCONTRACT();
        }
        #endregion

        #region Private Methods
        private async Task<List<fnRESIDENTCONTRACT>> LoadReport()
        {
            using (var BDal = new BaseDal())
            {
                var list = await Task.Run(() => BDal.RESIDENTCONTRACTDal.GetRESIDENTCONTRACTs(Filter));
                //var list = await Task.Run(() => GetResidentTestList());
                return list;
            }
        }

        private void ConfigureFilter()
        {
            Filter.MaxRows = 1000;
            if (SelectedBranch != null) Filter.BranchId = SelectedBranch.ID;

        }


        private List<fnRESIDENTCONTRACT> GetResidentTestList()
        {
            var list = new List<fnRESIDENTCONTRACT>();

            for (int i = 0; i < 1000; i++)
            {
                var resident = new fnRESIDENTCONTRACT() { ID = i, BRANCH = i, CITY = 1111, FAMILY = "fffff", FATHERNAME = "gggg", STREET = "yyyy", HOUSE = "tttt", NAME = "nnnn" };
                list.Add(resident);
                Thread.Sleep(5);
            }
            return list;
        }

        #endregion

    }
}
