using Tizen.NUI;
using Tizen.NUI.BaseComponents;

namespace NUIXAMLProject1
{
    public partial class Scene1Page : View
    {
        public Scene1Page()
        {
            InitializeComponent();
            //lottieView.Play();
        }

        private void imgView_ResourceReady(object sender, ImageView.ResourceReadyEventArgs e)
        {
            //lottieView.Play();
            //imgView.AlphaMaskURL = "*Resource*/images/mask.png";
        }
    }
}
