﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfImageDrawApplication1
{
    /// <summary>
    /// MainWindow.xaml の相互作用ロジック
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {

            InitializeComponent();
            // 
            //this.Dispatcher.Invoke(() => {

                var path = System.IO.Path.Combine(System.Environment.CurrentDirectory, @"image.png");

                var image = new BitmapImage();
                image.BeginInit();
                image.CacheOption = BitmapCacheOption.OnLoad;
                image.CreateOptions = BitmapCreateOptions.None;
                image.UriSource = new Uri(path, UriKind.Absolute);
                image.EndInit();
                image.Freeze();

                ImageCollection = new ObservableCollection<ImageSourceModel>();

                for (int i = 0; i < 5000; i++)
                {
                    ImageCollection.Add(new ImageSourceModel(image));
                }

                path = System.IO.Path.Combine(System.Environment.CurrentDirectory, @"image2.png");
                var image2 = new BitmapImage();
                image2.BeginInit();
                image2.CacheOption = BitmapCacheOption.OnLoad;
                image2.CreateOptions = BitmapCreateOptions.None;
                image2.UriSource = new Uri(path, UriKind.Absolute);
                image2.EndInit();
                image2.Freeze();
            ImageCollection.Add(new ImageSourceModel(image2));


            DataContext = ImageCollection;
           /// });

        }

        public ObservableCollection<ImageSourceModel> ImageCollection
        {
            set;get;
        }
    }

    //public class ImageSourceModel : INotifyPropertyChanged
    public class ImageSourceModel
    {
        public ImageSourceModel(BitmapImage path)
        {
            Bitmap = path;
        }

        private BitmapImage _bitmapImage = new BitmapImage();
        public BitmapImage Bitmap
        {
            get
            {
                /*
                var path = System.IO.Path.Combine(System.Environment.CurrentDirectory, @"image.png");

                var image = new BitmapImage();
                image.BeginInit();
                image.CacheOption = BitmapCacheOption.OnLoad;
                image.CreateOptions = BitmapCreateOptions.None;
                image.UriSource = new Uri(path, UriKind.Absolute);
                image.EndInit();
                image.Freeze();

                _bitmapImage = image;
                */
                return _bitmapImage;
            }
            set
            {
                _bitmapImage = value;
                //OnPropertyChanged("Bitmap");
            }

        }

        #region INotifyPropertyChanged メンバ  

        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string name)
        {
            PropertyChanged(this, new PropertyChangedEventArgs(name));
        }
        #endregion
    }
}
