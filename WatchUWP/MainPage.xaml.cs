using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml;
using System;
using Windows.UI.Xaml.Media;
using Windows.ApplicationModel;

// Документацию по шаблону элемента "Пустая страница" см. по адресу https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x419

namespace WatchUWP
{
    /// <summary>
    /// Пустая страница, которую можно использовать саму по себе или для перехода внутри фрейма.
    /// </summary>
    public sealed partial class MainPage : Page
    {

        DispatcherTimer watchTimer = null;
        TextBlock textBlockDateTime = new TextBlock();

        public MainPage()
        {
            this.InitializeComponent();

            // получаем ссылку на внешний вид приложения
            Windows.UI.ViewManagement.ApplicationView applicationView = Windows.UI.ViewManagement.ApplicationView.GetForCurrentView();
            // установка заголовка
            applicationView.Title = "Часы";

            WatchShow();
            SetTimerWatch();
        }

        // Метод для вывода часов на форму.
        public void WatchShow()
        {
            StackPanel stackPanelWatch = new StackPanel();
            stackPanelFirst.Children.Add(stackPanelWatch);
            TextBlock textBlockText = new TextBlock();
            stackPanelWatch.Children.Add(textBlockText);
            stackPanelWatch.Children.Add(textBlockDateTime);
            textBlockText.HorizontalAlignment = HorizontalAlignment.Center;
            textBlockText.Foreground = new SolidColorBrush(Windows.UI.Colors.Green);
            textBlockText.FontSize = 20;
            textBlockDateTime.HorizontalAlignment = HorizontalAlignment.Center;
            textBlockDateTime.Foreground = new SolidColorBrush(Windows.UI.Colors.Red);
            textBlockDateTime.FontSize = 80;
            textBlockText.Text = "Дата                                        Часы ";
        }

        // Метод для настройки таймера.
        public void SetTimerWatch()
        {
            watchTimer = new DispatcherTimer() { Interval = new System.TimeSpan(0, 0, 0, 0, 500) };        // timespan : int days,int hours,int minutes,int seconds,int milliseconds
            watchTimer.Tick += WatchTimer_Tick;
            watchTimer.Start();
        }

        // Метод для работы с датой и временем.
        private void WatchTimer_Tick(object sender, object e)
        {
            textBlockDateTime.Text = DateTime.Now.ToString();
        }
    }
}
