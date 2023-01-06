using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace VCB_TEGAKI
{
    class BOImage_Check
    {
        private int id;
        public int Id
        {
            get { return id; }
            set { id = value; }
        }
        private int ng1;
        public int NG1
        {
            get { return ng1; }
            set { ng1 = value; }
        }
        private int ng2;
        public int NG2
        {
            get { return ng2; }
            set { ng2 = value; }
        }
        private string fieldName;
        public string FieldName
        {
            get { return fieldName; }
            set { fieldName = value; }
        }

        private int pageId;
        public int PageId
        {
            get { return pageId; }
            set { pageId = value; }
        }

        private string pageName;
        public string PageName
        {
            get { return pageName; }
            set { pageName = value; }
        }

        private string pathUri;
        public string PathUri
        {
            get { return pathUri; }
            set { pathUri = value; }
        }

        private int hitPoint;
        public int HitPoint
        {
            get { return hitPoint; }
            set { hitPoint = value; }
        }

        private string status;
        public string Status
        {
            get { return status; }
            set { status = value; }
        }
        private Bitmap imagesource;
        public Bitmap Imagesource
        {
            get { return imagesource; }
            set { imagesource = value; }
        }
    }
}
