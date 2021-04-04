namespace TestApp
{
    using System.Windows;
    using FairMark;
    using FairMark.Toolbox;
    using FairMark.TrueApi;
    using FairMark.TrueApi.DataContracts;
    using FairMark.TrueApi.DataContracts._3_4;

    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public Credentials Credentials { get; set; }
        public TrueApiClient TrueApiClient { get; set; }


        public MainWindow()
        {
            InitializeComponent();
            
            Credentials = new Credentials() { CertificateThumbprint = "aa0444c6d47220d9e77558e88c763543cd9773e2" };
            TrueApiClient = new TrueApiClient("https://int01.gismt.crpt.tech/api/v3/true-api/", Credentials);

            var cises = TrueApiClient.GetCisesByOrderId("a1769132-796e-47cb-8bc5-1053c4d7d6c5");
            return;
            //var t = TrueApiClient.Post("cises/list", , new[] { new Parameter("values","010463578558601021U6vlokgzAt0K!", ParameterType.RequestBody) });
            var t = TrueApiClient.Get("elk/product-groups/balance/all");
            var tt = TrueApiClient.Get<ProductGroupBalance[]>("elk/product-groups/balance/all");
        }


        private void Button_Click(object sender, RoutedEventArgs e)
        {
            //tbxSignedText.Text = GostCryptoHelpers.ComputeDetachedSignature(TrueApiClient.UserCertificate, tbxTextToSign.Text);
            tbxSignedText.Text = GostCryptoHelpers.ComputeAttachedSignature(TrueApiClient.UserCertificate, tbxTextToSign.Text.Trim()).Trim();
        }
    }
}
