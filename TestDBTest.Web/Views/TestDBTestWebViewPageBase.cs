using Abp.Web.Mvc.Views;

namespace TestDBTest.Web.Views
{
    public abstract class TestDBTestWebViewPageBase : TestDBTestWebViewPageBase<dynamic>
    {

    }

    public abstract class TestDBTestWebViewPageBase<TModel> : AbpWebViewPage<TModel>
    {
        protected TestDBTestWebViewPageBase()
        {
            LocalizationSourceName = TestDBTestConsts.LocalizationSourceName;
        }
    }
}