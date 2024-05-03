using QApp.UI.ViewModels.Business;

namespace QApp.UI.Pages.Business.Service;

public partial class BusServiceListPage : ContentPage
{
    private readonly BusServiceListViewModel _vm;
    public BusServiceListPage(BusServiceListViewModel vm)
    {
        InitializeComponent();
        this.BindingContext = vm;
        _vm = vm;
    }

    protected override async void OnAppearing()
    {
        base.OnAppearing();
        await _vm.Initialize();
    }
}