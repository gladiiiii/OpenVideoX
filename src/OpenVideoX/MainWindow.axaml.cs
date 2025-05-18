using Avalonia.Controls;
using Avalonia.Interactivity;
using LibVLCSharp.Shared;
using System;

namespace OpenVideoX
{
    public partial class MainWindow : Window
    {
        private LibVLC _libVLC;
        private MediaPlayer _mediaPlayer;
        private string _videoPath;

        public MainWindow()
        {
            InitializeComponent();

            // LibVLC 初期化
            Core.Initialize();
            _libVLC = new LibVLC();
            _mediaPlayer = new MediaPlayer(_libVLC);
            VideoView.MediaPlayer = _mediaPlayer;

            // ボタンイベント登録
            OpenButton.Click += OpenButton_Click;
            PlayButton.Click += PlayButton_Click;
        }

        private async void OpenButton_Click(object? sender, RoutedEventArgs e)
        {
            var dlg = new OpenFileDialog
            {
                Title = "動画ファイルを選択",
                Filters = { new FileDialogFilter { Name = "Video", Extensions = { "mp4", "mkv", "avi" } } },
                AllowMultiple = false
            };
            var result = await dlg.ShowAsync(this);
            if (result != null && result.Length > 0)
            {
                _videoPath = result[0];
            }
        }

        private void PlayButton_Click(object? sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(_videoPath))
                return;

            // 既存再生中なら停止してから再生
            if (_mediaPlayer.IsPlaying)
                _mediaPlayer.Stop();

            using var media = new Media(_libVLC, new Uri(_videoPath));
            _mediaPlayer.Play(media);
        }

        protected override void OnClosed(EventArgs e)
        {
            _mediaPlayer.Dispose();
            _libVLC.Dispose();
            base.OnClosed(e);
        }
    }
}
