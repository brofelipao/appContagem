using Acr.UserDialogs;
using ContagemApp.Classes;
using ContagemApp.Pages;
using Microsoft.Maui.Controls;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace ContagemApp.ViewModels
{
    public class EnviarFotosViewModel : clsNotificaBase
    {
        private List<FileResult> files;
        private ObservableCollection<string> filesListView;
        public List<FileResult> Files { get { return files; } set { files = value; Notifica(); } }
        public ObservableCollection<string> FilesListView { get { return filesListView; } set { filesListView = value; Notifica(); } }
        public EnviarFotosViewModel()
        {
            filesListView = new ObservableCollection<string>();
            Files = new List<FileResult>();
        }

        public Command enviaParaApiCommand
        {
            get
            {
                return new Command(() => EnviaParaAPI());
            }
        }

        public async void SelecionarFoto()
        {
            PermissionStatus status = await Permissions.CheckStatusAsync<Permissions.StorageRead>();
            if (status == PermissionStatus.Denied)
            {
                status = await Permissions.RequestAsync<Permissions.StorageRead>();
            }

            if (status == PermissionStatus.Granted)
            {
                var options = new PickOptions
                {
                    FileTypes = FilePickerFileType.Images,
                };
                var files = (await FilePicker.PickMultipleAsync()).ToList();

                if (files != null && files.Count() > 0)
                {
                    files = files.Where(c => c.ContentType.Contains("image")).ToList();
                    Files.AddRange(files);
                    files.ForEach(c => FilesListView.Add(c.FileName));
                }
            }
        }

        public async void CapturarFoto()
        {
            PermissionStatus status = await Permissions.CheckStatusAsync<Permissions.Camera>();
            if (status == PermissionStatus.Denied)
            {
                status = await Permissions.RequestAsync<Permissions.Camera>();
            }

            if (status == PermissionStatus.Granted)
            {
                var file = await MediaPicker.CapturePhotoAsync();

                if (file != null)
                {
                    Files.Add(file);
                    FilesListView.Add(file.FileName);
                }
            }
        }

        public async void EnviaParaAPI()
        {
            if (Files == null || Files.Count <= 0)
            {
                await App.Current.MainPage.DisplayAlert("Negado", "Selecione uma ou mais imagens para prosseguir.", "OK");
                return;
            }

            UserDialogs.Instance.ShowLoading("Aguarde...");
            await Task.Delay(2000);

            var result = new List<ImagesReceiveRequest>();

            UserDialogs.Instance.HideLoading();
            Files.ForEach(image =>
            {
                var s = System.IO.File.ReadAllBytes(Files[0].FullPath);
                result.Add(new ImagesReceiveRequest()
                {
                    count = 1,
                    Image = Convert.ToBase64String(s),
                    path = image.FullPath
                });
            });

            await App.Current.MainPage.Navigation.PushAsync(new Resultados(result));
        }
    }
}
