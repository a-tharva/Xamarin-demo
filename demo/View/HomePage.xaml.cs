using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace demo.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class HomePage : ContentPage
    {

        public HomePage()
        {
            InitializeComponent();
        }

        private async void ButtonPickFile(object sender, EventArgs e)
        {
            var pickImage = await FilePicker.PickAsync(new PickOptions()
            {
                FileTypes = FilePickerFileType.Images,
                PickerTitle = "Pick an Image"
            });

            if(pickImage != null)
            {
                var stream = await pickImage.OpenReadAsync();
                imgFile.Source = ImageSource.FromStream(() => stream);
                fileName.Text = pickImage.FileName;
            }
        }

        async void ApiPage(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new ApiPage());
        }
    }
}