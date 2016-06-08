using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Devices.Gpio;

namespace DemoClima.Logic
{
    public class LightLogic
    {
        #region Properties Privates

        private int _pinInput;

        // only used if we don't get a response from the webapi call.
        private const int DefaultBlinkDelay = 1000;


        #endregion

        #region Propeties Public

        #endregion

        #region Build

        public LightLogic(int pPinInput)
        {
            this._pinInput = pPinInput;
        }

        public LightLogic()
        {
            this._pinInput = 17;
        }

        #endregion

        #region Methods Public

        public async void SetLightAsync(bool pEnable)
        {
            GpioPin _pinOpen = null;
            GpioOpenStatus status;
            try
            {
                var controllerOpen = await GpioController.GetDefaultAsync();
                var isOpen = controllerOpen.TryOpenPin(_pinInput, GpioSharingMode.Exclusive, out _pinOpen, out status);
                _pinOpen.SetDriveMode(GpioPinDriveMode.OutputOpenSource);

                if (isOpen)
                {                    
                    if(status == GpioOpenStatus.PinOpened)
                    {
                        if (!pEnable)
                        {
                            //await Task.Delay(1000);
                            _pinOpen.Write(GpioPinValue.High);
                        }
                        else
                        {
                            //await Task.Delay(1000);
                            //_pinOpen.SetDriveMode(GpioPinDriveMode.Input);
                            _pinOpen.Write(GpioPinValue.Low);
                        }
                    }                   
                }

              
                _pinOpen.Dispose();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        #endregion

        #region Methods privates

        #endregion

        #region Dispose

        #endregion
    }
}
