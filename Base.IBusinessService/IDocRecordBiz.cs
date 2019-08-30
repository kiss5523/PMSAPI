using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Base.SDK.Request.DocRecord;
using Base.SDK.Response;

namespace Base.IBusinessService
{
    public interface IDocRecordBiz
    {
        Task<SingleApiResponse> UpLoadFile(DocRecordUpLoadFileRequest req);
    }
}
