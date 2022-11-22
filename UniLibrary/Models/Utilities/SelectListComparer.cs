using System.Diagnostics.CodeAnalysis;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace UniLibrary.Models.Utilities
{
    public class SelectListComparer : IEqualityComparer<SelectListItem>
    {
        public bool Equals(SelectListItem x, SelectListItem y)
        {
            return x.Text == y.Text;
        }

        public int GetHashCode(SelectListItem item)
        {
            int hashText = item.Text == null ? 0 : item.Text.GetHashCode();
            return hashText;
        }
    }
}