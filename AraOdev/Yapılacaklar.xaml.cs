using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using Microsoft.Maui.Controls;

namespace AraOdev
{
    public partial class Yapılacaklar : ContentPage
    {
        private ObservableCollection<Task> tasks;

        public Yapılacaklar()
        {
            InitializeComponent();
            tasks = new ObservableCollection<Task>();
            TasksListView.ItemsSource = tasks;
        }

      
        private void OnAddTaskButtonClicked(object sender, EventArgs e)
        {
            string taskName = TaskEntry.Text;

            if (!string.IsNullOrWhiteSpace(taskName))
            {
                tasks.Add(new Task { Name = taskName, IsCompleted = false });
                TaskEntry.Text = "";
            }
        }

       
        private void OnDeleteTaskButtonClicked(object sender, EventArgs e)
        {
            var button = (Button)sender;
            if (button.BindingContext is Task task) 
            {
                tasks.Remove(task);
            }
            else
            {
                DisplayAlert("Hata", "Görev silinirken bir hata oluştu.", "Tamam");
            }
        }


        private void OnUpdateTaskButtonClicked(object sender, EventArgs e)
        {
            var button = (Button)sender;
            if (button.BindingContext is Task task)
            {
                string updatedTaskName = TaskEntry.Text;
                if (!string.IsNullOrWhiteSpace(updatedTaskName))
                {
                    task.Name = updatedTaskName; 
                    TaskEntry.Text = ""; 
                }
            }
        }

       
        private void OnTaskCheckboxChanged(object sender, CheckedChangedEventArgs e)
        {
            var checkbox = (CheckBox)sender;
            if (checkbox.BindingContext is Task task)
            {
                task.IsCompleted = e.Value;
            }
        }
    }

 
    public class Task : INotifyPropertyChanged
    {
        private string name;
        private bool isCompleted;

        public string Name
        {
            get => name;
            set
            {
                if (name != value)
                {
                    name = value;
                    OnPropertyChanged(nameof(Name));
                }
            }
        }

        public bool IsCompleted
        {
            get => isCompleted;
            set
            {
                if (isCompleted != value)
                {
                    isCompleted = value;
                    OnPropertyChanged(nameof(IsCompleted));
                }
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}