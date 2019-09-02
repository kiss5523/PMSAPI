using System;
using System.Collections.Generic;
using System.Text;
using Base.Common.Cos;

namespace Base.SDK.Model
{
    public class DocRecordDto:ICosBase
    {
        public Guid DocId { get; set; }
        public string DocType { get; set; }
        public string FileName { get; set; }
        public long FileSize { get; set; }
        public string DocSource { get; set; }
        public string FileExtension { get; set; }
        public string Memo { get; set; }
        
        public DateTime CreatedDate { get; set; }

        #region 文件拓展属性
        public string CosBuketName { get; set; }
        public string CosKey { get; set; }
        public string CosUrl { get; set; }
        #endregion
    }
}
