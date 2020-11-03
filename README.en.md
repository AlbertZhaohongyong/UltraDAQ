# UltraDAQ

#### Description
This software is the PC control program of mulit-channel high-speed data acquisition instrument,which needs to be combined with DS8000-R series digital oscillosope of RIGOL TECHNOLOGIES CO.,LTE to realize synchronous acquistion ,observation and analysis of multi-channel signals.

#### Installation and Running
1.Hardware configuration requirements   
Processor: 2GHz or above   
Memory: 2GB or above, 4GB or above   
Recommended Display: 1024*768 or higher   
Resolution Disk space: According to the amount of data saved (1M data amount per channel)  
2.The operating environment requires Windows 7 (32-bit, Chinese and English) Windows 7 (64-bit, Chinese and English) Windows 10 (32-bit, Chinese and English) Windows 10 (64-bit, Chinese and English)    
Note: I use Windows 7 (64 bit, Chinese) as an example to introduce the software installation and operation method.

#### Page layout and function
1.Main Menu

![输入图片说明](https://images.gitee.com/uploads/images/2020/1103/194406_b4f80202_6550018.png "屏幕截图.png")  

2.Instrument Communication  
- Reg:register LAN/USB connected devices  
- Delete:delete selected device  
- Apply:Apply configured instrument parameters 
3.Waveform Display 
- Collect： After the system configuration is complete, click the Collect button to start collecting waveform data, and click the Collect button again to stop the current oscilloscope from collecting waveforms and release the channel connection of the oscilloscope.  
- Update: Click the button to force trigger waveform acquisition.  
- Save： Click the button to store the currently collected waveform data locally.  

#### Software developer

AlbertZhaohongyong

#### Technology

1.  Multi-thread synchronization,Multiple thread reset event
2.  Visa communication
3.  Socket communication
