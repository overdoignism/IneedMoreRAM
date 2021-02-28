# IneedMoreRAM
It can make your windows a bit more free memory.  

\
可執行檔: 下載 [IneedMoreRAM.zip](../../raw/main/IneedMoreRAM.zip)\
雜湊值: [IneedMoreRAM_Hash.txt](../../raw/main/IneedMoreRAM_Hash.txt)

Executable file: Download the [IneedMoreRAM.zip](../../raw/main/IneedMoreRAM.zip)\
hash value: [IneedMoreRAM_Hash.txt](../../raw/main/IneedMoreRAM_Hash.txt)

\
![IMG](https://i.imgur.com/JQEjMhv.gif)

原理：

如同大多數所謂的記憶體清除程式，是調用了 Windows 的 K32EmptyWorkingSet API，呼叫系統做全局資源回收。

與其他的記憶體清除程式不同之處在於兩處：

一是我採取的等級權限是系統級，這樣的效果更好。

二是他只會在登入時的幾分鐘內執行，僅清除開機載入的相關程序造成的記憶體浪費，

避免在不對時間動作導致系統卡頓、或是浪費額外系統資源。

我再厲害也不會比 Windows 更知道該什麼時候做，所以就讓 Windows 自己處理吧。

使用方式：

將檔案複製到你要安裝的地方，點選安裝，然後重開機。

效果：

在我的實驗系統上可以節省約 0.3GB ~ 0.5GB 的記憶體（因人而異）。
＊ Windows 10 20H2、8GB

不過長時間使用的差異並未測試。

其他：

1. 本程式可以與其他記憶體清除程式並用。

2. 系統需求為 Windows 7 x64 或更高版本，安裝 .NET Framework 4.6。

聲明：

1. 本程式採用 Apache 2.0 開放原始碼授權。

2. 本程式設計者不對使用本程式之任何結果負責。

如有疑慮請自行檢視程式碼、自行編譯，或是不要使用。

其他：

感謝您的使用，如果您覺得不錯用，請推廣給您的好友，

**並歡迎來我的首頁逛一逛、看一下在下寫的小說（_就是要推廣小說啦_）。**

https://overdoingism.blogspot.com/p/blog-page.html


----------------------------------------------------


Theory:

As most "memory clean" apps, it's still call the K32EmptyWorkingSet API of Windows to do global memory recycle.

But there is 2 different:

1. I use the SYSTEM privilege, it's has better effect.

2. It's only work in several minute when user logon, for avoid bad action makes system lag, or resource waste.

How to use:

Put file to where you want install, click install button, and reboot.

Effect:

You may save 0.3GB ~ 0.5GB in your system. (Vary from one to another)

*** Test on Windows 10 20H2, 8GB

note: There has no long term difference test.

Other:

1. You can use with other memory cleaner in the same time.

2. Need Windows 7 x64 or higher with .NET Framework 4.6.

Claim:

1. It's an open source software using Apache 2.0 License.

2. Author HAS NO ANY RESPONSIBILITY AND WARRANTY for your using result.

Other:

If you like this app, you may tell your friends.

It's my site: https://overdoingism.blogspot.com/p/blog-page.html

