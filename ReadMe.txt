----------------------------------------------------
 B5L Sample code for get result.  (for C#)
----------------------------------------------------

(1) Contents
  This code provides B5L(3D TOF Sensor Module) C# sample code for get result.
  With this sample code, you can execute "Start Measurement" , "Stop Measurement" and "Get Result".

(2) File description
  The following files exist in the TOFSensorSampleGetResult/ folder.

    bin/                                    Output directory for building
    Properties/                             Data storage directory of project settings
    FormMain.cs                             Sample code main
    FormMain.Designer.cs                    Form screen design definition file
    FormMain.resx                           Form screen XML resource file
    Program.cs                              The main entry point for the application.
    TOFCommand.cs                           Command class
    TOFSensorSampleGetResult.csproj         Project file.
    TOFSerialPort.cs                        Serial Port connect/disconnect/send/receive class

(3) Building method for sample code
  1. The sample code is built to be operated on Windows 10.
     It can be compiled and linked with Visual Studio 2015(C#.NET).
  2. The exe file is generated under TOFSensorSampleGetResult/bin after compilation.
     .NET Framework 4.5 or later is required in execution.


[NOTES ON USAGE]
* This sample code and documentation are copyrighted property of OMRON Corporation
* This sample code does not guarantee proper operation
* This sample code is distributed in the Apache License 2.0.

----
OMRON Corporation 
Copyright 2020 OMRON Corporation, All Rights Reserved.