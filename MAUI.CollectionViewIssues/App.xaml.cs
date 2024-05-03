namespace QApp.UI
{
    public partial class App : Application
    {
        

        public App()
        {
            InitializeComponent();

            MainPage = new AppShell();
        }

        protected override void OnStart()
        {
            base.OnStart();
            //var res = await _appVersionRepo.IsNewVersionAvailable();
            //FirebaseAnalyticsService.Log(AnalyticsEvents.Status_Api_Invoked.ToString());
            //if (res != null)
            //{
            //    if(res.IsNewVersionAvailable && res.)
            //    await Shell.Current.DisplayAlert("New version available", "Update to the latest version", "Ok");
            //    Application.Current.Quit();
            //}
        }
    }
}