using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZarządzanieBudżetem.ImportExel
{
    public interface IExcelImporter
    {
        void ImportData(string filePath);
    }
}
