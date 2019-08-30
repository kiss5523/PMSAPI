using System;
using System.Collections.Generic;
using System.Text;
using Base.SDK.Base;
using Base.SDK.Response;

namespace Base.SDK.Request.DocRecord
{
    public class DocRecordUpLoadFileRequest : BaseApiRequest<SingleApiResponse>
    {
        public string DocType { get; set; }
        public string FileName { get; set; }
        public long FileSize { get; set; }
        public string DocSource { get; set; }
        public string FileExtension { get; set; }
        public byte[] Bytes { get; set; }
    }
}
