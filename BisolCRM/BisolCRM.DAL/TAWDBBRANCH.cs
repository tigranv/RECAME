//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace BisolCRM.DAL
{
    using System;
    using System.Collections.Generic;
    
    public partial class TAWDBBRANCH
    {
        public int ID { get; set; }
        public string APPARTMENT { get; set; }
        public Nullable<int> CITY { get; set; }
        public string COMMUNE { get; set; }
        public string EMAIL { get; set; }
        public string ENTRANCE { get; set; }
        public string FLOOR { get; set; }
        public string HOUSE { get; set; }
        public string SECTION { get; set; }
        public string STREET { get; set; }
        public string TOC1 { get; set; }
        public string TOC2 { get; set; }
        public string ZIP { get; set; }
        public Nullable<System.DateTime> CREATEDATE { get; set; }
        public Nullable<System.DateTime> DESTROYDATE { get; set; }
        public Nullable<double> GARDENSQUAREDEFAULT { get; set; }
        public Nullable<System.DateTime> LASTMODIFIED { get; set; }
        public Nullable<int> LISTINDEX { get; set; }
        public Nullable<decimal> MAXDRAINAGETARIFF { get; set; }
        public Nullable<decimal> MAXIRRIGATIONTARIFF { get; set; }
        public Nullable<decimal> MAXWATERTARIFF { get; set; }
        public Nullable<decimal> MINDRAINAGETARIFF { get; set; }
        public Nullable<decimal> MINIRRIGATIONTARIFF { get; set; }
        public Nullable<decimal> MINWATERTARIFF { get; set; }
        public string NAME { get; set; }
        public Nullable<int> PARENTBRANCH { get; set; }
        public Nullable<double> RESDEFAULT { get; set; }
        public Nullable<double> SQUAREDEFAULT { get; set; }
        public Nullable<double> VATAX { get; set; }
        public Nullable<double> WATERSPEED { get; set; }
        public Nullable<double> YARDTAPDEFAULT { get; set; }
        public Nullable<short> DISABLECONDOMINIUMS { get; set; }
        public Nullable<int> CURRENTINTERVAL { get; set; }
        public Nullable<short> STANDALONE { get; set; }
        public string TPID { get; set; }
        public Nullable<short> COUNTERCHECKPERIOD { get; set; }
        public Nullable<System.DateTime> CANONDATE { get; set; }
        public Nullable<double> COMMONRESDEFAULT { get; set; }
        public Nullable<double> COMMONRESDEFAULTCISBRANCH { get; set; }
        public Nullable<double> MAXBUILDINGTUBEGOODS { get; set; }
        public Nullable<double> MAXCONDOMINIUMGOODS { get; set; }
        public Nullable<double> MAXCONDOMINIUMGOODSCISBRANCH { get; set; }
        public Nullable<double> MAXPRIVATETUBEGOODS { get; set; }
        public Nullable<double> PRIVATERESDEFAULT { get; set; }
        public Nullable<double> PRIVATERESDEFAULTCISBRANCH { get; set; }
        public Nullable<double> RESDEFAULTCISBRANCH { get; set; }
        public Nullable<short> ALLOWCLEANUP { get; set; }
        public Nullable<short> ALLOWCONTRACTMOVING { get; set; }
        public Nullable<short> ALLOWEXPORTCHANGE { get; set; }
        public Nullable<short> ALLOWEXPORTLIB { get; set; }
        public Nullable<short> ALLOWEXPORTWHOLE { get; set; }
        public Nullable<short> ALLOWINSTALLPACK { get; set; }
        public Nullable<short> ALLOWOWNCONTRACTS { get; set; }
        public Nullable<short> ALLOWSUBBRANCHES { get; set; }
        public Nullable<short> APPLYPENALTY { get; set; }
        public Nullable<double> MAXPENALTY { get; set; }
        public Nullable<short> CHECKDUPLICATEPAYMENTS { get; set; }
        public Nullable<short> USEOLDDEBTMECHANISM { get; set; }
        public string TOC3 { get; set; }
        public string VATNUMBER { get; set; }
        public Nullable<decimal> MAXAVERAGEGOODS { get; set; }
        public Nullable<int> AVAILABLEDATAINTERVAL { get; set; }
        public Nullable<System.DateTime> AVAILABLEDATACURRENTDATE { get; set; }
        public Nullable<double> LONGITUDE { get; set; }
        public Nullable<double> LATITUDE { get; set; }
        public string CENTER_GEOM { get; set; }
        public string SHAPE_GEOM { get; set; }
    }
}
