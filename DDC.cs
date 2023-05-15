using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace InputSourceDDC
{
    public class DDC
    {
        [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
        private struct DISPLAY_DEVICE
        {
            [MarshalAs(UnmanagedType.U4)]
            public int cb;

            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 32)]
            public string DeviceName;

            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 128)]
            public string DeviceString;

            [MarshalAs(UnmanagedType.U4)]
            public int StateFlags;

            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 128)]
            public string DeviceID;

            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 128)]
            public string DeviceKey;
        }

        [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
        private struct PHYSICAL_MONITOR
        {
            public IntPtr hPhysicalMonitor;

            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 128)]
            public string szPhysicalMonitorDescription;
        }
        private delegate bool MonitorEnumProc(IntPtr hMonitor, IntPtr hdc, ref IntPtr lprcClip, int dwData);

        [DllImport("User32.dll")]
        private static extern IntPtr EnumDisplayMonitors(IntPtr hdc, IntPtr lprcClip, MonitorEnumProc lpfnEnum, int dwData);

        [DllImport("User32.dll")]
        private static extern bool EnumDisplayDevices(string lpDevice, int iDevNum, ref DISPLAY_DEVICE lpDisplayDevice, int dwFlags);

        [DllImport("DXVA2.dll")]
        private static extern bool GetNumberOfPhysicalMonitorsFromHMONITOR(IntPtr hMonitor, out uint pdwNumberOfPhysicalMonitors);

        [DllImport("DXVA2.dll")]
        private static extern bool GetPhysicalMonitorsFromHMONITOR(IntPtr hMonitor, uint dwPhysicalMonitorArraySize, [Out] PHYSICAL_MONITOR[] pPhysicalMonitorArray);

        [DllImport("DXVA2.dll")]
        private static extern bool GetVCPFeatureAndVCPFeatureReply(IntPtr hPhisicalMonitor, byte bVCPCode, out IntPtr pvct, out uint pdwCurrentValue, out uint pdwMaximumValue);

        [DllImport("DXVA2.dll")]
        private static extern bool SetVCPFeature(IntPtr hMonitor, byte bVCPCode, uint dwNewValue);

        [DllImport("DXVA2.dll")]
        private static extern bool DestroyPhysicalMonitor(IntPtr hMonitor);

        private enum VCPCodeEnum : byte
        {
            InputSelect = 0x60,
            PowerMode = 0xD6
        }

        private enum InputSelectEnum : uint
        {
            VGA_1 = 0x01,
            VGA_2,
            DVI_1,
            DVI_2,
            DisplayPort_1 = 0x0F,
            DisplayPort_2,
            HDMI_1,
            HDMI_2,
        }

        private enum PowerModeEnum : uint
        {
            On = 0x01,
            Standby = 0x02,
            Suspend = 0x03,
            Off = 0x04,
            OffButton = 0x05,
        }

        public class Monitor
        {
            public IntPtr handle;
            public string name;
            public string id;

            public override string ToString()
            {
                return name;
            }
        }

        public static List<Monitor> Monitors = new List<Monitor>();

        public static void Refresh()
        {
            Monitors.Clear();
            int hMonitors = 0;
            EnumDisplayMonitors(IntPtr.Zero, IntPtr.Zero, (IntPtr hMonitor, IntPtr hdc, ref IntPtr lprcClip, int dwData) =>
            {
                var device = new DISPLAY_DEVICE();
                device.cb = Marshal.SizeOf(device);

                EnumDisplayDevices(null, hMonitors++, ref device, 0);

                var displayName = device.DeviceName;
                var displayString = device.DeviceString;

                GetNumberOfPhysicalMonitorsFromHMONITOR(hMonitor, out uint numPhysicalMonitors);
                PHYSICAL_MONITOR[] physicalMonitors = new PHYSICAL_MONITOR[numPhysicalMonitors];
                GetPhysicalMonitorsFromHMONITOR(hMonitor, numPhysicalMonitors, physicalMonitors);

                for (int i = 0; i < physicalMonitors.Length; i++)
                {
                    EnumDisplayDevices(displayName, i, ref device, 0);
                    Monitors.Add(new Monitor
                    {
                        handle = physicalMonitors[i].hPhysicalMonitor,
                        name = $"{displayString} - {device.DeviceString} ({device.DeviceName})",
                        id = device.DeviceID
                    });
                }

                return true;
            }, 0);
        }

        private static void PowerSwitch(IntPtr hPhysicalMonitor)
        {
            GetVCPFeatureAndVCPFeatureReply(hPhysicalMonitor, (byte)VCPCodeEnum.PowerMode, out IntPtr pvct, out uint dwPowerMode, out uint pdwMaximumValue);
            var PowerMode = (PowerModeEnum)dwPowerMode;

            var mode = PowerMode != PowerModeEnum.Off ? PowerModeEnum.OffButton : PowerModeEnum.On;

            SetVCPFeature(hPhysicalMonitor, (byte)VCPCodeEnum.PowerMode, (uint)mode);
            DestroyPhysicalMonitor(hPhysicalMonitor);
        }

        private static void SourceSwitch(IntPtr hPhysicalMonitor, InputSelectEnum source)
        {
            SetVCPFeature(hPhysicalMonitor, (byte)VCPCodeEnum.InputSelect, (uint)source);
            DestroyPhysicalMonitor(hPhysicalMonitor);
        }

        public static void ProcessMessage(Monitor monitor, string message)
        {
            switch (message)
            {
                case "PowerSwitch":
                    PowerSwitch(monitor.handle);
                    break;
                case "DisplayPort_1":
                    SourceSwitch(monitor.handle, InputSelectEnum.DisplayPort_1);
                    break;
                case "DisplayPort_2":
                    SourceSwitch(monitor.handle, InputSelectEnum.DisplayPort_2);
                    break;
                case "HDMI_1":
                    SourceSwitch(monitor.handle, InputSelectEnum.HDMI_1);
                    break;
                case "HDMI_2":
                    SourceSwitch(monitor.handle, InputSelectEnum.HDMI_2);
                    break;
                case "VGA_1":
                    SourceSwitch(monitor.handle, InputSelectEnum.VGA_1);
                    break;
                case "VGA_2":
                    SourceSwitch(monitor.handle, InputSelectEnum.VGA_2);
                    break;
                case "DVI_1":
                    SourceSwitch(monitor.handle, InputSelectEnum.DVI_1);
                    break;
                case "DVI_2":
                    SourceSwitch(monitor.handle, InputSelectEnum.DVI_2);
                    break;
                default:
                    break;
            }
        }
    }
}
