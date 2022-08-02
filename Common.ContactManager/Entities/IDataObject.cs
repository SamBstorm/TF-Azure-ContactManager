using System;
using System.Collections.Generic;
using System.Text;

namespace Common.ContactManager.Entities
{
    public interface IDataObject<TId>
    {
        TId Id { get; set; }
    }
}
