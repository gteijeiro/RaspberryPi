using Sensors.Dht;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Devices.Gpio;

namespace DemoClima
{
    public class WeatherLogic
    {
        #region Properties Privates

        private int _pinInput;

        #endregion

        #region Propeties Public

        #endregion

        #region Build

        public WeatherLogic(int pPinInput)
        {
            this._pinInput = pPinInput;
        }

        public WeatherLogic()
        {
            this._pinInput = 4;
        }

        #endregion

        #region Methods Public

        public async Task<WeatherEntity> GetWeatherAsync()
        {
            GpioPin _pinOpen = null;
            Dht11 dht11 = null;          
            try
            {


                var weather = new WeatherEntity();

                _pinOpen = GpioController.GetDefault().OpenPin(_pinInput, GpioSharingMode.Exclusive);

                dht11 = new Dht11(_pinOpen, GpioPinDriveMode.Input);


                DhtReading reading = await dht11.GetReadingAsync();
                
                if (reading.IsValid)
                {
                    weather.Humidity = reading.Humidity.ToString();
                    weather.Temperature = reading.Temperature.ToString();
                    weather.LastUpdate = DateTime.Now.ToString();
                }
                else
                {
                    weather.Humidity = string.Empty;
                    weather.Temperature = string.Empty;
                    weather.LastUpdate = string.Empty;
                }

                _pinOpen.Dispose();
                dht11.Dispose();


                return weather;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                _pinOpen.Dispose();
                dht11.Dispose();
            }
        }

        #endregion

        #region Methods privates

        #endregion

        #region Dispose

        #endregion

    }
}
