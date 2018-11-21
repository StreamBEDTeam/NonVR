using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Linq;
using System.Text;

namespace StreamBED.Backend.Helper
{
    public class ImageSerialization
    {
        private List<ImageWithMetadata> ImageList;

        public void AddImage(ImageWithMetadata Image)
        {
            ImageList.Add(Image);
        }

        public void RemoveImage(ImageWithMetadata Image)
        {
            ImageList.Remove(Image);
        }

        public void SerializeImage()
        {
            Stream stream = File.Open("ImageData.dat", FileMode.Create);
            BinaryFormatter binaryFormatter = new BinaryFormatter();

            binaryFormatter.Serialize(stream, ImageList);

            stream.Close();
        }

        public void DeserializeImage()
        {
            Stream stream = File.Open("ImageData.dat", FileMode.Open);
            BinaryFormatter binaryFormatter = new BinaryFormatter();

            ImageList = (List<ImageWithMetadata>)binaryFormatter.Deserialize(stream);

            stream.Close();
        }
    }
}
