using System;
using System.Linq;
using MVVMSidekick.ViewModels;
using WuxiPostal.Models;
using WuxiPostal.Repository;

namespace WuxiPostal.ViewModels
{
    public class PostalCodeDetail_Model : ViewModelBase<PostalCodeDetail_Model>
    {
        public PostalCodeDetail_Model()
        {
            if (IsInDesignMode)
            {
                PostalCode = WuXiPostalContext.Instance.PostalCodes.First();
            }
        }

        public PostalCode PostalCode
        {
            get { return _PostalCodeLocator(this).Value; }
            set { _PostalCodeLocator(this).SetValueAndTryNotify(value); }
        }
        #region Property PostalCode PostalCode Setup
        protected Property<PostalCode> _PostalCode = new Property<PostalCode> { LocatorFunc = _PostalCodeLocator };
        static Func<BindableBase, ValueContainer<PostalCode>> _PostalCodeLocator = RegisterContainerLocator<PostalCode>("PostalCode", model => model.Initialize("PostalCode", ref model._PostalCode, ref _PostalCodeLocator, _PostalCodeDefaultValueFactory));
        static Func<PostalCode> _PostalCodeDefaultValueFactory = () => { return default(PostalCode); };
        #endregion

        public void InitData(string pCode)
        {
            if (!string.IsNullOrEmpty(pCode))
            {
                var postalCode = WuXiPostalContext.Instance.PostalCodes.FirstOrDefault(p => p.Code == pCode);
                if (null != postalCode)
                {
                    PostalCode = postalCode;
                }
            }
        }
    }
}

