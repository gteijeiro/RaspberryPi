using Sensors.Dht;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading.Tasks;
using Windows.Devices.Gpio;
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

namespace DemoTemperatura
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        private DispatcherTimer _timer = new DispatcherTimer();

        public MainPage()
        {
            _timer.Tick += _timer_Tick;
            _timer.Interval = new TimeSpan(0, 0, 5);
            _timer.Start();


            this.InitializeComponent();
        }

        public async void _timer_Tick(object sender, object e)
        {
            GpioPin _pin = GpioController.GetDefault().OpenPin(4, GpioSharingMode.Exclusive);
            Dht11 dht11 = new Dht11(_pin, GpioPinDriveMode.Input);
            DhtReading reading = await dht11.GetReadingAsync().AsTask();

            if (reading.IsValid)
            {
                txtHumedad.Text = reading.Humidity.ToString();
                txtTemperatura.Text = reading.Temperature.ToString();
            }
            _pin.Dispose();
            dht11.Dispose();
            
        }
    }
}
