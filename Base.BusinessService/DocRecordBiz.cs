using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Base.Common.Cos;
using Base.Domain.Entitys;
using Base.IBusinessService;
using Base.Repository;
using Base.SDK.Model;
using Base.SDK.Request.DocRecord;
using Base.SDK.Response;

namespace Base.BusinessService
{
    public class DocRecordBiz : IDocRecordBiz
    {
        public async Task<SingleApiResponse> UpLoadFile(DocRecordUpLoadFileRequest req)
        {
            var docId = Guid.NewGuid();
            var cosKey = $"{req.DocType}/{DateTime.Now.ToString("yyyyMMdd")}/{docId.ToString()}.{req.FileExtension}";
            var url = CosHelper.Instance.UploadFile("rest", cosKey, req.Bytes);

            var docRecord = new DocRecord()
            {
                DocId = docId,
                DocType = req.DocType,
                FileName = req.FileName,
                FileSize = req.FileSize,
                DocSource = req.DocSource,
                FileExtension = req.FileExtension,
                Memo = "",
                CosBuketName = "rest",
                CosKey = cosKey,
                CreatedDate = DateTime.Now
            };
            RepoBase.Instance.Add(docRecord);
            return new SingleApiResponse()
            {
                Data = cosKey
            };
        }
    }
}
