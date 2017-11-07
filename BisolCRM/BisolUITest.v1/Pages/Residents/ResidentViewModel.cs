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
                ResidentsList = new ObservableCollection<fnRESIDENTCONTRACT>(GetResidentTestList());// BDal.RESIDENTCONTRACTDal.GetRESIDENTCONTRACTs(filter));

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
    }
}
