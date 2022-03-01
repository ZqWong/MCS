using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Automation.BDaq;
using Utilities;

namespace MCS.DeviceRespond
{
    public delegate void ReceiveHandlerDI(byte[] reveiceBytes);
    public delegate void ReceiveHandlerAI(double[] reveiceDatas);

    class PCI1710
    {

        public ReceiveHandlerDI OnReceiveDI;
        public ReceiveHandlerAI OnReceiveAI;

        private string deviceDescription;
        private string profilePath;
        private int startPort;
        private int portCount;
        private int readIntervalMS;
        private byte[] lastBuffer;
        private double[] lastData;


        public PCI1710()
        {
        }

        public void InitDeviceDI(string deviceDescription, string profilePath, int startPort, int portCount, int readIntervalMS)
        {
            this.deviceDescription = deviceDescription;
            this.profilePath = profilePath;
            this.startPort = startPort;
            this.portCount = portCount;
            this.readIntervalMS = readIntervalMS;

            ErrorCode errorCode = ErrorCode.Success;
            lastBuffer = new byte[portCount];

            InstantDiCtrl instantDiCtrl;

            try
            {
                instantDiCtrl = new InstantDiCtrl();
            }
            catch (Exception e)
            {
                NlogHandler.GetSingleton().Error(string.Format("Check IO device state. Exception: {0}", e.Message.ToString()));
                return;

            }

            try
            {
                // Step 2: Select a device by device number or device description and specify the access mode.
                // in this example we use ModeWrite mode so that we can fully control the device, including configuring, sampling, etc.
                instantDiCtrl.SelectedDevice = new DeviceInformation(deviceDescription);
                errorCode = instantDiCtrl.LoadProfile(profilePath);//Loads a profile to initialize the device.
                if (BioFailed(errorCode))
                {
                    //Console.WriteLine("LoadProfile failed!");

                    throw new Exception();
                }

                byte[] buffer = new byte[portCount];

                do
                {
                    // Step 3: Read DI ports' status and show.
                    errorCode = instantDiCtrl.Read(startPort, portCount, buffer);
                    //errorCode = instantDiCtrl.ReadBit(startPort, bit, out data);
                    if (BioFailed(errorCode))
                    {
                        //Console.WriteLine("Read failed!");
                        throw new Exception();
                    }

                    if (Enumerable.SequenceEqual(buffer, lastBuffer))
                    {
                        Thread.Sleep(readIntervalMS);
                        continue;
                    }

                    Array.Copy(buffer, lastBuffer, buffer.Length);

                    this.OnReceiveDI(buffer);

                } while (true);
            }
            catch (Exception e)
            {
                // Something is wrong
                string errStr = BioFailed(errorCode) ? " Some error occurred. And the last error code is " + errorCode.ToString()
                                                          : e.Message;

                NlogHandler.GetSingleton().Error(errStr);
            }
            finally
            {
                // Step 4: Close device and release any allocated resource.
                //instantDiCtrl.Dispose();
            }
        }

        public void InitDeviceAI(string deviceDescription, string profilePath, int startPort, int portCount,
            int readIntervalMS)
        {
            this.deviceDescription = deviceDescription;
            this.profilePath = profilePath;
            this.startPort = startPort;
            this.portCount = portCount;
            this.readIntervalMS = readIntervalMS;

            ErrorCode errorCode = ErrorCode.Success;
            double[] lastData = new double[portCount];

            InstantAiCtrl instantAIContrl = new InstantAiCtrl();

            try
            {
                // Step 2: Select a device by device number or device description and specify the access mode.
                // in this example we use ModeWrite mode so that we can fully control the device, including configuring, sampling, etc.
                instantAIContrl.SelectedDevice = new DeviceInformation(deviceDescription);
                errorCode = instantAIContrl.LoadProfile(profilePath);//Loads a profile to initialize the device.
                if (BioFailed(errorCode))
                {
                    throw new Exception();
                }
                //Console.WriteLine(" Snap has started, any key to quit!\n");

                // Step 3: Read samples and do post-process, we show data here.
                //Console.WriteLine(" InstantAI is in progress... any key to quit !\n");
                //int channelCountMax = instantAIContrl.Features.ChannelCountMax;
                double[] scaledData = new double[portCount];//the count of elements in this array should not be less than the value of the variable channelCount

                do
                {
                    // read samples, just scaled data in this demo
                    errorCode = instantAIContrl.Read(startPort, portCount, scaledData);
                    if (BioFailed(errorCode))
                    {
                        throw new Exception();
                    }
                    // process the acquired samples
                    bool hasChange = false;
                    for (int i = 0; i < portCount; ++i)
                    {
                        if (Math.Round(lastData[i], 0) != Math.Round(scaledData[i], 0))
                        {
                            lastData[i] = scaledData[i];
                            hasChange = true;
                        }
                    }

                    if(hasChange)
                        OnReceiveAI(scaledData);

                    Thread.Sleep(this.readIntervalMS);

                } while (true);
            }
            catch (Exception e)
            {
                // Something is wrong
                string errStr = BioFailed(errorCode) ? " Some error occurred. And the last error code is " + errorCode.ToString()
                                                      : e.Message;
                NlogHandler.GetSingleton().Error(errStr);
            }
            finally
            {
                // Step 4: Close device and release any allocated resource.
                instantAIContrl.Dispose();
                //Console.ReadKey(false);
            }

        }

        static bool BioFailed(ErrorCode err)
        {
            return err < ErrorCode.Success && err >= ErrorCode.ErrorHandleNotValid;
        }
    }
}
