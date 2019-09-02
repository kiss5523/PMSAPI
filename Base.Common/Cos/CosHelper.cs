using System;
using System.Collections.Generic;
using System.Text;
using Base.Common.Config;
using Base.Common.Tools;
using COSXML;

namespace Base.Common.Cos
{
    public class CosHelper : Singleton<CosHelper>
    {
        private static CosXmlServer cosClient;
        private static string appId;
        private static string region;
        private static string secretId;
        private static string secretKey;
        private static int second;
        public CosHelper()
        {
            appId = Appsettings.app(new string[] { "Cos", "appId" });
            region = Appsettings.app(new string[] { "Cos", "region" }); 
            secretId = Appsettings.app(new string[] { "Cos", "secretId" });
            secretKey = Appsettings.app(new string[] { "Cos", "secretKey" });
            second =Convert.ToInt32(Appsettings.app(new string[] { "Cos", "second" }));
            // 构建一个 CoxXmlServer 对象
            cosClient = new CosBuilder()
                    .SetAccount(appId, region)
                    .SetCosXmlServer()
                    .SetSecret(secretId, secretKey)
                    .Builder();
        }

        public string UploadFile(string buketName, string key, string path)
        {
            IBucketClient bucketClient = new BucketClient(cosClient, buketName, appId, region);
            bucketClient.UpFile(key, path);
            return $"https://{buketName}-{appId}.cos.{region}.myqcloud.com/{key}";
        }

        public string UploadFile(string buketName, string key, byte[] bytes)
        {
            IBucketClient bucketClient = new BucketClient(cosClient, buketName, appId, region);
            bucketClient.UpFile(key, bytes);
            return $"https://{buketName}-{appId}.cos.{region}.myqcloud.com/{key}";
        }
        public string ObjectUrlGet(string buketName, string key)
        {
            IBucketClient bucketClient = new BucketClient(cosClient, buketName, appId, region);
            return bucketClient.SelectObject(key, second).Result;
        }

        public void ObjectUrlGetList<T>(IEnumerable<ICosBase> cosBases)where  T:ICosBase
        {
            foreach (var cosBase in cosBases)
            {
                cosBase.CosUrl = ObjectUrlGet(cosBase.CosBuketName, cosBase.CosKey);
            }
        }
    }
}
