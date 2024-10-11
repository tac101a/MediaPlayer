using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;
using Newtonsoft.Json;

namespace Media_Player_App
{
    public class Media : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler? PropertyChanged;
        public string? Name { get; set; }
        public string? Singer { get; set; }
        public string? ImagePath { get; set; }
        public Uri? FullPath { get; set; }
        public string FileExtension { get; set; } = string.Empty;
        public string? RunTime { get; set; }
        public string? EndTime { get; set; }
        [JsonIgnore] public BitmapImage? Image { get; set; }
        public Media() { }
        public Media(string filePath)
        {
            var fileInfo = new FileInfo(filePath);
            if (!File.Exists(filePath))
            {
                throw new Exception($"The file {filePath} doesn't exist.");
            }
            var mediaFile = TagLib.File.Create(filePath);

            this.Name = mediaFile.Tag.Title ?? fileInfo.Name;       //  Get Filename
            this.FullPath = new Uri(filePath);
            this.FileExtension = fileInfo.Extension;

            #region Lấy thông tin ca sĩ

            string[] artistList;
            if (mediaFile.Tag.AlbumArtists.Length > 0)
            {
                // If Album Artists are available
                artistList = mediaFile.Tag.AlbumArtists;
            }
            else
            {
                // Otherwise, use Performers (track artists)
                artistList = mediaFile.Tag.Performers;
            }

            if (artistList == null || artistList.Length == 0)
            {
                this.Singer = "Unknown";
            }
            else
            {
                this.Singer = String.Join(";", artistList);
            }

            #endregion
            // Get image from media file
            var firstPicture = mediaFile.Tag.Pictures.FirstOrDefault();
            if (firstPicture != null)
            {
                byte[] imageData = firstPicture.Data.Data;
                var image = new BitmapImage();
                using (var mem = new MemoryStream(imageData))
                {
                    mem.Position = 0;
                    image.BeginInit();
                    image.CreateOptions = BitmapCreateOptions.PreservePixelFormat;
                    image.CacheOption = BitmapCacheOption.OnLoad;
                    image.UriSource = null;
                    image.StreamSource = mem;
                    image.EndInit();
                }
                image.Freeze();
                this.Image = image;
            }
            else
            {
                if (!string.IsNullOrWhiteSpace(this.ImagePath))
                {
                    this.Image = new BitmapImage(new Uri(this.ImagePath, UriKind.RelativeOrAbsolute));
                }
                else
                {
                    // The default image path should be a resource in your project for this to work
                    this.Image = new BitmapImage(new Uri("pack://application:,,,/Images/musical-note.png"));
                }
            }
        }
    }
}
