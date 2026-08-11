using System;
using System.Configuration;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using Utility.Helper;
using WorkDoService;
using WorkDoService.Models;

namespace WorkDoWinService
{
    internal class MainForm : Form
    {
        private readonly NotifyIcon _trayIcon;
        private readonly ContextMenuStrip _trayMenu;
        private readonly ToolStripMenuItem _openMenuItem;
        private readonly ToolStripMenuItem _exitMenuItem;
        private Label _statusLabel;
        private Label _loginStatusIconLabel;
        private Label _loginStatusLabel;
        private TextBox _emailTextBox;
        private TextBox _passwordTextBox;
        private TextBox _gpsXTextBox;
        private TextBox _gpsYTextBox;
        private TextBox _gpsPlaceTextBox;
        private TextBox _clockInTextBox;
        private TextBox _clockOutTextBox;
        private CheckBox _enableFlexibleClockOutCheckBox;
        private Button _manualClockInButton;
        private Button _manualClockOutButton;
        private Button _saveButton;
        private Button _loginButton;
        private bool _allowClose;
        private MainService _service;

        public MainForm()
        {
            AutoScaleMode = AutoScaleMode.Font;
            StartPosition = FormStartPosition.CenterScreen;
            Text = "WorkDo 自動打卡";
            MinimumSize = new Size(500, 460);

            Icon appIcon = LoadApplicationIcon();
            Icon = appIcon;

            _trayMenu = new ContextMenuStrip();
            _openMenuItem = new ToolStripMenuItem("開啟", null, (_, __) => ShowMainWindow());
            _exitMenuItem = new ToolStripMenuItem("結束", null, (_, __) => ExitApplication());
            _trayMenu.Items.Add(_openMenuItem);
            _trayMenu.Items.Add(new ToolStripSeparator());
            _trayMenu.Items.Add(_exitMenuItem);

            _trayIcon = new NotifyIcon
            {
                Icon = appIcon,
                Visible = true,
                Text = "WorkDo 自動打卡"
            };
            _trayIcon.DoubleClick += (_, __) => ShowMainWindow();
            _trayIcon.ContextMenuStrip = _trayMenu;

            BuildLayout();
            LoadSettings();
            PunchNotification.PunchCompleted += OnAutomaticPunchCompleted;
            StartService();
            Shown += async (_, __) => await LoginAsync(false);

            Resize += OnResize;
            FormClosing += OnFormClosing;
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                PunchNotification.PunchCompleted -= OnAutomaticPunchCompleted;
                StopService();
                if (_trayIcon != null)
                {
                    _trayIcon.Visible = false;
                    _trayIcon.Dispose();
                }
                _trayMenu?.Dispose();
            }

            base.Dispose(disposing);
        }

