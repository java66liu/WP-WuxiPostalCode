using System;
using System.Collections.ObjectModel;
using System.Linq;
using MVVMSidekick.Utilities;
using MVVMSidekick.ViewModels;
using WuxiPostal.Models;
using WuxiPostal.Repository;

namespace WuxiPostal.ViewModels
{
    public class MainPage_Model : ViewModelBase<MainPage_Model>
    {
        public MainPage_Model()
        {
            Districts = (WuXiPostalContext.Instance).Districts.OrderBy(d => d.Name).ToObservableCollection();
            PostalCodes = (WuXiPostalContext.Instance).PostalCodes.OrderBy(p => p.Code).ToObservableCollection();
        }

        public ObservableCollection<string> Fuckers
        {
            get { return _FuckersLocator(this).Value; }
            set { _FuckersLocator(this).SetValueAndTryNotify(value); }
        }
        #region Property ObservableCollection<string> Fuckers Setup
        protected Property<ObservableCollection<string>> _Fuckers = new Property<ObservableCollection<string>> { LocatorFunc = _FuckersLocator };
        static Func<BindableBase, ValueContainer<ObservableCollection<string>>> _FuckersLocator = RegisterContainerLocator<ObservableCollection<string>>("Fuckers", model => model.Initialize("Fuckers", ref model._Fuckers, ref _FuckersLocator, _FuckersDefaultValueFactory));
        static Func<ObservableCollection<string>> _FuckersDefaultValueFactory = () => { return default(ObservableCollection<string>); };
        #endregion


        public ObservableCollection<District> Districts
        {
            get { return _DistrictsLocator(this).Value; }
            set { _DistrictsLocator(this).SetValueAndTryNotify(value); }
        }
        #region Property ObservableCollection<District> Districts Setup
        protected Property<ObservableCollection<District>> _Districts = new Property<ObservableCollection<District>> { LocatorFunc = _DistrictsLocator };
        static Func<BindableBase, ValueContainer<ObservableCollection<District>>> _DistrictsLocator = RegisterContainerLocator<ObservableCollection<District>>("Districts", model => model.Initialize("Districts", ref model._Districts, ref _DistrictsLocator, _DistrictsDefaultValueFactory));
        static Func<ObservableCollection<District>> _DistrictsDefaultValueFactory = () => { return default(ObservableCollection<District>); };
        #endregion

        public ObservableCollection<PostalCode> PostalCodes
        {
            get { return _PostalCodesLocator(this).Value; }
            set { _PostalCodesLocator(this).SetValueAndTryNotify(value); }
        }
        #region Property ObservableCollection<PostalCode> PostalCodes Setup
        protected Property<ObservableCollection<PostalCode>> _PostalCodes = new Property<ObservableCollection<PostalCode>> { LocatorFunc = _PostalCodesLocator };
        static Func<BindableBase, ValueContainer<ObservableCollection<PostalCode>>> _PostalCodesLocator = RegisterContainerLocator<ObservableCollection<PostalCode>>("PostalCodes", model => model.Initialize("PostalCodes", ref model._PostalCodes, ref _PostalCodesLocator, _PostalCodesDefaultValueFactory));
        static Func<ObservableCollection<PostalCode>> _PostalCodesDefaultValueFactory = () => { return default(ObservableCollection<PostalCode>); };
        #endregion
    }
}

