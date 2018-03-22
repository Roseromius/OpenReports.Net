using System;
using System.Collections.Generic;
using System.Text;

namespace OpenReports.Net
{
    public class UrlGenerator
    {
        public static string SortEnumToString(SortOption option)
        {
            switch (option)
            {
                case SortOption.AscendingCreatedAt:
                    return "createdAt";
                case SortOption.DescendingCreatedAt:
                    return "-createdAt";
                case SortOption.AscendingUpdatedAt:
                    return "updatedAt";
                case SortOption.DescendingUpdatedAt:
                    return "-updatedAt";
                case SortOption.AscendingAlphabetical:
                    return "name";
                case SortOption.DescendingAlphabetical:
                    return "-name";
                default:
                    return "";
            }
        }
    }
}
