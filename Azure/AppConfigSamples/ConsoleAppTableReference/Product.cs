using Azure;
using Azure.Data.Tables;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleAppTableReference
{
    public record Product : ITableEntity
    {
        public string RowKey { get; set; } = default!;

        public string PartitionKey { get; set; } = default!;

        public string Name { get; init; } = default!;

        public int Quantity { get; init; }

        public bool OnSale { get; init; }

        public ETag ETag { get; set; } = default!;

        public DateTimeOffset? Timestamp { get; set; } = default!;
    }
}
