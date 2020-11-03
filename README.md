# UltraDAQ

#### 介绍
此软件为多通道高速数据采集仪器的上位机程控程序，需要结合普源精电科技股份有限公司的DS8000-R系列数字示波器使用，以实现对多通道信号的同步采集、观测和分析。

#### 安装与运行
1. 硬件配置要求
处理器：2GHz 以上
内存：2GB 及以上，推荐 4GB 以上
显示器：1024*768 或更高分辨率
磁盘空间：根据保存的数据量而定（每通道 1M 数据量）
2. 运行环境要求
Windows 7（32 位，中英文）
Windows 7（64 位，中英文）
Windows 10（32 位，中英文）
Windows 10（64 位，中英文）
注：本文以 Windows 7（64 位，中文）为例介绍软件安装和运行方法。

#### 页面布局及功能
1.  主菜单

![输入图片说明](https://images.gitee.com/uploads/images/2020/1103/171037_5568d631_6550018.png "屏幕截图.png")
- **Inst Config:** 配置界面
- **Wav Disp:** 波形显示界面
2.  仪器通讯栏
- **Reg** ![输入图片说明](https://images.gitee.com/uploads/images/2020/1103/171212_204c0a75_6550018.png "屏幕截图.png"):可注册局域网/USB连接的设备
- **Delete** ![输入图片说明](https://images.gitee.com/uploads/images/2020/1103/171309_c273abd9_6550018.png "屏幕截图.png"):删除选中设备
- **Apply** ![输入图片说明](https://images.gitee.com/uploads/images/2020/1103/171525_a4624ec1_6550018.png "屏幕截图.png"):配置好的仪器参数批量下发
3.  波形捕捉栏

![输入图片说明](https://images.gitee.com/uploads/images/2020/1103/171619_29a3cf51_6550018.png "屏幕截图.png")
- **Collect：** 在系统配置完成后，点击Collect按钮可启动采集波形数据，再次点击 Collect 按钮,可停止当前示波器采集波形,释放示波器的通道连接。
- **Update:** 点击按钮强制触发波形采集。
- **Save：** 点击按钮，可将当前采集的波形数据存储到本地。

#### 名词解释
TrigSoure：触发源，可在下拉菜单中选择模拟通道 CHAN1-CHAN4 或 EXT（外触发）作为触发信源，默认配置为外触发。  
TrigMode：触发模式，可在下拉菜单中选择SINGLE（单次触发）、NORMAL（普通触发）、AUTO（自动触发），默认触发方式为单次触发（SINGLE）。  
TrigLevel：触发电平，当触发源为 CHAN1-CHAN4 时，触发电平的取值范围与通道当前的档位有关；当触发源为EXT 时，触发电平的取值范围为-5V 至+5V；默认为 500mV。  
MemDepth：存储深度，可在下拉菜单中选择1K、10K、100K、1M, 默认为 10K。  
Holdoff：触发释抑，用于稳定触发复杂的重复波形，可调范围为 8 ns 至 10 s，默认为 8ns。  
HorzScale：水平时基，可调范围为 200 ps/div 至 1 ks/div，默认为 1us。  
HorzPos：水平偏移，取值范围与时基有关，默认为 0。  
Collect：勾选表示该通道使能。  
Device：该通道所属的注册设备的名称。  
Channel：注册设备的通道号。  
ChannelTag：通道号标签，用于标识通道。  
Mark：通道标识备注，可用于对ChannelTag进行备注。  
Scale：用于配置该通道的垂直档位，单位 V。  
Offset：用于配置该通道的垂直偏移，单位 V。  
Impedance：可在下拉菜单中选择 50Ω 或 1 MΩ 作为该通道的输入阻抗，默认配置为 1 MΩ。  
Coupling：可在下拉菜单中选择耦合方式为直流（DC）、交流（AC）和接地（GND），默认配置为直流。  
Attenuation：可在下拉菜单中选择探头衰减比为*1 或*10，默认配置为*1。  


#### 软件开发者
1.  AlbertZhaohongyong

#### 技术
1.  多线程同步、MultipleThreadResetEvent
2.  Visa通信、Socket通信
