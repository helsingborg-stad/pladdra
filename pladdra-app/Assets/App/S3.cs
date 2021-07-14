using UnityEngine;
using Amazon.S3;
using Amazon.S3.Model;
using System;
using System.IO;
using System.Threading.Tasks;

namespace Pladdra
{
    public class S3 : MonoBehaviour
    {
        public string S3BucketName = null;
        public string SampleFileName = null;

        private static IAmazonS3 _s3Client;
        private static IAmazonS3 client
        {
            get
            {
                if (_s3Client == null)
                {
                    _s3Client = new AmazonS3Client(Auth.GetCredentials(), Auth.Region);
                }
                //test comment
                return _s3Client;
            }
        }

        public static async Task SaveObjectToFile(string fileName, string keyName, string bucketName)
        {
            string path = Path.Combine(Pladdra.App.CachePath, fileName);
            System.IO.FileInfo file = new System.IO.FileInfo(path);

            GetObjectRequest request = new GetObjectRequest
            {
                BucketName = bucketName,
                Key = keyName,
            };

            GetObjectResponse response = await client.GetObjectAsync(request);
            await Task.Run(() =>
            {
                using (Stream responseStream = response.ResponseStream)
                {
                    var bytes = ReadStream(responseStream);
                    file.Directory.Create();
                    File.WriteAllBytes(Path.Combine(Pladdra.App.CachePath, fileName), bytes);
                    responseStream.Close();
                }
            });
        }

        public static byte[] ReadStream(Stream responseStream)
        {
            byte[] buffer = new byte[16 * 1024];
            using (MemoryStream ms = new MemoryStream())
            {
                int read;
                while ((read = responseStream.Read(buffer, 0, buffer.Length)) > 0)
                {
                    ms.Write(buffer, 0, read);
                }
                return ms.ToArray();
            }
        }

        public static async Task<ListObjectsResponse> ListingObjectsAsync(string bucketName)
        {
            ListObjectsResponse response = null;

            try
            {
                ListObjectsRequest request = new ListObjectsRequest()
                {
                    BucketName = bucketName,
                    MaxKeys = 5,
                };

                response = await client.ListObjectsAsync(request);

            }
            catch (AmazonS3Exception ex)
            {
                Console.WriteLine($"Error encountered on server. Message:'{ex.Message}' getting list of objects.");

                throw ex;
            }

            return response;
        }
    }
}