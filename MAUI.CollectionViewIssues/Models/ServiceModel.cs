using CommunityToolkit.Mvvm.ComponentModel;

namespace QApp.UI.Models
{
    public class ServiceCatModel
    {
        public int CatId { get; set; }
        public string CatName { get; set; }
        public List<ServiceModel> Services { get; set; }
    }

    public class ServiceModel
    {
        public int SvcId { get; set; }
        public string SvcName { get; set; }
        public decimal Price { get; set; }
        public int Duration { get; set; }
        public bool IsPopular { get; set; }
        public bool IsActive { get; set; }

        //For UI purpose
        public bool IsSelected { get; set; }
    }

    [ObservableObject]
    public partial class ServiceCatUIModel(List<ServiceUIModel> services) : List<ServiceUIModel>(services)
    {
        [ObservableProperty]
        public int _catId;
        [ObservableProperty]
        public string _catName;
    }

    public partial class ServiceUIModel : ObservableObject
    {
        [ObservableProperty]
        public int _svcId;
        [ObservableProperty]
        public string _svcName;
        [ObservableProperty]
        public decimal _price;
        [ObservableProperty]
        public int _duration;
        [ObservableProperty]
        public bool _isPopular;
        [ObservableProperty]
        public bool _isActive;
    }
}
