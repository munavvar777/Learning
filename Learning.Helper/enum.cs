using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Learning.Helper
{
    public enum RecordStatus
    {
        Added,
        Updated,
        Deleted,
        NotFound,
        AlreadyDeleted,
        ReferenceExist,
        NoContent,
        Failed,
        Success
    }
}