        private void BuildLayout()
        {
            var layout = new TableLayoutPanel
            {
                Dock = DockStyle.Fill,
                ColumnCount = 2,
                RowCount = 12,
                Padding = new Padding(16),
                AutoSize = true,
                AutoSizeMode = AutoSizeMode.GrowAndShrink
            };

            layout.ColumnStyles.Add(new ColumnStyle(SizeType.AutoSize));
            layout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100f));

            _gpsXTextBox = CreateTextBox();
            _gpsYTextBox = CreateTextBox();
            _gpsPlaceTextBox = CreateTextBox();
            _clockInTextBox = CreateTextBox();
            _clockOutTextBox = CreateTextBox();
            _emailTextBox = CreateTextBox();
            _passwordTextBox = CreateTextBox();
            _passwordTextBox.UseSystemPasswordChar = true;

            var gpsCoordinatePanel = new TableLayoutPanel
            {
                AutoSize = true,
                Dock = DockStyle.Fill,
                ColumnCount = 4,
                RowCount = 1,
                Margin = Padding.Empty
            };
            gpsCoordinatePanel.ColumnStyles.Add(new ColumnStyle(SizeType.AutoSize));
            gpsCoordinatePanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50f));
            gpsCoordinatePanel.ColumnStyles.Add(new ColumnStyle(SizeType.AutoSize));
            gpsCoordinatePanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50f));
            gpsCoordinatePanel.Controls.Add(CreateLabel("X"), 0, 0);
            gpsCoordinatePanel.Controls.Add(_gpsXTextBox, 1, 0);
            gpsCoordinatePanel.Controls.Add(CreateLabel("Y"), 2, 0);
            gpsCoordinatePanel.Controls.Add(_gpsYTextBox, 3, 0);

            layout.Controls.Add(CreateLabel("GPS 座標"), 0, 0);
            layout.Controls.Add(gpsCoordinatePanel, 1, 0);

            layout.Controls.Add(CreateLabel("地址"), 0, 1);
            layout.Controls.Add(_gpsPlaceTextBox, 1, 1);

            layout.Controls.Add(CreateLabel("上班時間"), 0, 2);
            layout.Controls.Add(_clockInTextBox, 1, 2);

            layout.Controls.Add(CreateLabel("下班時間"), 0, 3);
            layout.Controls.Add(_clockOutTextBox, 1, 3);

            _enableFlexibleClockOutCheckBox = new CheckBox
            {
                Text = "啟用彈性下班時間",
                AutoSize = true,
                Anchor = AnchorStyles.Left
            };
            layout.Controls.Add(_enableFlexibleClockOutCheckBox, 1, 4);

            var manualPunchPanel = new FlowLayoutPanel
            {
                AutoSize = true,
                Dock = DockStyle.Fill,
                FlowDirection = FlowDirection.LeftToRight,
                WrapContents = false
            };

            _manualClockInButton = new Button { Text = "手動打上班卡", AutoSize = true };
            _manualClockOutButton = new Button { Text = "手動打下班卡", AutoSize = true };
            _manualClockInButton.Click += async (_, __) => await ManualPunchAsync(Enum_clocktype.ClockIn);
            _manualClockOutButton.Click += async (_, __) => await ManualPunchAsync(Enum_clocktype.ClockOut);
            manualPunchPanel.Controls.Add(_manualClockInButton);
            manualPunchPanel.Controls.Add(_manualClockOutButton);
            layout.Controls.Add(CreateLabel("手動打卡"), 0, 5);
            layout.Controls.Add(manualPunchPanel, 1, 5);

            layout.Controls.Add(CreateLabel("Email"), 0, 8);
            layout.Controls.Add(_emailTextBox, 1, 8);
            layout.Controls.Add(CreateLabel("密碼"), 0, 9);
            layout.Controls.Add(_passwordTextBox, 1, 9);

            var loginStatusPanel = new FlowLayoutPanel
            {
                AutoSize = true,
                Dock = DockStyle.Fill,
                FlowDirection = FlowDirection.LeftToRight,
                WrapContents = false
            };
            _loginStatusIconLabel = new Label { Text = "●", AutoSize = true, ForeColor = Color.DimGray };
            _loginStatusLabel = new Label { Text = "尚未登入", AutoSize = true, ForeColor = Color.DimGray };
            loginStatusPanel.Controls.Add(_loginStatusIconLabel);
            loginStatusPanel.Controls.Add(_loginStatusLabel);
            layout.Controls.Add(CreateLabel("登入狀態"), 0, 10);
            layout.Controls.Add(loginStatusPanel, 1, 10);

            _loginButton = new Button
            {
                Text = "登入",
                AutoSize = true,
                Anchor = AnchorStyles.Right,
                Padding = new Padding(10, 4, 10, 4)
            };
            _loginButton.Click += async (_, __) => await LoginAsync(true);
            layout.Controls.Add(_loginButton, 1, 11);

            _saveButton = new Button
            {
                Text = "儲存設定",
                AutoSize = true,
                Anchor = AnchorStyles.Right,
                Padding = new Padding(10, 4, 10, 4)
            };
            _saveButton.Click += (_, __) => SaveSettings();

            layout.Controls.Add(_saveButton, 1, 6);

            _statusLabel = new Label
            {
                AutoSize = true,
                ForeColor = Color.DimGray,
                Margin = new Padding(3, 12, 3, 0)
            };
            layout.Controls.Add(_statusLabel, 0, 7);
            layout.SetColumnSpan(_statusLabel, 2);

            Controls.Add(layout);
        }

        private static Label CreateLabel(string text)
        {
            return new Label
            {
                Text = text,
                AutoSize = true,
                Anchor = AnchorStyles.Left,
                Margin = new Padding(3, 6, 3, 6)
            };
        }

        private static TextBox CreateTextBox()
        {
            return new TextBox
            {
                Anchor = AnchorStyles.Left | AnchorStyles.Right,
                Width = 320
            };
        }

        private Icon LoadApplicationIcon()
        {
            var baseDirectory = AppDomain.CurrentDomain.BaseDirectory;
            var iconPath = Path.Combine(baseDirectory, "WorkdoAuto.ico");
            if (File.Exists(iconPath))
            {
                return new Icon(iconPath);
            }

            using (var stream = typeof(MainForm).Assembly.GetManifestResourceStream("WorkDoWinService.WorkdoAuto.ico"))
            {
                if (stream != null)
                {
                    return new Icon(stream);
                }
            }

            return SystemIcons.Application;
        }

        private void LoadSettings()
        {
            try
            {
                var helper = ConfigHelper.GetInstance();
                _emailTextBox.Text = helper.GetAppSettingValue("Email");
                _passwordTextBox.Text = helper.GetAppSettingValue("Pw");
                LoadGpsCoordinates(helper.GetAppSettingValue("gpsLocation"));
                _gpsPlaceTextBox.Text = helper.GetAppSettingValue("gpsPlace");
                _clockInTextBox.Text = helper.GetAppSettingValue("ClockIn");
                _clockOutTextBox.Text = helper.GetAppSettingValue("ClockOut");
                _enableFlexibleClockOutCheckBox.Checked = GetBooleanSetting(helper, "EnableFlexibleClockOut", true);
                UpdateStatus("設定已載入。");
            }
            catch (ConfigurationErrorsException ex)
            {
                UpdateStatus("讀取設定失敗：" + ex.Message, true);
            }
            catch (Exception ex)
            {
                UpdateStatus("讀取設定發生錯誤：" + ex.Message, true);
            }
        }

        private void SaveSettings()
        {
            try
            {
                var helper = ConfigHelper.GetInstance();
                helper.SetAppSettingValue("Email", _emailTextBox.Text.Trim());
                helper.SetAppSettingValue("Pw", _passwordTextBox.Text);
                string gpsLocation = BuildGpsLocation();
                helper.SetAppSettingValue("gpsLocation", gpsLocation);
                helper.SetAppSettingValue("gpsPlace", _gpsPlaceTextBox.Text.Trim());
                helper.SetAppSettingValue("ClockIn", _clockInTextBox.Text.Trim());
                helper.SetAppSettingValue("ClockOut", _clockOutTextBox.Text.Trim());
                helper.SetAppSettingValue("EnableFlexibleClockOut", _enableFlexibleClockOutCheckBox.Checked.ToString().ToLowerInvariant());

                RestartService();
                UpdateStatus("設定已儲存並重新啟動排程服務。");
                _trayIcon.ShowBalloonTip(2000, Text, "設定已儲存。", ToolTipIcon.Info);
            }
            catch (ConfigurationErrorsException ex)
            {
                UpdateStatus("儲存設定失敗：" + ex.Message, true);
                MessageBox.Show(ex.Message, Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                UpdateStatus("儲存設定發生錯誤：" + ex.Message, true);
                MessageBox.Show(ex.Message, Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadGpsCoordinates(string gpsLocation)
        {
            if (string.IsNullOrWhiteSpace(gpsLocation))
            {
                return;
            }

            Match pointMatch = Regex.Match(
                gpsLocation,
                @"^\s*POINT\s*\(\s*(?<x>[^\s,()]+)\s+(?<y>[^\s,()]+)\s*\)\s*$",
                RegexOptions.IgnoreCase);
            if (!pointMatch.Success)
            {
                pointMatch = Regex.Match(
                    gpsLocation,
                    @"^\s*(?<x>[^,]+?)\s*,\s*(?<y>[^,]+?)\s*$");
            }

            if (pointMatch.Success)
            {
                _gpsXTextBox.Text = pointMatch.Groups["x"].Value.Trim();
                _gpsYTextBox.Text = pointMatch.Groups["y"].Value.Trim();
            }
        }

        private string BuildGpsLocation()
        {
            string x = _gpsXTextBox.Text.Trim();
            string y = _gpsYTextBox.Text.Trim();
            double coordinate;
            if (string.IsNullOrWhiteSpace(x)
                || string.IsNullOrWhiteSpace(y)
                || !double.TryParse(x, NumberStyles.Float, CultureInfo.InvariantCulture, out coordinate)
                || !double.TryParse(y, NumberStyles.Float, CultureInfo.InvariantCulture, out coordinate))
            {
                throw new ConfigurationErrorsException("GPS X、Y 座標必須填寫有效數字，小數請使用小數點。");
            }

            return $"POINT ({x} {y})";
        }

        private async System.Threading.Tasks.Task LoginAsync(bool saveCredentials)
        {
            if (string.IsNullOrWhiteSpace(_emailTextBox.Text) || string.IsNullOrEmpty(_passwordTextBox.Text))
            {
                SetLoginStatus("請輸入 Email 與密碼。", false);
                return;
            }

            _loginButton.Enabled = false;
            _emailTextBox.Enabled = false;
            _passwordTextBox.Enabled = false;
            SetLoginStatus("登入中…", null);

            try
            {
                if (saveCredentials)
                {
                    var helper = ConfigHelper.GetInstance();
                    helper.SetAppSettingValue("Email", _emailTextBox.Text.Trim());
                    helper.SetAppSettingValue("Pw", _passwordTextBox.Text);
                    RestartService();
                }

                var simulation = new Simulation();
                await System.Threading.Tasks.Task.Run(() => simulation.LoginSimulation());
                SetLoginStatus("登入成功", true);
            }
            catch (Exception ex)
            {
                string message = "登入失敗：" + ex.Message;
                SetLoginStatus(message, false);
                MessageBox.Show(message, Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                _loginButton.Enabled = true;
                _emailTextBox.Enabled = true;
                _passwordTextBox.Enabled = true;
            }
        }

        private void SetLoginStatus(string message, bool? succeeded)
        {
            Color color = succeeded == true ? Color.ForestGreen : succeeded == false ? Color.Firebrick : Color.DarkOrange;
            _loginStatusIconLabel.ForeColor = color;
            _loginStatusLabel.ForeColor = color;
            _loginStatusLabel.Text = message;
        }

        private void StartService()
        {
            try
            {
                _service = new MainService();
                _service.Start();
                UpdateStatus("排程服務執行中。");
            }
            catch (Exception ex)
            {
                _service = null;
                UpdateStatus("排程服務啟動失敗：" + ex.Message, true);
                MessageBox.Show(ex.Message, Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void RestartService()
        {
            StopService();
            StartService();
        }

        private async System.Threading.Tasks.Task ManualPunchAsync(Enum_clocktype clockType)
        {
            _manualClockInButton.Enabled = false;
            _manualClockOutButton.Enabled = false;

            try
            {
                var simulation = new Simulation();
                await System.Threading.Tasks.Task.Run(() => simulation.LoginSimulation());
                var result = await simulation.PunchWithValidationAsync(clockType);
                string typeText = clockType == Enum_clocktype.ClockIn ? "上班卡" : "下班卡";
                string message = result.WasPunched
                    ? $"{typeText}打卡成功：{FormatPunchTime(result.PunchTime)}"
                    : $"今天已經打過{typeText}：{FormatPunchTime(result.PunchTime)}";

                UpdateStatus(message);
                _trayIcon.ShowBalloonTip(3000, Text, message,
                    result.WasPunched ? ToolTipIcon.Info : ToolTipIcon.Warning);
            }
            catch (Exception ex)
            {
                UpdateStatus("手動打卡失敗：" + ex.Message, true);
                MessageBox.Show(ex.Message, Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                _manualClockInButton.Enabled = true;
                _manualClockOutButton.Enabled = true;
            }
        }

        private void OnAutomaticPunchCompleted(object sender, WorkDoService.Models.PunchCompletedEventArgs e)
        {
            Action showToast = () =>
            {
                string typeText = e.Result.ClockType == Enum_clocktype.ClockIn ? "上班卡" : "下班卡";
                string message = $"自動{typeText}成功：{FormatPunchTime(e.Result.PunchTime)}";
                UpdateStatus(message);
                _trayIcon.ShowBalloonTip(3000, Text, message, ToolTipIcon.Info);
            };

            if (InvokeRequired)
            {
                BeginInvoke(showToast);
            }
            else
            {
                showToast();
            }
        }

        private static string FormatPunchTime(string punchTime)
        {
            DateTime parsedTime;
            return DateTime.TryParse((punchTime ?? string.Empty).Replace("+0800", string.Empty), out parsedTime)
                ? parsedTime.ToString("yyyy/MM/dd HH:mm:ss")
                : punchTime;
        }

        private static bool GetBooleanSetting(ConfigHelper helper, string key, bool defaultValue)
        {
            try
            {
                bool parsedValue;
                return bool.TryParse(helper.GetAppSettingValue(key), out parsedValue)
                    ? parsedValue
                    : defaultValue;
            }
            catch (ApplicationException)
            {
                return defaultValue;
            }
        }

        private void StopService()
        {
            if (_service != null)
            {
                try
                {
                    _service.Stop();
                }
                catch
                {
                    // ignore exceptions during shutdown
                }
                finally
                {
                    _service = null;
                }
            }
        }

        private void ShowMainWindow()
        {
            if (Visible)
            {
                if (WindowState == FormWindowState.Minimized)
                {
                    WindowState = FormWindowState.Normal;
                }
            }
            else
            {
                Show();
                WindowState = FormWindowState.Normal;
            }

            Activate();
        }

        private void ExitApplication()
        {
            _allowClose = true;
            _trayIcon.Visible = false;
            Close();
        }

        private void OnResize(object sender, EventArgs e)
        {
            if (WindowState == FormWindowState.Minimized)
            {
                Hide();
                _trayIcon.ShowBalloonTip(1500, Text, "程式仍在系統列執行。", ToolTipIcon.Info);
            }
        }

        private void OnFormClosing(object sender, FormClosingEventArgs e)
        {
            if (!_allowClose && e.CloseReason == CloseReason.UserClosing)
            {
                e.Cancel = true;
                Hide();
            }
            else if (_allowClose)
            {
                StopService();
            }
        }

        private void UpdateStatus(string message, bool isError = false)
        {
            if (_statusLabel.InvokeRequired)
            {
                _statusLabel.Invoke(new Action(() => UpdateStatus(message, isError)));
                return;
            }

            _statusLabel.Text = message;
            _statusLabel.ForeColor = isError ? Color.Firebrick : Color.DimGray;
        }
    }
}
