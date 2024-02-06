namespace DialogClosesWindows
{
    public partial class MainPage : ContentPage
    {
        int count = 0;

        public MainPage()
        {
            InitializeComponent();
        }

        private async void OnCounterClicked(object sender, EventArgs e)
        {
            var contact = await Microsoft.Maui.ApplicationModel.Communication.Contacts.Default.PickContactAsync();

            if (contact != null)
            {
                var phones = contact.Phones.Select(x => x.PhoneNumber).ToList();

                if (phones.Count > 1)
                {
                    await Task.Delay(1000);
                    string res = await Application.Current.MainPage.DisplayActionSheet("chosse a number", "cancel", null, [.. phones]);
                }
            }
        }
    }

}
