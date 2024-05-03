using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using QApp.UI.Models;
using System.Collections.ObjectModel;
using System.ComponentModel;

namespace QApp.UI.ViewModels.Business
{
    public partial class BusServiceListViewModel : ObservableObject, INotifyPropertyChanged
    {
        [ObservableProperty]
        ObservableCollection<ServiceCatUIModel> _serviceCats;

        [ObservableProperty]
        bool _isBusy;

        [ObservableProperty]
        bool _isEditAllowed;

        [ObservableProperty]
        bool _isDataChanged;

        public BusServiceListViewModel()
        {
            ServiceCats = new ObservableCollection<ServiceCatUIModel>();
        }

        public async Task Initialize()
        {
            IsBusy = true;
            IsDataChanged = false;
            IsEditAllowed = true;

            await LoadData();

            IsBusy = false;
        }

        private async Task LoadData()
        {
            ServiceCats.Clear();
            var data = new List<ServiceCatModel>()
            {
                new()
                {
                     CatId=1,
                     CatName="Category1",
                     Services=
                     [
                         new()
                         {
                              SvcId=1,
                              SvcName="Service 1"
                         },
                         new()
                         {
                              SvcId=1,
                              SvcName="Service 2"
                         }
                     ]
                },
                                new()
                {
                     CatId=1,
                     CatName="Category2",
                     Services=
                     [
                         new()
                         {
                              SvcId=1,
                              SvcName="Service 3"
                         },
                         new()
                         {
                              SvcId=1,
                              SvcName="Service 4"
                         }
                     ]
                },
                                                new()
                {
                     CatId=1,
                     CatName="Category3",
                     Services=
                     [
                         new()
                         {
                              SvcId=1,
                              SvcName="Service 5"
                         },
                         new()
                         {
                              SvcId=1,
                              SvcName="Service 6"
                         }
                     ]
                }
            };

            data.ForEach(x =>
            {
                var services = x.Services.Select(x => new ServiceUIModel()
                {
                    SvcId = x.SvcId,
                    SvcName = x.SvcName,
                    Duration = x.Duration,
                    Price = x.Price,
                    IsPopular = x.IsPopular,
                    IsActive = x.IsActive
                });

                ServiceCats.Add(new ServiceCatUIModel(services.ToList())
                {
                    CatId = x.CatId,
                    CatName = x.CatName
                });
            }
            );
        }

        [RelayCommand]
        async Task AddService(ServiceCatUIModel cat)
        {
            IsBusy = true;
            cat.Add(new()
            {
                SvcId = 10,
                SvcName = "Newly added"
            });
            IsBusy = false;
            await Shell.Current.DisplayAlert("Message", $"Added a new service under category [{cat.CatName}].\n\n Services Count from List<Object> is " + cat.Count, "Ok");
        }

        [RelayCommand]
        async Task ServiceSelected(CollectionView cv)
        {
            IsBusy = true;

            var service = (ServiceUIModel)cv.SelectedItem;
            bool x = await Application.Current.MainPage.DisplayAlert("Delete?", "Do you want to delete the service?", "Yes", "No");
            if (x == true)
            {
                var cat = ServiceCats.ToList().Where(x => x.Contains(service)).FirstOrDefault();
                cat.Remove(service);
                await Shell.Current.DisplayAlert("Message", $"Removed service from category [{cat.CatName}].\n\n Services Count from List<Object> is " + cat.Count, "Ok");
            }

            
            IsBusy = false;
        }
    }
}