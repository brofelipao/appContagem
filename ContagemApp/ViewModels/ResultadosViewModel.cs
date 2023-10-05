using ContagemApp.Classes;
using ContagemApp.Utils;
using Microsoft.Maui.Controls.PlatformConfiguration;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContagemApp.ViewModels
{
    public class ResultadosViewModel : clsNotificaBase
    {
        private ObservableCollection<ImagesReceiveRequest> images;
        public ObservableCollection<ImagesReceiveRequest> Images { get { return images; } set { images = value; Notifica(); } }
        public ResultadosViewModel(List<ImagesReceiveRequest> imagesP)
        {
            var obsimages = new ObservableCollection<ImagesReceiveRequest>();
            imagesP.ForEach(image =>
            {
                image.ImageByte = new MemoryStream(Convert.FromBase64String(image.Image)).ToByteArray();
                image.countString = "Qtd. de larvas: " + image.count.ToString();
                obsimages.Add(image);
            });

            Images = obsimages;
            Notifica();
        }
    }
}
