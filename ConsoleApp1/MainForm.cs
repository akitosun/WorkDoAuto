using System;
using System.Configuration;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using Utility.Helper;
using WorkDoService;

namespace WorkDoWinService
{
    internal class MainForm : Form
    {
        private readonly NotifyIcon _trayIcon;
        private readonly ContextMenuStrip _trayMenu;
        private readonly ToolStripMenuItem _openMenuItem;
        private readonly ToolStripMenuItem _exitMenuItem;
        private Label _statusLabel;
        private TextBox _gpsLocationTextBox;
        private TextBox _gpsPlaceTextBox;
        private TextBox _clockInTextBox;
        private TextBox _clockOutTextBox;
        private Button _saveButton;
        private bool _allowClose;
        private MainService _service;

        public MainForm()
        {
            AutoScaleMode = AutoScaleMode.Font;
            StartPosition = FormStartPosition.CenterScreen;
            Text = "WorkDo 自動打卡";
            MinimumSize = new Size(500, 320);

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
            StartService();

            Resize += OnResize;
            FormClosing += OnFormClosing;
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
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
                RowCount = 6,
                Padding = new Padding(16),
                AutoSize = true,
                AutoSizeMode = AutoSizeMode.GrowAndShrink
            };

            layout.ColumnStyles.Add(new ColumnStyle(SizeType.AutoSize));
            layout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100f));

            _gpsLocationTextBox = CreateTextBox();
            _gpsPlaceTextBox = CreateTextBox();
            _clockInTextBox = CreateTextBox();
            _clockOutTextBox = CreateTextBox();

            layout.Controls.Add(CreateLabel("GPS 座標"), 0, 0);
            layout.Controls.Add(_gpsLocationTextBox, 1, 0);

            layout.Controls.Add(CreateLabel("地址"), 0, 1);
            layout.Controls.Add(_gpsPlaceTextBox, 1, 1);

            layout.Controls.Add(CreateLabel("上班時間"), 0, 2);
            layout.Controls.Add(_clockInTextBox, 1, 2);

            layout.Controls.Add(CreateLabel("下班時間"), 0, 3);
            layout.Controls.Add(_clockOutTextBox, 1, 3);

            _saveButton = new Button
            {
                Text = "儲存設定",
                AutoSize = true,
                Anchor = AnchorStyles.Right,
                Padding = new Padding(10, 4, 10, 4)
            };
            _saveButton.Click += (_, __) => SaveSettings();

            layout.Controls.Add(_saveButton, 1, 4);

            _statusLabel = new Label
            {
                AutoSize = true,
                ForeColor = Color.DimGray,
                Margin = new Padding(3, 12, 3, 0)
            };
            layout.Controls.Add(_statusLabel, 0, 5);
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
                _gpsLocationTextBox.Text = helper.GetAppSettingValue("gpsLocation");
                _gpsPlaceTextBox.Text = helper.GetAppSettingValue("gpsPlace");
                _clockInTextBox.Text = helper.GetAppSettingValue("ClockIn");
                _clockOutTextBox.Text = helper.GetAppSettingValue("ClockOut");
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
                helper.SetAppSettingValue("gpsLocation", _gpsLocationTextBox.Text.Trim());
                helper.SetAppSettingValue("gpsPlace", _gpsPlaceTextBox.Text.Trim());
                helper.SetAppSettingValue("ClockIn", _clockInTextBox.Text.Trim());
                helper.SetAppSettingValue("ClockOut", _clockOutTextBox.Text.Trim());

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
