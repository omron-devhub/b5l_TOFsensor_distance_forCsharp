/*---------------------------------------------------------------------------*/
/* Copyright(C)  2020  OMRON Corporation                                     */
/*                                                                           */
/* Licensed under the Apache License, Version 2.0 (the "License");           */
/* you may not use this file except in compliance with the License.          */
/* You may obtain a copy of the License at                                   */
/*                                                                           */
/*     http://www.apache.org/licenses/LICENSE-2.0                            */
/*                                                                           */
/* Unless required by applicable law or agreed to in writing, software       */
/* distributed under the License is distributed on an "AS IS" BASIS,         */
/* WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.  */
/* See the License for the specific language governing permissions and       */
/* limitations under the License.                                            */
/*---------------------------------------------------------------------------*/
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TOFSensorSampleGetResult
{
    /// <summary>
    /// Form main class
    /// </summary>
    public partial class FormMain : Form
    {
        /// <summary>
        /// Serial communication class
        /// </summary>
        private TOFSerialPort _serialPort = new TOFSerialPort();
        /// <summary>
        /// Command definition list
        /// </summary>
        private List<TOFCommand> _listCommand = new List<TOFCommand>();
        /// <summary>
        /// Last sent commandID
        /// </summary>
        private byte _lastSendCommandID;
        /// <summary>
        /// Normal number
        /// </summary>
        private int _normalCount = 0;
        /// <summary>
        /// Abnormal number
        /// </summary>
        private int _errorCount = 0;

        /// <summary>
        /// constructor
        /// </summary>
        public FormMain()
        {
            InitializeComponent();
            this.SetCommand();
        }

        /// <summary>
        /// Set the command definition list.
        /// </summary>
        private void SetCommand()
        {
            // Start Measurement
            this._listCommand.Add(new TOFCommand(0x80, new byte[4] { 0xFE, 0x80, 0x00, 0x00 }, 4, 6, 500));
            // Stop Measurement
            this._listCommand.Add(new TOFCommand(0x81, new byte[4] { 0xFE, 0x81, 0x00, 0x00 }, 4, 6, 500));
            // Get Result
            // If the output format is polar coordinates, the receive data length will be 153606.
            this._listCommand.Add(new TOFCommand(0x82, new byte[5] { 0xFE, 0x82, 0x00, 0x01, 0x00 }, 5,153606, 500));
        }

        /// <summary>
        /// Load event.
        /// </summary>
        /// <param name="sender">The evented object</param>
        /// <param name="e">Additional event information</param>
        private void FormMain_Load(object sender, EventArgs e)
        {
            this.ChangeEnabledButton(true);
            this.btnRefresh.PerformClick();
        }

        /// <summary>
        /// Change button Enabled.
        /// </summary>
        /// <param name="enabled">Enabled property value to set</param>
        /// <remarks>
        /// Set the Enable property of the buttons on the form.
        /// </remarks>
        private void ChangeEnabledButton(bool enabled)
        {
            this.cmbCOMList.Enabled = enabled;
            this.btnRefresh.Enabled = enabled;
            this.btnConnect.Enabled = enabled;
            this.btnDisconnect.Enabled = !enabled;
            this.btnCommand80.Enabled = !enabled;
            this.btnCommand81.Enabled = !enabled;
            this.btnCommand82.Enabled = !enabled;
        }

        /// <summary>
        /// Click the refresh button.
        /// </summary>
        /// <param name="sender">The evented object</param>
        /// <param name="e">Additional event information</param>
        /// <remarks>
        /// Refresh the list of COM ports.
        /// </remarks>
        private void btnRefresh_Click(object sender, EventArgs e)
        {
            this.cmbCOMList.Text = "";
            this.cmbCOMList.Items.Clear();
            foreach (string comPort in TOFSerialPort.GetPortNames())
            {
                if (!this.cmbCOMList.Items.Contains(comPort))
                {
                    this.cmbCOMList.Items.Add(comPort);
                }
            }
            this.cmbCOMList.SelectedIndex = this.cmbCOMList.Items.Count - 1;
        }

        /// <summary>
        /// Click the connect button.
        /// </summary>
        /// <param name="sender">The evented object</param>
        /// <param name="e">Additional event information</param>
        /// <remarks>
        /// Serial Port Connect.
        /// </remarks>
        private void btnConnect_Click(object sender, EventArgs e)
        {
            // No input check
            if (this.cmbCOMList.Text.Equals(string.Empty))
            {
                MessageBox.Show("Specify a port.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Serial communication connection
            string message = this._serialPort.Connect(this.cmbCOMList.Text);
            if (message.Equals(string.Empty))
            {
                this.ChangeEnabledButton(false);
            }
            else
            {
                MessageBox.Show(message, "Fatal error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Click the Disconnect button.
        /// </summary>
        /// <param name="sender">The evented object</param>
        /// <param name="e">Additional event information</param>
        /// <remarks>
        /// Serial Port Disconnect.
        /// </remarks>
        private void btnDisconnect_Click(object sender, EventArgs e)
        {
            // Serial communication disconnection
            this._serialPort.Disconnect();
            this.ChangeEnabledButton(true);
        }

        /// <summary>
        /// Click the Start measurement button.
        /// </summary>
        /// <param name="sender">The evented object</param>
        /// <param name="e">Additional event information</param>
        /// <remarks>
        /// Send start measurement command.
        /// </remarks>
        private void btnCommand80_Click(object sender, EventArgs e)
        {
            this.AsyncSerialPort(0x80);
        }

        /// <summary>
        /// Click the Stop measurement button.
        /// </summary>
        /// <param name="sender">The evented object</param>
        /// <param name="e">Additional event information</param>
        /// <remarks>
        /// Send stop measurement command.
        /// </remarks>
        private void btnCommand81_Click(object sender, EventArgs e)
        { 
            this.AsyncSerialPort(0x81);
        }

        /// <summary>
        /// Click the Get result button.
        /// </summary>
        /// <param name="sender">The evented object</param>
        /// <param name="e">Additional event information</param>
        /// <remarks>
        ///  Send get result command.
        /// </remarks>
        private void btnCommand82_Click(object sender, EventArgs e)
        {
            if(this.chkRepeat.Checked)
            {
                this.btnCommand82.Enabled = false;
            }
            this.AsyncSerialPort(0x82);
        }

        /// <summary>
        /// Click the Log clear button.
        /// </summary>
        /// <param name="sender">The evented object</param>
        /// <param name="e">Additional event information</param>
        /// <remarks>
        /// Clear log area and data count.
        /// </remarks>
        private void btnClear_Click(object sender, EventArgs e)
        {
            this.txtLog.Clear();
            this._normalCount = 0;
            this._errorCount = 0;
            this.txtResult.Text = string.Format("Nromal count：{0}. Error count：{1}.", this._normalCount.ToString(), this._errorCount.ToString());
        }

        /// <summary>
        /// Send and receive serial communication asynchronously.
        /// </summary>
        /// <param name="cmd">Send command</param>
        /// <remarks>
        /// [Note]
        /// If you let the UI thread process while receiving data, data is likely to be missed.
        /// Data is sent and received in order using the command response method.
        ///    1.Send command from form 
        /// -> 2.Send and receive command in thread 
        /// -> 3.Write received data on form
        /// </remarks>
        async private void AsyncSerialPort(byte cmd)
        {
            // Clear the log area every 1000 times.
            if (this._normalCount % 1000 == 0)
            {
                this.txtLog.Clear();
            }

            // Get send command from definition list.
            this._lastSendCommandID = cmd;
            TOFCommand command = this.GetCommand(cmd);
            this._serialPort.ReceivedDataLength = 0;

            // Write send command information to log area.
            this.txtLog.AppendText(string.Format("{0}  {1}  {2}  {3}\r\n"
                , DateTime.Now.ToString("HH:mm:ss.fff")
                , command.SendDataLength.ToString("D7")
                , "Send   "
                , BitConverter.ToString(command.SendData)));
            this.txtLog.ScrollToCaret();

            // Send send command to serial port asynchronously.
            await Task.Run(() => this._serialPort.SendReceive(command));

            // When called back, write the received data.
            this.CallbackSerialPort();
        }

        /// <summary>
        /// Get command definition of parameter.
        /// </summary>
        /// <param name="commandID">Command class object</param>
        /// <returns></returns>
        private TOFCommand GetCommand(byte commandID)
        {
            foreach (TOFCommand command in this._listCommand)
            {
                if (command.CommandID.Equals(commandID))
                {
                    return command;
                }
            }

            return null;
        }

        /// <summary>
        /// Callback processing after receiving data.
        /// </summary>
        /// <remarks>
        /// </remarks>
        private void CallbackSerialPort()
        {
            byte[] data = this._serialPort.ReceiveDataBuffer;
            int length = this._serialPort.ReceivedDataLength;
            bool isError = this._serialPort.IsError;

            try
            {
                if (6 <= length && data[0] == 0xFE)
                {
                    // When the synchronization code is 0xFE and the received data length is 6 or more.
                    int dataLength = (data[2] << 24) + (data[3] << 16) + (data[4] << 8) + data[5];
                    if (length == dataLength + 6)
                    {
                        // When all data can be received,
                        // Write received data information to log area.
                        this._normalCount++;
                        this.txtResult.Text = string.Format("Nromal count：{0}. Error count：{1}.", this._normalCount.ToString(), this._errorCount.ToString());
                        this.txtLog.AppendText(string.Format("{0}  {1}  {2}  {3}\r\n"
                            , DateTime.Now.ToString("HH:mm:ss.fff")
                            , length.ToString("D7")
                            , "Receive"
                            , BitConverter.ToString(data, 0, 20 <= length ? 20 : length)));
                        this.txtLog.ScrollToCaret();

                        // If Output CSV is TRUE, CSV output.
                        if (this._lastSendCommandID == 0x82 && this.chkOutputCSV.Checked)
                        {
                            // Get command definition.
                            TOFCommand command = this.GetCommand(this._lastSendCommandID);
                            // Extract get result data from the receive buffer.
                            byte[] resultData = new byte[command.ReceiveDataLength];
                            Buffer.BlockCopy(data, 0, resultData, 0, length);
                            // CSV output.
                            this.OutputCsv(resultData);
                        }

                        // If Repeat is TRUE, Send Get result command.
                        if (this.chkRepeat.Checked)
                        {
                            this.AsyncSerialPort(this._lastSendCommandID);
                            return;
                        }
                    }
                    else
                    {
                        // When some data could not be received,
                        // Write received data information to log area.
                        this._errorCount++;
                        this.txtLog.AppendText(string.Format("Failed to receive data. The received data length is {0} bytes.\r\n"
                            , length));
                        this.txtLog.ScrollToCaret();

                        // If Repeat is TRUE, Send Get result command.
                        if (this.chkRepeat.Checked)
                        {
                            this.AsyncSerialPort(this._lastSendCommandID);
                            return;
                        }
                    }
                }
                else
                {
                    // When some data could not be received,
                    // Write received data information to log area.
                    this._errorCount++;
                    if (isError)
                    {
                        // When some data could not be received,
                        // Write received data information to log area.
                        this.txtLog.AppendText(string.Format("Failed to send data.\r\n"));
                    }
                    else
                    {
                        // When some data could not be received,
                        // Write received data information to log area.
                        this.txtLog.AppendText(string.Format("Failed to receive data.\r\n"));
                    }
                    this.txtLog.ScrollToCaret();

                    // If Repeat is TRUE, Send Get result command.
                    if (this.chkRepeat.Checked)
                    {
                        this.AsyncSerialPort(this._lastSendCommandID);
                        return;
                    }
                }
            }
            catch (ObjectDisposedException)
            {
                // Do nothing until the object is destroyed.
            }
        }

        /// <summary>
        /// Repeat checkbox click event.
        /// </summary>
        /// <param name="sender">The evented object</param>
        /// <param name="e">Additional event information</param>
        private void chkRepeat_CheckedRepeat(object sender, EventArgs e)
        {
            if (this._serialPort.IsOpen)
            {
                if (this.chkRepeat.Checked)
                {
                    // No other buttons can be pressed during repeat.
                    this.btnDisconnect.Enabled = false;
                    this.btnCommand80.Enabled = false;
                    this.btnCommand81.Enabled = false;
                }
                else
                {
                    // Returns the button status if not in repeat.
                    this.ChangeEnabledButton(false);
                }
            }
        }

        /// <summary>
        /// Output CSV checkbox click event.
        /// </summary>
        /// <param name="sender">The evented object</param>
        /// <param name="e">Additional event information</param>
        /// <remarks>
        /// When Output CSV is turned ON, a folder selection dialog is displayed.
        /// </remarks>
        private void chkOutputCSV_CheckedChanged(object sender, EventArgs e)
        {
            this.txtOutputCSVPath.Clear();
            if (this.chkOutputCSV.Checked)
            {
                if (this._folderBrowserDialog.ShowDialog() == DialogResult.OK)
                {
                    this.txtOutputCSVPath.Text = this._folderBrowserDialog.SelectedPath;
                }
                else
                {
                    this.chkOutputCSV.Checked = false;
                }
            }
        }

        /// <summary>
        /// Output CSV file.
        /// </summary>
        /// <param name="data">Get result data</param>
        /// <remarks>
        /// Output get result data to CSV file.
        /// [Note]
        /// Image seen from TOF sensor:
        ///   Upper right coordinate: (0,0)
        ///   Lower left coordinates: (319, 239)
        /// Get result data:
        ///   Distance per pixel: 2 bytes
        ///   First: (319, 239)
        ///   Last: (0,0)
        ///   Output order: (319, 239)-> (0,0)
        /// CSV file name:
        ///   File name is determined in microseconds because it is about 10FPS in standard mode.
        /// Get result format:
        ///   The output format is polar coordinates.
        ///   The receive length of get result data is 153606 bytes.
        /// </remarks>
        private void OutputCsv(byte[] data)
        {
            if (!Directory.Exists(this.txtOutputCSVPath.Text))
            {
                return;
            }

            int distance = 0;
            int index = 153604;
            using (FileStream fs = new FileStream(this.txtOutputCSVPath.Text + "/result_" + DateTime.Now.ToString("yyyyMMddHHmmssfff") + ".csv", FileMode.CreateNew))
            {
                using (StreamWriter sr = new StreamWriter(fs))
                {
                    for (int i = 0; i <= 239; i++)
                    {
                        for (int j = 0; j <= 319; j++)
                        {
                            // The distance is calculated every two bytes and output.
                            distance = (short)((data[index + 1] << 8) + data[index]);
                            index = index - 2;
                            sr.Write(distance);
                            if (j != 319)
                            {
                                // Do not output the last column.
                                sr.Write(",");
                            }
                        }
                        if (i != 239)
                        {
                            // Do not output the last line.
                            sr.Write("\r\n");
                        }
                    }
                }
            }
        }

        /// <summary>
        /// Event when form is closed.
        /// </summary>
        /// <param name="sender">The evented object</param>
        /// <param name="e">Additional event information</param>
        private void FormMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            // Serial Port Disconnect.
            this._serialPort.Disconnect();
        }
    }
}
