using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Base.Common.Cos;
using Base.Domain.Entitys;
using Base.IBusinessService;
using Base.Repository;
using Base.SDK.Request.DocRecord;
using Base.SDK.Response;

namespace Base.BusinessService
{
    public class DocRecordBiz : IDocRecordBiz
    {
        public async Task<SingleApiResponse> UpLoadFile(DocRecordUpLoadFileRequest req)
        {
            var docId = Guid.NewGuid();
            var url = CosHelper.Instance.UploadFile("rest",
                 $"{req.DocType}/{DateTime.Now.ToString("yyyyMMdd")}/{docId.ToString().Replace("-", "")}.{req.FileExtension}", req.Bytes);

            var docRecord = new DocRecord()
            {
                DocId = docId,
                DocType = req.DocType,
                FileName = req.FileName,
                FileSize = req.FileSize,
                DocSource = req.DocSource,
                FileExtension = req.FileExtension,
                Memo = "",
                DocUrl = url,
                CreatedDate = DateTime.Now
            };
            return new SingleApiResponse()
            {
                Data = RepoBase.Instance.Add(docRecord)
        };
        }
    }
}
