using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using MVVMSidekick.Utilities;
using MVVMSidekick.ViewModels;
using WuxiPostal.Repository;

namespace WuxiPostal.ViewModels
{
    public class SearchForm_Model : ViewModelBase<SearchForm_Model>
    {
        public SearchForm_Model()
        {
            SuggessedPostalCodeList = new ObservableCollection<string>(new List<string>());

            var codes = WuXiPostalContext.Instance.PostalCodes.Select(s => s.Code).ToObservableCollection();

            if (codes.Any())
            {
                SuggessedPostalCodeList = codes;
            }
        }

        public string DistrictTerm
        {
            get { return _DistrictTermLocator(this).Value; }
            set { _DistrictTermLocator(this).SetValueAndTryNotify(value); }
        }
        #region Property string DistrictTerm Setup
        protected Property<string> _DistrictTerm = new Property<string> { LocatorFunc = _DistrictTermLocator };
        static Func<BindableBase, ValueContainer<string>> _DistrictTermLocator = RegisterContainerLocator<string>("DistrictTerm", model => model.Initialize("DistrictTerm", ref model._DistrictTerm, ref _DistrictTermLocator, _DistrictTermDefaultValueFactory));
        static Func<string> _DistrictTermDefaultValueFactory = () => { return default(string); };
        #endregion

        public string PostalCodeTerm
        {
            get { return _PostalCodeTermLocator(this).Value; }
            set { _PostalCodeTermLocator(this).SetValueAndTryNotify(value); }
        }
        #region Property string PostalCodeTerm Setup
        protected Property<string> _PostalCodeTerm = new Property<string> { LocatorFunc = _PostalCodeTermLocator };
        static Func<BindableBase, ValueContainer<string>> _PostalCodeTermLocator = RegisterContainerLocator<string>("PostalCodeTerm", model => model.Initialize("PostalCodeTerm", ref model._PostalCodeTerm, ref _PostalCodeTermLocator, _PostalCodeTermDefaultValueFactory));
        static Func<string> _PostalCodeTermDefaultValueFactory = () => { return default(string); };
        #endregion


        public ObservableCollection<string> SuggessedPostalCodeList
        {
            get { return _SuggessedPostalCodeListLocator(this).Value; }
            set { _SuggessedPostalCodeListLocator(this).SetValueAndTryNotify(value); }
        }
        #region Property ObservableCollection<string> SuggessedPostalCodeList Setup
        protected Property<ObservableCollection<string>> _SuggessedPostalCodeList = new Property<ObservableCollection<string>> { LocatorFunc = _SuggessedPostalCodeListLocator };
        static Func<BindableBase, ValueContainer<ObservableCollection<string>>> _SuggessedPostalCodeListLocator = RegisterContainerLocator<ObservableCollection<string>>("SuggessedPostalCodeList", model => model.Initialize("SuggessedPostalCodeList", ref model._SuggessedPostalCodeList, ref _SuggessedPostalCodeListLocator, _SuggessedPostalCodeListDefaultValueFactory));
        static Func<ObservableCollection<string>> _SuggessedPostalCodeListDefaultValueFactory = () => { return default(ObservableCollection<string>); };
        #endregion
    }
}

