using System.Collections.ObjectModel;

namespace ContagemApp;

public partial class EnviarFotos : ContentPage
{
    List<FileResult> Files { get; set; }
    ObservableCollection<string> filesListView { get; set; }
    public EnviarFotos()
	{
        Files = new List<FileResult>();
        filesListView = new ObservableCollection<string>();
        InitializeComponent();
	}

    private async void capturaFotoClicked(object sender, EventArgs e)
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
                filesListView.Add(file.FileName);
                listViewImages.ItemsSource = filesListView;
            }
        }
    }

    private async void selecioneFotoClicked(object sender, EventArgs e)
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
                files.ForEach(c => filesListView.Add(c.FileName));
                listViewImages.ItemsSource = filesListView;
            }
        }
    }
}