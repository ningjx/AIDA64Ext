using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AIDA64Ext.Models
{
    public class AIDAShownItems
    {
        public AIDA64Data AIDA64Data { get; set; } = new AIDA64Data();

        public bool Contains(string label)
        {
            var item = AIDA64Data.Items.Where(t => t.Label == label).FirstOrDefault();
            if (item == null)
                return false;
            return true;
        }
    }
}
