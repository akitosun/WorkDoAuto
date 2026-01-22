# WorkDoAuto
WorkDo平台自動打卡程式
# How to Use
1. [下載壓縮檔](https://github.com/akitosun/WorkDoAuto/blob/master/Publish.7z)並解壓縮
2. 使用文字編輯器開啟WorkDoWinService.exe.config，搜尋appSettings節點，設定以下資訊
- Email:WorkDo的帳號
- Pw:密碼
- gpsLocation:Google地圖上的座標，格式為POINT (x座標 y座標)
- gpsPlace:中文地址
- ClockIn:上班卡時間
- ClockOut:下班卡時間
3. 啟動exe執行檔(直接執行)，或是使用InstallService.bat(需Admin權限)將應用程式安裝成Windows Service
4. 解除安裝方法:執行UninstallService.bat(需Admin權限)
