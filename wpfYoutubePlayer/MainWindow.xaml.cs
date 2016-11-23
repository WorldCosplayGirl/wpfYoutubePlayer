using System;
using System.Windows;
using System.Windows.Navigation;

namespace wpfYoutubePlayer
{
    /// <summary>
    /// MainWindow.xaml 的互動邏輯
    /// </summary>
    public partial class MainWindow : Window
    {
        Panel pn = new Panel();

        public MainWindow()
        {
            InitializeComponent();

            InitPlayer();
        }

        //初始化
        void InitPlayer()
        {
            wbPlayer.Height = Form.Height;
            wbPlayer.Width = Form.Width;
        }

        private void Window_KeyDown(object sender, System.Windows.Input.KeyEventArgs e)
        {
            switch (e.Key.ToString())
            {
                case "NumPad0":
                    var dresult = pn.ShowDialog();
                    if ( dresult == System.Windows.Forms.DialogResult.OK)
                    {
                        //預防相同連結重整
                        if (wbPlayer.Source != new Uri(pn.rtnval))
                            wbPlayer.Source = new Uri(pn.rtnval);

                        Form.Topmost = pn.topest;
                    }
                    else if( dresult == System.Windows.Forms.DialogResult.Retry )
                    {
                        wbPlayer.Refresh();
                    }
                    break;

                case "NumPad1":
                    SetWinSize(25);
                    break;

                case "NumPad2":
                    SetWinSize(50);
                    break;

                case "NumPad3":
                    SetWinSize(75);
                    break;

                case "NumPad4":
                    SetWinSize(100);
                    Form.Top = 0;
                    break;
            }
        }

        void SetWinSize(int rate)
        {
            double h = System.Windows.SystemParameters.PrimaryScreenHeight;
            double w = System.Windows.SystemParameters.PrimaryScreenWidth;

            Form.Height = wbPlayer.Height = h * rate * 0.01;
            Form.Width = wbPlayer.Width = w * rate * 0.01;
        }
    }
}
