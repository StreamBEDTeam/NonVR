using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Linq;
using System.Text;

namespace StreamBED.Backend.Helper
{
    /// <summary>
    /// Defines methods to serialize and deserialize a list of <see cref="ImageWithMetadata"/>.
    /// </summary>
    [Serializable]
    public class ImageSerialization
    {
        // Stores all the images that are going to be serialized or deserialized.
        private List<ImageWithMetadata> imageList;

        /// <summary>
        /// Returns the <see cref="ImageSerialization.imageList"/> as a 
        /// <see cref="System.Collections.ObjectModel.ReadOnlyCollection{ImageWithMetadata}"/>
        /// </summary>
        public IList<ImageWithMetadata> ImageList { get { return imageList.AsReadOnly(); } }

        // Constructor
        public ImageSerialization()
        {
            imageList = new List<ImageWithMetadata>();
        }

        /// <summary>
        /// Adds an <see cref="ImageWithMetadata"/> into 
        /// ImageList to be serialized or deserialized.
        /// </summary>
        /// <param name="Image"><see cref="ImageWithMetadata"/> to be added.</param>
        public void AddImage(ImageWithMetadata Image)
        {
            imageList.Add(Image);
        }

        /// <summary>
        /// Removes an <see cref="ImageWithMetadata"/> from <paramref name="ImageList"/>.
        /// </summary>
        /// <param name="Image"><see cref="ImageWithMetadata"/> to be removed.</param>
        public void RemoveImage(ImageWithMetadata Image)
        {
            imageList.Remove(Image);
        }

        public void ClearImages()
        {
            imageList.Clear();
        }

        /// <summary>
        /// Serializes ImageList and is saved to ImageData.dat.
        /// </summary>
        public void SerializeImage()
        {
            Stream stream = File.Open("ImageData.dat", FileMode.Create);
            BinaryFormatter binaryFormatter = new BinaryFormatter();

            binaryFormatter.Serialize(stream, imageList);

            stream.Close();
        }

        /// <summary>
        /// Deserializes ImageList from ImageData.dat.
        /// </summary>
        public void DeserializeImage()
        {
            Stream stream = File.Open(@"ImageData.dat", FileMode.Open, FileAccess.Read, FileShare.Read);
            DeserializeImage(stream);
        }

        public void DeserializeImage(Stream stream)
        {
            BinaryFormatter binaryFormatter = new BinaryFormatter();

            var images = binaryFormatter.Deserialize(stream);

            if (images is List<ImageWithMetadata>)
            {
                imageList = (List<ImageWithMetadata>)images;
            }
            else if (images is IList<ImageWithMetadata>)
            {
                foreach (ImageWithMetadata i in (IList<ImageWithMetadata>)images)
                {
                    imageList.Add(i);
                }
            }

            stream.Close();
        }
    }
}
