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
        public CosHelper()
        {
            appId = Appsettings.app(new string[] { "Cos", "appId" });
            region = Appsettings.app(new string[] { "Cos", "region" }); 
            secretId = Appsettings.app(new string[] { "Cos", "secretId" }); 
            secretKey = Appsettings.app(new string[] { "Cos", "secretKey" }); 
            // 构建一个 CoxXmlServer 对象
            cosClient = new CosBuilder()
                    .SetAccount(appId, region)
                    .SetCosXmlServer()
                    .SetSecret(secretId, secretKey)
                    .Builder();
        }

        public string UploadFile(string buketName, string key, string path)
        {
            IBucketClient bucketClient = new BucketClient(cosClient, buketName, appId);
            bucketClient.UpFile(key, path);
            return $"https://{buketName}-{appId}.cos.{region}.myqcloud.com/{key}";
        }

        public string UploadFile(string buketName, string key, byte[] bytes)
        {
            IBucketClient bucketClient = new BucketClient(cosClient, buketName, appId);
            bucketClient.UpFile(key, bytes);
            return $"https://{buketName}-{appId}.cos.{region}.myqcloud.com/{key}";
        }
    }
}
