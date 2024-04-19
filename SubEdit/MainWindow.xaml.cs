using System.IO;
using System.Windows;

namespace SubEdit
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            FileInfo testFile = new("sample.srt");

            SRTSerializer.Load(testFile, out var output);

            SubTitleFile subs = new();

            for (int i = 0; i < 1000; i += 2)
            {
                var rec = new SubRecord
                {
                    StartTime = TimeSpan.FromSeconds(i),
                    EndTime = TimeSpan.FromSeconds(i + 1),
                };
                rec.Lines.Add($"Line {i} <-> {i + 1}");
                subs.Add(rec);
            }


        }
    }
}