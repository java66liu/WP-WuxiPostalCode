using System;
using System.Linq;
using MVVMSidekick.Utilities;
using MVVMSidekick.ViewModels;
using WuxiPostal.Models;
using WuxiPostal.Repository;

namespace WuxiPostal.ViewModels
{
    public class DistrictDetail_Model : ViewModelBase<DistrictDetail_Model>
    {
        public DistrictDetail_Model()
        {
            if (IsInDesignMode)
            {
                District = new District()
                {
                    Id = "1",
                    Name = "测试区",
                    PostalCodes = WuXiPostalContext.Instance.PostalCodes.OrderBy(c => c.Code).Take(10).ToObservableCollection()
                };
            }
        }

        public District District
        {
            get { return _DistrictLocator(this).Value; }
            set { _DistrictLocator(this).SetValueAndTryNotify(value); }
        }
        #region Property District District Setup
        protected Property<District> _District = new Property<District> { LocatorFunc = _DistrictLocator };
        static Func<BindableBase, ValueContainer<District>> _DistrictLocator = RegisterContainerLocator<District>("District", model => model.Initialize("District", ref model._District, ref _DistrictLocator, _DistrictDefaultValueFactory));
        static Func<District> _DistrictDefaultValueFactory = () => { return default(District); };
        #endregion

        public void InitData(string dId)
        {
            if (!string.IsNullOrEmpty(dId))
            {
                var district = WuXiPostalContext.Instance.Districts.FirstOrDefault(d => d.Id == dId);
                if (null != district)
                {
                    District = district;
                }
            }
        }
    }
}

