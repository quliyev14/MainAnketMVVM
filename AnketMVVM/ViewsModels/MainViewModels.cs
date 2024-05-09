using AnketMVVM.Commands;
using AnketMVVM.Models;
using System.Windows;
using System.Windows.Controls;
using AnketMVVM.Views;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Collections.ObjectModel;
using System.Xml;
using System.Text.Json;
using System.IO;
using System;



namespace AnketMVVM.ViewModels
{
    public class MainViewModels : INotifyPropertyChanged
    {

        public string? FileNameText { get; set; }
        private User _user { get; set; } = new();
        public User User
        {
            get => _user;
            set
            {
                _user = value;
                OnPropertyChange();
            }
        }


        private User _selectedUser;
        public User SelectedUser
        {
            get => _selectedUser;
            set
            {
                _selectedUser = value;
                OnPropertyChange();
            }
        }



        private ObservableCollection<User> _userlist { get; set; } = new();

        public ObservableCollection<User> UserList
        {
            get => _userlist;

            set
            {
                _userlist = value;
                OnPropertyChange();
            }
        }

        public RelayCommand AddCommand { get; set; }
        public RelayCommand SaveCommand { get; set; }
        public RelayCommand ChangeCommand { get; set; }
        public RelayCommand LoadCommand { get; set; }





        public MainViewModels()
        {
            AddCommand = new RelayCommand(Add);
            SaveCommand = new RelayCommand(Save);
            LoadCommand = new RelayCommand(Load);
        }

        private void Add(object? parameter) { UserList.Add(User); }

        private void Reset() => User = new User();

        private void Save(object? parameter)
        {
            try
            {
                if (SelectedUser is not null)
                {
                    if (FileNameText is not null)
                    {
                        var json = JsonSerializer.Serialize(SelectedUser, new JsonSerializerOptions() { WriteIndented = true });

                        File.WriteAllText(FileNameText, json);

                        MessageBox.Show("Json File Is Saved!");
                    }

                    else throw new ArgumentNullException(nameof(FileNameText));
                }

                else throw new InvalidOperationException(nameof(SelectedUser));
            }

            catch (InvalidOperationException) { MessageBox.Show("Please Selected"); }

            catch (ArgumentNullException) { MessageBox.Show("Enter the name json with .json at the end"); }

            catch { }
        }

        private void Load(object? parameter)
        {
            string? filepath = "saved.json";

            if (File.Exists(filepath))
            {
                var jsonFileRead = File.ReadAllText(filepath);

                var jsonRead = JsonSerializer.Deserialize<User>(jsonFileRead) ?? new User();

                User = jsonRead;
            }
        }


        public event PropertyChangedEventHandler? PropertyChanged;
        private void OnPropertyChange([CallerMemberName] string? PropertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(PropertyName));
        }
    }
}

