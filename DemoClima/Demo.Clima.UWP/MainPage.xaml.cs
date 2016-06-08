using DemoClima;
using DemoClima.Logic;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace Demo.Clima.UWP
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        DispatcherTimer timer = null;
        bool isEnable = false;

        public MainPage()
        {
            timer = new DispatcherTimer();
            timer.Interval = new TimeSpan(0, 0, 5);
            timer.Tick += Timer_Tick;
            timer.Start();
            this.InitializeComponent();            
        }

        private void Timer_Tick(object sender, object e)
        {
            this.CallSensor();
        }

        private async void CallSensor()
        {
            try
            {
                var weather = new WeatherLogic();
                var resultSensor = await weather.GetWeatherAsync();

                if(!string.IsNullOrWhiteSpace(resultSensor.Humidity))
                {
                    txtHumidity.Text = resultSensor.Humidity;
                }

                if (!string.IsNullOrWhiteSpace(resultSensor.Temperature))
                {
                    txtTemperature.Text = resultSensor.Temperature + "C°";
                }
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        private void btnEnable_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var light = new LightLogic();
                var enable = isEnable ? true : false;
                light.SetLightAsync(enable);

                isEnable = !enable;

                if (isEnable)
                {
                    btnEnable.Content = "Deshabilitar";
                }
                else
                {
                    btnEnable.Content = "Habilitar";
                }
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }
    }
}
