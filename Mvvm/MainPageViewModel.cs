using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows.Input;
using Xamarin.Forms;

namespace Mvvm
{
    public class Entry
    {
        public int Value1 { get; set; }
        public int Value2 { get; set; }
    }

    public class MainPageViewModel : INotifyPropertyChanged
    {
        private int counter = 0;
        private ObservableCollection<Entry> entries;
        public ObservableCollection<Entry> Entries
        {
            get
            {
                return entries;
            }
            set
            {
                entries = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Entries)));
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private string result;
        public string Result
        {
            get
            {
                return result;
            }
            private set
            {
                if (result != value)
                {
                    result = value;
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Result)));
                }
            }
        }

        private ICommand onIncrementCommand;
        public ICommand OnIncrementCommand
        {
            get
            {
                if (onIncrementCommand == null)
                {
                    onIncrementCommand = new Command(IncrementCommand);
                }

                return onIncrementCommand;
            }
        }

        private ICommand onCustomIncrementCommand;
        public ICommand OnCustomIncrementCommand
        {
            get
            {
                if (onCustomIncrementCommand == null)
                {
                    onCustomIncrementCommand = new Command<string>(IncrementCustomCommand);
                }

                return onCustomIncrementCommand;
            }
        }

        private ICommand onResetCommand;
        public ICommand OnResetCommand
        {
            get
            {
                if (onResetCommand == null)
                {
                    onResetCommand = new Command(ResetCommand);
                }

                return onResetCommand;
            }
        }

        private ICommand onAddCommand;
        public ICommand OnAddCommand
        {
            get
            {
                if (onAddCommand == null)
                {
                    onAddCommand = new Command(AddCommand);
                }

                return onAddCommand;
            }
        }

        private ICommand onClearCommand;
        public ICommand OnClearCommand
        {
            get
            {
                if (onClearCommand == null)
                {
                    onClearCommand = new Command(ClearCommand);
                }

                return onClearCommand;
            }
        }

        public MainPageViewModel()
        {
            Entries = new ObservableCollection<Entry>();
            Result = "0";
        }

        private void IncrementCommand()
        {
            counter++;
            UpdateResult();
        }

        private void IncrementCustomCommand(string args)
        {
            counter = counter + int.Parse(args);
            UpdateResult();
        }

        private void ResetCommand()
        {
            counter = 0;
            UpdateResult();
        }

        private void AddCommand()
        {
            var newEntry = new Entry()
            {
                Value1 = counter,
                Value2 = counter + 1
            };

            Entries.Add(newEntry);
        }

        private void ClearCommand()
        {
            Entries.Clear();
        }

        private void UpdateResult()
        {
            Result = counter.ToString();
        }
    }
}
