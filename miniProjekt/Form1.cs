using System.Net;

namespace miniProjekt
{
    public partial class Form1 : Form
    {
        private CancellationTokenSource cancellationTokenSource;

        public Form1()
        {
            InitializeComponent();
        }
        private int DownloadAndProcessData(int taskIndex, int numberOfItems, IProgress<int> progress, CancellationToken cancellationToken)
        {
            int result = 0;

            for (int i = 0; i < numberOfItems; i++)
            {
                if (cancellationToken.IsCancellationRequested)
                {
                    cancellationToken.ThrowIfCancellationRequested();
                }

                // Simulate downloading and processing data
                string data = DownloadData($"http://example.com/task{taskIndex}/item{i}");
                int processedData = ProcessData(data);

                result += processedData;

                // Report progress
                int completedItems = (taskIndex * numberOfItems) + i + 1;
                progress.Report(completedItems);
            }

            return result;
        }
        private string DownloadData(string url)
        {
            using (var webClient = new WebClient())
            {
                try
                {
                    return webClient.DownloadString(url);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Wyst¹pi³ wyj¹tek: " + ex.Message);
                    return null;
                }
            }
        }

        private int ProcessData(string data)
        {
            // Simulate processing data
            Thread.Sleep(100);

            return data.Length;
        }

        private async void Startbutton_ClickAsync(object sender, EventArgs e)
        {
            cancellationTokenSource = new CancellationTokenSource();
            progressBar.Value = 0;
            resultTextBox.Clear();

            try
            {
                int numberOfTasks = 10;
                int numberOfItemsPerTask = 100;
                int totalNumberOfItems = numberOfTasks * numberOfItemsPerTask;

                IProgress<int> progress = new Progress<int>(value =>
                {
                    progressBar.Value = value;
                    statusLabel.Text = $"Completed {value} out of {totalNumberOfItems}";
                });

                // Create tasks
                Task<int>[] tasks = new Task<int>[numberOfTasks];
                for (int i = 0; i < numberOfTasks; i++)
                {
                    tasks[i] = Task.Factory.StartNew(() => DownloadAndProcessData(i, numberOfItemsPerTask, progress, cancellationTokenSource.Token),
                        cancellationTokenSource.Token, TaskCreationOptions.LongRunning, TaskScheduler.Default);
                }

                // Wait for all tasks to complete and sum up the results
                int totalResult = 0;
                for (int i = 0; i < numberOfTasks; i++)
                {
                    int result = await tasks[i];
                    totalResult += result;
                }

                resultTextBox.Text = $"Total result: {totalResult}";
                statusLabel.Text = "Done";
            }
            catch (OperationCanceledException)
            {
                statusLabel.Text = "Cancelled";
            }
            catch (Exception ex)
            {
                statusLabel.Text = $"Error: {ex.Message}";
            }

        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            cancellationTokenSource?.Cancel();
        }
    }
}