using System;
using System.Collections.ObjectModel;
using System.Linq;
using MVVMSidekick.Utilities;
using MVVMSidekick.ViewModels;
using WuxiPostal.Models;
using WuxiPostal.Repository;

namespace WuxiPostal.ViewModels
{
    public class SearchResultByDistrictName_Model : ViewModelBase<SearchResultByDistrictName_Model>
    {
        public SearchResultByDistrictName_Model()
        {
            if (IsInDesignMode)
            {
                DistrictTerm = "测试路";
            }

            InitData("哈哈");
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


        public ObservableCollection<Group<PostCodeSearchResult>> GroupedSearchResult
        {
            get { return _GroupedSearchResultLocator(this).Value; }
            set { _GroupedSearchResultLocator(this).SetValueAndTryNotify(value); }
        }
        #region Property ObservableCollection<AlphaKeyGroup<PostalCode>> GroupedSearchResult Setup
        protected Property<ObservableCollection<Group<PostCodeSearchResult>>> _GroupedSearchResult = new Property<ObservableCollection<Group<PostCodeSearchResult>>> { LocatorFunc = _GroupedSearchResultLocator };
        static Func<BindableBase, ValueContainer<ObservableCollection<Group<PostCodeSearchResult>>>> _GroupedSearchResultLocator = RegisterContainerLocator<ObservableCollection<Group<PostCodeSearchResult>>>("GroupedSearchResult", model => model.Initialize("GroupedSearchResult", ref model._GroupedSearchResult, ref _GroupedSearchResultLocator, _GroupedSearchResultDefaultValueFactory));
        static Func<ObservableCollection<Group<PostCodeSearchResult>>> _GroupedSearchResultDefaultValueFactory = () => { return default(ObservableCollection<Group<PostCodeSearchResult>>); };
        #endregion

        public void InitData(string districtTerm)
        {
            DistrictTerm = districtTerm;

            var result = WuXiPostalContext.Instance.PostalCodes
                                              .Where(p => p.Addresses.Any(a => a.Contains(districtTerm)));

            var postalCodes = result as PostalCode[] ?? result.ToArray();
            var postCodeSearchResults = (from postalCode in postalCodes
                                         from address in postalCode.Addresses.Where(a => a.Contains(districtTerm))
                                         select new PostCodeSearchResult()
                                         {
                                             Address = address,
                                             Code = postalCode.Code
                                         }).ToList();

            var sGroup = Group<PostCodeSearchResult>.GetItemGroups(postCodeSearchResults, _ => _.Code);

            GroupedSearchResult = sGroup.ToObservableCollection();
        }
    }
}

