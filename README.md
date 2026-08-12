# WorkDoAuto

WorkDoAuto 是一套 Windows 桌面自動打卡工具，可依設定時間在 WorkDo 執行上下班打卡，也支援手動打卡與彈性下班時間。

## 功能

- 依工作日與設定時間自動打上班卡。
- 可選擇是否依實際上班時間延後下班打卡。
- 自動或手動打卡前會先檢查當日紀錄，避免重複打卡。
- 登入後在主畫面顯示今日上班卡、下班卡的狀態與打卡時間。
- 自動打卡成功，或偵測到今天已打過卡時，顯示 Windows 系統匣通知。
- 提供手動打上班卡及下班卡按鈕。
- 可自動補送 WorkDo 中的缺卡申請。
- 視窗最小化或關閉時可繼續在系統匣執行。

## 系統需求

- Windows
- .NET Framework 4.7.2
- Visual Studio 或 Visual Studio Build Tools（只有自行建置時需要）

## 建置

在專案根目錄執行：

```bat
build.bat
```

預設建置 `Release`。也可以指定建置組態：

```bat
build.bat Debug
build.bat Release
```

Release 執行檔位於：

```text
artifacts\Release\WorkDoWinService\WorkDoWinService.exe
```

## 使用方式

1. 啟動 `WorkDoWinService.exe`。
2. 在畫面中輸入 WorkDo Email、密碼、GPS 座標及地址。
3. 設定上下班時間，以及是否啟用彈性下班時間。
4. 按下儲存設定。
5. 登入成功後，可在「今日打卡狀態」查看上下班是否已打卡及實際時間。
6. 將視窗最小化或關閉後，程式會留在 Windows 系統匣繼續執行。
7. 若要完全結束程式，請從系統匣選單執行離開。

本程式是桌面常駐程式，不需要安裝成 Windows Service。

## 彈性下班時間

啟用後，程式會以 WorkDo 今日紀錄中的實際上班打卡時間推算下班時間；即使啟動程式前就已經打過上班卡，也會採用該筆既有紀錄。實際上班時間比設定時間晚多久，下班打卡時間就延後多久。例如設定 09:00 上班、18:00 下班，實際於 09:03 上班，當日下班打卡會延後到 18:03。提早打上班卡不會讓下班時間提前。

關閉後，下班卡會依設定時間觸發，不受實際上班時間影響。

## 設定檔

Email、密碼、GPS 座標與地址存放於目前 Windows 使用者的 LocalAppData：

```text
%LocalAppData%\WorkDoAuto\settings.config
```

上下班時間、工作日、假日日曆網址等程式設定存放在執行檔旁的 `WorkDoWinService.exe.config`。

> 密碼目前存放在使用者個人設定檔中，但尚未加密。請勿分享 `settings.config`。

## 注意事項

- 程式必須保持執行，才能在設定時間自動打卡。
- 電腦休眠、關機或無網路時，無法於該時間執行打卡。
- 第一次使用前請確認帳號、GPS 資訊與上下班時間皆已正確設定。
- 若今日已完成相同類型的打卡，程式不會重複送出，並會在 UI 與系統匣通知中顯示既有打卡時間。
- 本工具使用 WorkDo 網頁 API，若 WorkDo 調整 API，可能需要更新程式。
