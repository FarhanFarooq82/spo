using BeoRecruitment.Views;

namespace BeoRecruitment
{
    public partial class MainNavigationPage : NavigationPage
    {
        public MainNavigationPage(MainPage root) : base(root)
        {
            SetDynamicResource(BarBackgroundColorProperty, "Primary");
        }
    }
}
